using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDates
{
    public class Photos : BaseEntity
    {
       
        public User User { get; set; }
        public string Url { get; set; }
        
    }
}
