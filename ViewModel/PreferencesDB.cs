using ModelDates;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class PreferencesDB:BaseDB
    {
   
        public PreferencesList SelectAll()
        {
            command.CommandText = $"SELECT * FROM Preferences";

            PreferencesList preferencesList = new PreferencesList(base.Select());
            return preferencesList;
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Preferences p = entity as Preferences;
            p.User = UserDB.SelectById((int) reader["UserID"]);
            p.MinAge =int.Parse( reader["AgeMin"].ToString());
            p.MaxAge =int.Parse( reader["AgeMax"].ToString());
            p.PreferredGender = GenderDB.SelectById((int)reader["PreferredGender"]);
            var xx = reader["DistanceMax"].ToString();
            p.MaxDistanceKm =int.Parse( reader["DistanceMax"].ToString()); 
            base.CreateModel(entity);
            return p;

        }
        public override BaseEntity NewEntity()
        {
            return new Preferences();
        }

        static private PreferencesList list = new PreferencesList();
        public static Preferences SelectById(int id)
        {
            PreferencesDB db = new PreferencesDB();
            list = db.SelectAll();

            Preferences p = list.Find(item => item.Id == id);
            return p;
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
            throw new NotImplementedException();
        }
    }
}
