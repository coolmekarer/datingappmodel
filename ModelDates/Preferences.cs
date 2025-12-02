using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDates
{
    public class Preferences :BaseEntity
    {
      
        public User User { get; set; }

        public int MinAge { get; set; }
        public int MaxAge { get; set; }

        public Gender PreferredGender { get; set; }
        public int MaxDistanceKm { get; set; }
    }
}
