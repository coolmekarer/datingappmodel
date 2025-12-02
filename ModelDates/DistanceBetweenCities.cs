using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ModelDates
{
    public class DistanceBetweenCities :BaseEntity
    {

      
        public City City1 { get; set; }
     
        public City City2 { get; set; }
        public double DistanceKm { get; set; }
      
    }
}
