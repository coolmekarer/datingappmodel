using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1
{
    public class Photos : BaseEntity
    {
       
        public User User { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; } = false;
    }
}
