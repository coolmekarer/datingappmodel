using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ModelDates
{
    public class Messages : BaseEntity
    {
    
        public Matches Match { get; set; }
      
        public User Sender { get; set; }
        public string MessageText { get; set; }
        public DateTime SentAt { get; set; } = DateTime.UtcNow;

    }
}
