using ModelDates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class MatchesDB:BaseDB
    {
       

        public MatchesList SelectAll()
        {
            command.CommandText = $"SELECT * FROM Matches";

            MatchesList matchesList = new MatchesList(base.Select());
            return matchesList;
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Matches m = entity as Matches;
            m.User1 = UserDB.SelectById((int)reader["User1ID"]);
            m.User2 = UserDB.SelectById((int)reader["User2ID"]);

            base.CreateModel(entity);
            return m;

        }
        public override BaseEntity NewEntity()
        {
            return new Matches();
        }

        static private MatchesList list = new MatchesList();
        public static Matches SelectById(int id)
        {
            MatchesDB db = new MatchesDB();
            list = db.SelectAll();

            Matches m = list.Find(item => item.Id == id);
            return m;
        }
    }
}
