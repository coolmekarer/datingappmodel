using ModelDates;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class MessagesDB:BaseDB
    {
        

        public MessagesList SelectAll()
        {
            command.CommandText = $"SELECT * FROM Messages";

            MessagesList messagesList = new MessagesList(base.Select());
            return messagesList;
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            ModelDates.Messages me = entity as ModelDates.Messages;
            me.Match = MatchesDB.SelectById((int)reader["MatchID"]);
            me.Sender = UserDB.SelectById((int)reader["SenderID"]);
            me.MessageText = reader["MessageText"].ToString();
            me.SentAt= DateTime.Parse(reader["SentAt"].ToString());

            base.CreateModel(entity);
            return me;

        }
        public override BaseEntity NewEntity()
        {
            return new Messages();
        }

        static private MessagesList list = new MessagesList();
        public static Messages SelectById(int id)
        {
            MessagesDB db = new MessagesDB();
            list = db.SelectAll();

            Messages me = list.Find(item => item.Id == id);
            return me;
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
