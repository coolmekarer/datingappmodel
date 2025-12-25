using ModelDates;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class UserDB:BaseDB
    {
       

        public UserList SelectAll()
        {
            command.CommandText = $"SELECT * FROM [User]";

            UserList userList = new UserList(base.Select());
            return userList;
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            User u = entity as User;
            u.Username = reader["Username"].ToString();
            u.Email = reader["Email"].ToString();
            u.Password = reader["Password"].ToString();
            u.DateOfBirth = DateTime.Parse(reader["DateOfBirth"].ToString());
            u.Bio = reader["Bio"].ToString();
            u.Gender= GenderDB.SelectById((int)reader["Gender"]);
            u.City= CityDB.SelectById((int)reader["City"]);
            u.CreatedAt = DateTime.Parse(reader["CreatedAt"].ToString()) ;
            u.Age = int.Parse(reader["Age"].ToString());
            base.CreateModel(entity);
            return u;
            
        }
        public override BaseEntity NewEntity()
        {
            return new User();
        }

        static private UserList list = new UserList();
        public static   User SelectById(int id)
        {
            UserDB db = new UserDB();
            list = db.SelectAll();

            User u = list.Find(item => item.Id == id);
            return u;
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            throw new NotImplementedException();
        }

        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            throw new NotImplementedException();
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            User c = entity as User;
            if (c != null)
            {
                string sqlStr = $"UPDATE [User] SET Username=@cUsername,City=@ccode, " +
                    $"Email=@cEmail, [Password]=@cPassword, Gender=@cGender, " +
                    $"DateOfBirth=@cDateOfBirth, Bio=@cBio," +
                    $" Age=@cAge," +
                    $"CreatedAt=@cCreatedAt" +
                                $" WHERE ID=@id";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@cUsername", c.Username));
                command.Parameters.Add(new OleDbParameter("@ccode", c.City.Id));
                command.Parameters.Add(new OleDbParameter("@Email", c.Email));
                command.Parameters.Add(new OleDbParameter("@cPassword", c.Password));
                command.Parameters.Add(new OleDbParameter("@cGender", c.Gender.Id));
                command.Parameters.Add(new OleDbParameter("@cDateOfBirth", c.DateOfBirth));
                command.Parameters.Add(new OleDbParameter("@cBio", c.Bio));
                command.Parameters.Add(new OleDbParameter("@cAge", c.Age));
                command.Parameters.Add(new OleDbParameter("@cCreatedAt", c.CreatedAt));
                command.Parameters.Add(new OleDbParameter("@cId", c.Id));
              
               
            }
        }
    }
}
