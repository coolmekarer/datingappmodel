using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDates
{
    public class MessagesList:List<Messages>
    {
        public MessagesList() { }
        public MessagesList(IEnumerable<Messages> list) : base(list) { }
        public MessagesList(IEnumerable<BaseEntity> list) : base(list.Cast<Messages>().ToList()) { }
    }
}
