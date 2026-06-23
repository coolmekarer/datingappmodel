using ModelDates;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace ViewModel
{
    public class MatchesDB : BaseDB
    {
        public override BaseEntity NewEntity() => new Matches();

        public MatchesList SelectAll()
        {
            // Pass the SQL string directly to the safe, local-command base.Select()
            return new MatchesList(base.Select("SELECT * FROM Matches"));
        }

        protected override BaseEntity CreateModel(BaseEntity entity, OleDbDataReader reader)
        {
            Matches m = entity as Matches;
            if (m != null)
            {
                if (reader["User1ID"] != DBNull.Value)
                    m.User1ID = UserDB.SelectById(Convert.ToInt32(reader["User1ID"]));

                if (reader["User2ID"] != DBNull.Value)
                    m.User2ID = UserDB.SelectById(Convert.ToInt32(reader["User2ID"]));

                if (reader["ID"] != DBNull.Value)
                    m.Id = Convert.ToInt32(reader["ID"]);
            }
            return m;
        }

        public static Matches SelectById(int id)
        {
            using (MatchesDB db = new MatchesDB())
            {
                return db.SelectAll().Find(item => item.Id == id);
            }
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Matches m = entity as Matches;
            if (m == null) return;

            cmd.CommandText = "DELETE FROM Matches WHERE ID = ?";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("?", m.Id);
        }

        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Matches m = entity as Matches;
            if (m == null) return;

            cmd.CommandText = "INSERT INTO Matches (User1ID, User2ID) VALUES (?, ?)";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("?", m.User1ID.Id);
            cmd.Parameters.AddWithValue("?", m.User2ID.Id);
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Matches m = entity as Matches;
            if (m == null) return;

            cmd.CommandText = "UPDATE Matches SET User1ID = ?, User2ID = ? WHERE ID = ?";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("?", m.User1ID.Id);
            cmd.Parameters.AddWithValue("?", m.User2ID.Id);
            cmd.Parameters.AddWithValue("?", m.Id);
        }
        public List<Matches> GetMatchesForUser(int userId)
        {
            // Fetches all matches where the user is either User1 or User2
            string sql = "SELECT * FROM Matches WHERE User1ID = ? OR User2ID = ?";
            var allMatches = base.Select(sql, userId, userId);
            return new MatchesList(allMatches);
        }

        public bool MatchExists(int user1Id, int user2Id)
        {
            string connString = BaseDB.connectionString;

            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                string sql = "SELECT COUNT(*) FROM [Matches] WHERE (User1ID = ? AND User2ID = ?) OR (User1ID = ? AND User2ID = ?)";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                cmd.Parameters.AddWithValue("?", user1Id);
                cmd.Parameters.AddWithValue("?", user2Id);
                cmd.Parameters.AddWithValue("?", user2Id);
                cmd.Parameters.AddWithValue("?", user1Id);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
    }
}