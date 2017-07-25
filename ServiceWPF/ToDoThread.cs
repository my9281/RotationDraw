using CommonEntity;
using Newtonsoft.Json;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ServiceWPF
{
    public class ToDoThread
    {
        static DBContent.DBUser db = new DBContent.DBUser();
        static DBContent.DBTable dbt = new DBContent.DBTable();
        public static void Init(ConnectBase<string> conn, Socket s)
        {
            new Thread(() =>
            {
                try
                {
                    if (conn.Title == "login")
                    {
                        var k = DeserializeJsonToObject<LoginInfo>(conn.Content);
                        var u = db.UserLogin(k.name, k.password);
                        byte[] bs = Encoding.UTF8.GetBytes(u.ToString());
                        s.Send(bs, bs.Length, 0);
                    }
                    if (conn.Title == "GetTable")
                    {
                        var li = dbt.GetTableList();
                        byte[] bs = Encoding.UTF8.GetBytes(SerializeObject(li));
                        s.Send(bs, bs.Length, 0);
                    }
                }
                catch (System.Exception e)
                {
                    byte[] bs = Encoding.UTF8.GetBytes(e.Message.ToString());
                    s.Send(bs, bs.Length, 0);
                }

            }).Start();
        }
        public static T DeserializeJsonToObject<T>(string json) where T : class => new JsonSerializer().Deserialize(new JsonTextReader(new StringReader(json)), typeof(T)) as T;
        public static string SerializeObject(object o) => JsonConvert.SerializeObject(o);
    }
}
