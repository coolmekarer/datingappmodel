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
            Messages c = entity as Messages;
            if (c != null)
            {
                // Remove the comma after the second '?' and add a space before 'WHERE'
                string sqlStr = "UPDATE Messages SET MatchID=?, SenderID=?, MessageText=?,SentAt=?" +
                                "WHERE ID=?";

                cmd.CommandText = sqlStr;
                cmd.Parameters.Clear();

                // 1. Text fields
                cmd.Parameters.Add("@cMatchID", OleDbType.Integer).Value = c.Match.Id;

                // 2. Numeric fields (Ensure these are integers in Access)
                cmd.Parameters.Add("@cSenderID", OleDbType.Integer).Value = c.Sender.Id;

                cmd.Parameters.Add("@cMessageText", OleDbType.VarWChar).Value = c.MessageText;
                cmd.Parameters.Add("@cSentAt", OleDbType.Date).Value = c.SentAt;

                // 9. WHERE ID (Integer)
                cmd.Parameters.Add("@id", OleDbType.Integer).Value = c.Id;
            }
        }
    }
}
