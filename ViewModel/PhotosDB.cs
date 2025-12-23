using ModelDates;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class PhotosDB:BaseDB
    {
        

        public PhotosList SelectAll()
        {
            command.CommandText = $"SELECT * FROM Photos";

            PhotosList photosList = new PhotosList(base.Select());
            return photosList;
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Photos ph = entity as Photos;
            ph.User = UserDB.SelectById((int)reader["UserID"]);
            ph.Url =reader["PhotoURL"].ToString();
           
            base.CreateModel(entity);
            return ph;

        }
        public override BaseEntity NewEntity()
        {
            return new Photos();
        }

        static private PhotosList list = new PhotosList();
        public static Photos SelectById(int id)
        {
            PhotosDB db = new PhotosDB();
            list = db.SelectAll();

            Photos ph = list.Find(item => item.Id == id);
            return ph;
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
