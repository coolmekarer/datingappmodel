using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDates
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }

    }
}
