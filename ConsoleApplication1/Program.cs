using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        /// <summary>  
        /// 获取时间戳  
        /// </summary>  
        /// <returns></returns>  
        public static long GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(2017, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds);
        }
        static void Main(string[] args)
        {
            //     NewMethod();
            //   GetStart();

            //Maticsoft.BLL.log l = new Maticsoft.BLL.log();
            //Maticsoft.Model.log s= l.getTop1("my9281");
        }

        //private static void GetStart()
        //{

        //    var timeid = Guid.NewGuid().ToString();
        //    Maticsoft.BLL.log l = new Maticsoft.BLL.log();
        //    l.Add(new Maticsoft.Model.log() { TableID = 1, SelecterCard = -1, PlaceID = timeid, UserID = "my9281", NextPackage = 0, TimeLine = GetTimeStamp() });
        //}

        //private static void NewMethod(string timeid)
        //{
        //    Random ran = new Random();
        //    Maticsoft.BLL.cards c = new Maticsoft.BLL.cards();
        //    var q = c.GetModelList("7");
        //    var Clist = q.Where(e => e.XiYouDu == "C").ToList();
        //    var UClist = q.Where(e => e.XiYouDu == "UC").ToList();

        //    var Rlist = q.Where(e => e.XiYouDu == "R").ToList();
        //    var SRlist = q.Where(e => e.XiYouDu == "SR").ToList();
        //    var hightlist = new List<Maticsoft.Model.cards>();
        //    SRlist.ForEach(ex => hightlist.Add(ex));
        //    for (int i = 0; i < 7; i++)
        //    {
        //        Rlist.ForEach(ex => hightlist.Add(ex));
        //    }
        //    var CPList = new List<List<Maticsoft.Model.cardpackage>>();
        //    for (int i = 0; i < 8; i++)
        //    {
        //        var nod = new List<Maticsoft.Model.cardpackage>();
        //        for (int j = 0; j < 6; j++)
        //        {
        //            nod.Add(new Maticsoft.Model.cardpackage()
        //            {
        //                PID = timeid,
        //                packageID = i,
        //                TableID = 1,
        //                CID = Clist[ran.Next(0, Clist.Count)].CID
        //            });
        //        }
        //        for (int j = 0; j < 3; j++)
        //        {
        //            nod.Add(new Maticsoft.Model.cardpackage()
        //            {
        //                PID = timeid,
        //                packageID = i,
        //                TableID = 1,
        //                CID = UClist[ran.Next(0, UClist.Count)].CID
        //            });
        //        }
        //        nod.Add(new Maticsoft.Model.cardpackage()
        //        {
        //            PID = timeid,
        //            packageID = i,
        //            TableID = 1,
        //            CID = hightlist[ran.Next(0, hightlist.Count)].CID
        //        });
        //        CPList.Add(nod);
        //    }
        //    Maticsoft.BLL.cardpackage cpbll = new Maticsoft.BLL.cardpackage();
        //    foreach (var item in CPList)
        //    {
        //        foreach (var item2 in item)
        //        {
        //            cpbll.Add(item2);
        //            Console.Write("!");
        //        }
        //    }
        //}
    }
}