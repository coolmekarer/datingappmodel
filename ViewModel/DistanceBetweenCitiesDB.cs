using ModelDates;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class DistanceBetweenCitiesDB:BaseDB
    {
        

        public DistanceBetweenCitiesList SelectAll()
        {
            command.CommandText = $"SELECT * FROM DistanceBetweenCities";

            DistanceBetweenCitiesList distancebetweencitiesList = new DistanceBetweenCitiesList(base.Select());
            return distancebetweencitiesList;
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            DistanceBetweenCities d = entity as DistanceBetweenCities;
            d.City1 = CityDB.SelectById((int)reader["City1"]);
            d.City2= CityDB.SelectById((int)reader["City2"]);
            d.DistanceKm = double.Parse(reader["KM"].ToString());
            base.CreateModel(entity);
            return d;

        }
        public override BaseEntity NewEntity()
        {
            return new DistanceBetweenCities();
        }

        static private DistanceBetweenCitiesList list = new DistanceBetweenCitiesList();
        public static DistanceBetweenCities SelectById(int id)
        {
            DistanceBetweenCitiesDB db = new DistanceBetweenCitiesDB();
            list = db.SelectAll();

            DistanceBetweenCities d = list.Find(item => item.Id == id);
            return d;
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
