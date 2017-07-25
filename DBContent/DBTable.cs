using System;
using System.Collections.Generic;
using System.Linq; 
namespace DBContent
{
    public class DBTable
    {
        /// <summary>
        /// 获得桌号列表
        /// </summary>
        /// <returns></returns>
        public List<Entity.table> GetTableList()
        {
            var db = new Entity.zmdbEntities1();
            var li = from u in db.table
                     join s in db.userontable on u.tableid equals s.tableid into g
                     select u;
            return li.ToList();
        }
        /// <summary>
        /// 坐下
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="tableid">桌号</param>
        /// <returns></returns>
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
        /// <summary>
        /// 开始游戏
        /// </summary>
        /// <param name="tableid">桌号</param>
        /// <returns></returns>
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
        /// <summary>
        /// 向桌子上发补充包
        /// </summary>
        /// <param name="tableid">桌ID</param>
        /// <param name="setids">四包分别是什么蛋</param>
        /// <returns></returns>
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
        /// <summary>
        /// 选卡
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="pickedcardid">选择的卡ID</param>
        /// <returns></returns>
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
        /// <summary>
        /// 刷新当前牌桌所开第几包（请在开第二第三第四包之前调用）
        /// </summary>
        /// <param name="tableid">桌号</param>
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
        /// <summary>
        /// 传牌
        /// </summary>
        /// <param name="tableid">桌号</param>
        /// <param name="IsRight">是否右传</param>
        /// <returns>桌号</returns>
        public int ChangeCard(int tableid, bool IsRight)
        {
            var db = new Entity.zmdbEntities1();
            var game = db.game.Where(ex => ex.tableid == tableid).First();
            var packagelist = game.gamepackage.ToList();
            for (int i = 0; i < packagelist.Count; i++)
            {
                if (IsRight)
                {
                    var j = i + 1 >= packagelist.Count ? packagelist.Count : i + 1;
                    var item = packagelist[i];
                    var item2 = packagelist[j];
                    var temp = item2.startuserid;
                    item2.startuserid = item.startuserid;
                    item.startuserid = temp;
                }
                else
                {
                    var j = i - 1 < 0 ? packagelist.Count - 1 : i - 1;
                    var item = packagelist[i];
                    var item2 = packagelist[j];
                    var temp = item2.startuserid;
                    item2.startuserid = item.startuserid;
                    item.startuserid = temp;
                }
            }
            db.SaveChanges();
            return tableid;
        }
        /// <summary>
        /// 获得我正在选的扩展包信息
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <returns></returns>
        public List<Entity.packagecard> GetMyList(int userid)
        {
            var db = new Entity.zmdbEntities1();
            var package = db.gamepackage.First(e => e.startuserid == userid && e.isNow == true);
            var gamepackage = db.packagecard.Where(e => e.gamepackageid == package.gamepackageid && e.pickituserid == null).ToList();
            return gamepackage;
        }
        /// <summary>
        /// 获得我的已经扣下的卡表
        /// </summary>
        /// <param name="gameid">游戏ID</param>
        /// <param name="userid">用户ID</param>
        /// <returns></returns>
        public List<Entity.cards> GetMyCardList(int gameid, int userid)
        {
            var db = new Entity.zmdbEntities1();
            var li = db.packagecard.Where(ex => ex.gamepackage.gameid == gameid && userid == ex.pickituserid).ToList();
            List<Entity.cards> s = new List<Entity.cards>();
            li.ForEach(ex => s.Add(ex.cards));
            return s;
        }
    }
}
