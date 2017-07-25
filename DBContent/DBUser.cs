using System.Linq;
namespace DBContent
{
    public class DBUser
    {
        public bool CreateUser(Entity.users u)
        {
            Entity.zmdbEntities1 db = new Entity.zmdbEntities1();
            db.users.Add(u);
            db.SaveChanges();
            return true;
        }
        public int UserLogin(string userloginname, string password)
        {
            Entity.zmdbEntities1 db = new Entity.zmdbEntities1();
            var u = db.users.FirstOrDefault(ex => ex.userloginname == userloginname && ex.password == password);
            if (u != null)
            {
                return u.userid;
            }
            return -1;
        }
        public Entity.users GetUserByid(int id)
        {
            Entity.zmdbEntities1 db = new Entity.zmdbEntities1();
            var u = db.users.FirstOrDefault(ex => ex.userid == id);
            return u;
        }
    }
}
