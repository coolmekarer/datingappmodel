using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1
{
    public class Matches : BaseEntity
    {
      
        public User User1 { get; set; }

   
        public User User2 { get; set; }
    }
}
