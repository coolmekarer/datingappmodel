using ModelDates;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class GenderDB:BaseDB
    {
        public override BaseEntity NewEntity()
        {
            return new Gender();
        }

        public GenderList SelectAll()
        {
            command.CommandText = $"SELECT * FROM Gender";

            GenderList genderList = new GenderList(base.Select());
            return genderList;
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Gender g = entity as Gender;
            if (g != null)
            {
                g.Name = reader["GenderName"].ToString();
            }

            base.CreateModel(entity);
            return entity;
        }

        static private GenderList list = new GenderList();
        public static Gender SelectById(int id)
        {
            GenderDB db = new GenderDB();
            list = db.SelectAll();
            Gender g = list.Find(item => item.Id == id);
            return g;
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            throw new NotImplementedException();
        }

        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Gender g = entity as Gender;
            if (g != null)
            {
                string sqlStr = $"Insert INTO Gender (GenderName) VALUES (@cName)";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@cName", g.Name));
            }
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Gender g = entity as Gender;
            if (g != null)
            {
                string sqlStr = $"UPDATE Gender SET GenderName=@gName WHERE ID=@id";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@gName", g.Name));
                command.Parameters.Add(new OleDbParameter("@id", g.Id));
            }
        }
    }
}