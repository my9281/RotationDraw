using System;
using System.Collections.Generic;
using System.Linq;

namespace DBContent
{
    public class DBTable
    {
        public List<Entity.table> GetTableList()
        {
            var db = new Entity.zmdbEntities1();
            var li = from u in db.table
                     join s in db.userontable on u.tableid equals s.tableid into g
                     select u;
            return li.ToList();
        }
        public int SetInTable(int userid, int tableid)
        {
            var db = new Entity.zmdbEntities1();
            var ui = db.userontable.FirstOrDefault(ex => ex.userid == userid);
            if (ui != null)
            {
                db.userontable.Remove(ui);
                db.SaveChanges();
            }
            db.userontable.Add(new Entity.userontable() { tableid = tableid, userid = userid, rank = 0 });
            db.SaveChanges();
            return tableid;
        }
        public int StartGame(int tableid)
        {
            var db = new Entity.zmdbEntities1();
            if (db.table.Where(ex => ex.tableid == tableid).First().game.Count >= 1) return -1;
            var k = db.table.First(t => t.tableid == tableid).userontable;
            db.game.Add(new Entity.game()
            {
                adminid = k.First().userid,
                referee = "李校长",
                starttime = DateTime.Now,
                tableid = tableid,
                state = 0,
            });
            db.SaveChanges();
            db = new Entity.zmdbEntities1();
            return db.table.First(ex => ex.tableid == tableid).game.First().gameid;
        }
        public int AddCardPackageGame(int tableid, List<int> setids)
        {
            var db = new Entity.zmdbEntities1();
            var table = db.table.FirstOrDefault();
            var users = table.userontable.ToList();
            var game = table.game.First();
            if (game == null) return -1;
            if (game.gamepackage.Count > 0) return -2;
            for (int i = 0; i < users.Count; i++)
            {
                var user = users[i];
                setids.ForEach(setid => db.gamepackage.Add(new Entity.gamepackage()
                {
                    gameid = game.gameid,
                    gamepackageset = setid,
                    rank = i,
                    startuserid = user.userid
                }));
            }
            db.SaveChanges();
            db = new Entity.zmdbEntities1();
            game = table.game.First();
            Random ran = new Random();
            var c = db.cards.ToList();
            game.gamepackage.ToList().ForEach(ex =>
            {
                var SRlist = c.Where(e => e.Level == "传世" && e.set == ex.gamepackageset).ToList();
                var Rlist = c.Where(e => e.Level == "非凡" && e.set == ex.gamepackageset).ToList();
                var UClist = c.Where(e => e.Level == "稀有" && e.set == ex.gamepackageset).ToList();
                var Clist = c.Where(e => e.Level == "普通" && e.set == ex.gamepackageset).ToList();
                int selectlevel = ran.Next(0, 8);
                Action<List<Entity.cards>> fun = (li) => db.packagecard.Add(new Entity.packagecard()
                {
                    cardid = li[ran.Next(0, li.Count)].CardID,
                    gamepackageid = ex.gamepackageid,
                    pickituserid = null,
                });
                if (selectlevel == 7) fun(SRlist);
                else fun(Rlist);
                for (int i = 0; i < 3; i++) fun(UClist);
                for (int i = 0; i < 6; i++) fun(Clist);
                db.SaveChanges();
            });
            return db.table.First(ex => ex.tableid == tableid).game.First().gameid;
        }

        public int PickedCard(int userid, int pickedcardid)
        {
            var db = new Entity.zmdbEntities1();
            var user = (from c in db.users
                        where c.userid == userid
                        select c).First();
            var ss = db.packagecard.First(ex => ex.packagecardid == pickedcardid);
            if (ss == null) return -1;
            ss.pickituserid = userid;
            ss.userpackage.Add(new Entity.userpackage()
            {
                userid = userid,
                rank = 11 - ss.gamepackage.packagecard.Where(ex => ex.pickituserid == null).Count(),
                packagecardid = ss.packagecardid,
            });
            db.SaveChanges();
            return ss.cardid;
        }
        public void SetNow(int tableid)
        {
            var db = new Entity.zmdbEntities1();
            var gamepackage = db.game.First(ex => ex.tableid == tableid).gamepackage.ToList();
            var kd = gamepackage.GroupBy(ex => ex.startuserid);
            var p = kd.ToList();
            foreach (var item in p)
            {
                var temp = item.ToList();
                foreach (var inneritem in temp)
                {
                    inneritem.isNow = false;
                    var k = inneritem.packagecard.ToList(); 
                    var b2 = true;
                    k.ForEach(e => b2 = b2 && e.pickituserid == null); 
                    if (!b2)
                    {
                        inneritem.isNow = true;
                        break;
                    }
                }
            }
            db.SaveChanges();
        }
        public List<Entity.packagecard> GetMyList(int userid)
        {
            var db = new Entity.zmdbEntities1();
            var package = db.gamepackage.First(e => e.startuserid == userid && e.isNow == true);
            var gamepackage = db.packagecard.Where(e => e.gamepackageid == package.gamepackageid && e.pickituserid == null).ToList();
            return gamepackage;
        }
    }
}
