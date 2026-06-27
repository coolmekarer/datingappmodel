using ModelDates;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace ViewModel
{
    public class UserDB : BaseDB
    {
        public UserList SelectAll()
        {
            return new UserList(base.Select("SELECT * FROM [User]"));
        }

        private bool HasColumn(OleDbDataReader r, string name)
        {
            for (int i = 0; i < r.FieldCount; i++)
                if (string.Equals(r.GetName(i), name, StringComparison.OrdinalIgnoreCase))
                    return true;
            return false;
        }

        protected override BaseEntity CreateModel(BaseEntity entity, OleDbDataReader reader)
        {
            User u = entity as User;
            if (u == null) return entity;

            u.Username = HasColumn(reader, "Username") && reader["Username"] != DBNull.Value ? reader["Username"].ToString() : string.Empty;
            u.Email = HasColumn(reader, "Email") && reader["Email"] != DBNull.Value ? reader["Email"].ToString() : string.Empty;
            u.Password = HasColumn(reader, "Password") && reader["Password"] != DBNull.Value ? reader["Password"].ToString() : string.Empty;
            u.Bio = HasColumn(reader, "Bio") && reader["Bio"] != DBNull.Value ? reader["Bio"].ToString() : string.Empty;
            u.ProfilePic = HasColumn(reader, "ProfilePic") && reader["ProfilePic"] != DBNull.Value ? reader["ProfilePic"].ToString() : string.Empty;

            u.DateOfBirth = HasColumn(reader, "DateOfBirth") && reader["DateOfBirth"] != DBNull.Value ? Convert.ToDateTime(reader["DateOfBirth"]) : DateTime.Now.AddYears(-18);
            u.CreatedAt = HasColumn(reader, "CreatedAt") && reader["CreatedAt"] != DBNull.Value ? Convert.ToDateTime(reader["CreatedAt"]) : DateTime.Now;
            u.Age = HasColumn(reader, "Age") && reader["Age"] != DBNull.Value ? Convert.ToInt32(reader["Age"]) : 0;

            u.Gender = new Gender { Id = HasColumn(reader, "Gender") && reader["Gender"] != DBNull.Value ? Convert.ToInt32(reader["Gender"]) : 0 };
            u.City = new City { Id = HasColumn(reader, "City") && reader["City"] != DBNull.Value ? Convert.ToInt32(reader["City"]) : 0 };

            string idName = HasColumn(reader, "id") ? "id" : "ID";
            u.Id = (HasColumn(reader, idName) && reader[idName] != DBNull.Value) ? Convert.ToInt32(reader[idName]) : 0;

            return u;
        }

        public override BaseEntity NewEntity() => new User();

        public static User SelectById(int id)
        {
            using (UserDB db = new UserDB())
            {
                return db.SelectAll().Find(item => item.Id == id);
            }
        }

        // Updated SelectFilteredDiscovery to use the isolated local-command pattern
        public UserList SelectFilteredDiscovery(int currentUserId, int genderId, int minAge, int maxAge, int maxDistance)
        {
            // IMPORTANT: This creates a unique query string that BaseDB will execute safely
            string sql = $"SELECT * FROM [User] WHERE ID <> {currentUserId} AND Gender = {genderId} " +
                         $"AND Age BETWEEN {minAge} AND {maxAge}";

            // Note: For production, use parameterized queries to prevent SQL Injection
            return new UserList(base.Select(sql));
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            User u = entity as User;
            if (u == null) return;
            cmd.CommandText = "DELETE FROM [User] WHERE ID = ?";
            cmd.Parameters.AddWithValue("?", u.Id);
        }

        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            User p = entity as User;
            if (p == null) return;

            cmd.CommandText = "INSERT INTO [User] (Username, Email, [Password], Gender, DateOfBirth, City, Bio, ProfilePic, CreatedAt, Age) VALUES (?,?,?,?,?,?,?,?,?,?)";
            cmd.Parameters.Clear();

            // Helper to add parameters with explicit types to stop "Data type mismatch"
            cmd.Parameters.Add("@p1", OleDbType.VarWChar).Value = (object)p.Username ?? DBNull.Value;
            cmd.Parameters.Add("@p2", OleDbType.VarWChar).Value = (object)p.Email ?? DBNull.Value;
            cmd.Parameters.Add("@p3", OleDbType.VarWChar).Value = (object)p.Password ?? DBNull.Value;
            cmd.Parameters.Add("@p4", OleDbType.Integer).Value = p.Gender != null ? (object)p.Gender.Id : DBNull.Value;
            cmd.Parameters.Add("@p5", OleDbType.Date).Value = p.DateOfBirth > DateTime.MinValue ? (object)p.DateOfBirth : DBNull.Value;
            cmd.Parameters.Add("@p6", OleDbType.Integer).Value = p.City != null ? (object)p.City.Id : DBNull.Value;
            cmd.Parameters.Add("@p7", OleDbType.LongVarWChar).Value = (object)p.Bio ?? DBNull.Value;
            cmd.Parameters.Add("@p8", OleDbType.LongVarWChar).Value = (object)p.ProfilePic ?? DBNull.Value;
            cmd.Parameters.Add("@p9", OleDbType.Date).Value = p.CreatedAt > DateTime.MinValue ? (object)p.CreatedAt : DateTime.Now;
            cmd.Parameters.Add("@p10", OleDbType.Integer).Value = (object)p.Age;
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            User c = entity as User;
            if (c == null) return;

            cmd.CommandText = "UPDATE [User] SET Username=?, City=?, Email=?, [Password]=?, Gender=?, DateOfBirth=?, Bio=?, ProfilePic=?, Age=?, CreatedAt=? WHERE ID=?";
            cmd.Parameters.Clear();

            // Use explicit OleDbType to prevent "Data type mismatch"
            cmd.Parameters.Add("@p1", OleDbType.VarWChar).Value = (object)c.Username ?? DBNull.Value;
            cmd.Parameters.Add("@p2", OleDbType.Integer).Value = c.City != null ? (object)c.City.Id : DBNull.Value;
            cmd.Parameters.Add("@p3", OleDbType.VarWChar).Value = (object)c.Email ?? DBNull.Value;
            cmd.Parameters.Add("@p4", OleDbType.VarWChar).Value = (object)c.Password ?? DBNull.Value;
            cmd.Parameters.Add("@p5", OleDbType.Integer).Value = c.Gender != null ? (object)c.Gender.Id : DBNull.Value;
            cmd.Parameters.Add("@p6", OleDbType.Date).Value = (object)c.DateOfBirth;
            cmd.Parameters.Add("@p7", OleDbType.LongVarWChar).Value = (object)c.Bio ?? DBNull.Value;
            cmd.Parameters.Add("@p8", OleDbType.LongVarWChar).Value = (object)c.ProfilePic ?? DBNull.Value;
            cmd.Parameters.Add("@p9", OleDbType.Integer).Value = (object)c.Age;
            cmd.Parameters.Add("@p10", OleDbType.Date).Value = (object)c.CreatedAt;

            // The WHERE clause ID parameter
            cmd.Parameters.Add("@p11", OleDbType.Integer).Value = (object)c.Id;
        }
    }
}