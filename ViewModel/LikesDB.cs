using ModelDates;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class LikesDB:BaseDB
    {
      

        public LikesList SelectAll()
        {
            command.CommandText = $"SELECT * FROM Likes";

           LikesList likesList = new LikesList(base.Select());
            return likesList;
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Likes l = entity as Likes;
            l.Liker = UserDB.SelectById((int)reader["LikerID"]);
            l.LikedUser = UserDB.SelectById((int)reader["LikedID"]);
            base.CreateModel(entity);
            return l;

        }
        public override BaseEntity NewEntity()
        {
            return new Likes();
        }

        static private LikesList list = new LikesList();
        public static Likes SelectById(int id)
        {
            LikesDB db = new LikesDB();
            list = db.SelectAll();

            Likes l = list.Find(item => item.Id == id);
            return l;
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
