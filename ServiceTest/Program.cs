using DBContent;
using Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace ServiceTest
{
    class Program
    {
        static void Main(string[] args)
        {
            DBUser d = new DBUser();
            DBTable dt = new DBTable();
            // Console.Write(dt.StartGame(1));
            //添加card
            //   dt.AddCardPackageGame(1, new List<int>() { 9, 9, 10, 10 });
            //dt.PickedCard(1,321);
            //Console.ReadLine();

        }


        private static void AddRobot(DBTable dt)
        {

            //登录
            //var c = d.UserLogin("my9281", "chen_1992");
            //获取用户信息
            //var p = d.GetUserByid(c);
            //   AddRobot(dt);
            //p = d.GetUserByid(c);
            //var t = p.userontable.ToList().First().table;
            //t.userontable.ToList().ForEach(ex => Console.WriteLine("{0},{1},{2}", ex.users.username, ex.users.title, ex.rank));
            //RegistAndLogin(d);

            //添加机器人
            for (int i = 1; i <= 8; i++)
            {
                dt.SetInTable(i, 1);
            }
        }

        private static void RegistAndLogin(DBContent.DBUser d)
        {
            var b = d.CreateUser(new users()
            {
                userloginname = "my9281",
                password = "chen_1992",
                registtime = DateTime.Now,
                title = "大腐竹",
                username = "阮清寒"
            });
            Console.WriteLine(b);
            var c = d.UserLogin("my9281", "chen_1992");
            Console.WriteLine(c);
            var p = d.GetUserByid(c);
            Console.WriteLine(p);
        }
    }



    public class XmlSerializeUtil
    {
        #region 反序列化  
        /// <summary>  
        /// 反序列化  
        /// </summary>  
        /// <param name="type">类型</param>  
        /// <param name="xml">XML字符串</param>  
        /// <returns></returns>  
        public static T DeserializeFromXml<T>(string filePath)
        {
            try
            {
                if (!System.IO.File.Exists(filePath))
                    throw new ArgumentNullException(filePath + " not Exists");

                using (System.IO.StreamReader reader = new System.IO.StreamReader(filePath))
                {
                    System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(typeof(T));
                    T ret = (T)xs.Deserialize(reader);
                    return ret;
                }
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }
        #endregion

        #region 序列化  
        /// <summary>  
        /// 序列化  
        /// </summary>  
        /// <param name="type">类型</param>  
        /// <param name="obj">对象</param>  
        /// <returns></returns>  
        public static string Serializer(Type type, object obj)
        {
            MemoryStream Stream = new MemoryStream();
            XmlSerializer xml = new XmlSerializer(type);
            //序列化对象  
            xml.Serialize(Stream, obj);
            Stream.Position = 0;
            StreamReader sr = new StreamReader(Stream);
            string str = sr.ReadToEnd();

            sr.Dispose();
            Stream.Dispose();

            return str;
        }

        #endregion
    }
}
