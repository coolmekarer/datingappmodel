using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace datingapp1
{
    public class Messages : BaseEntity
    {
    
        public Match Match { get; set; }
      
        public User Sender { get; set; }
        public string MessageText { get; set; }
        public DateTime SentAt { get; set; } = DateTime.UtcNow;

    }
}
