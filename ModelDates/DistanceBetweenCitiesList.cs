using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDates
{
    public class DistanceBetweenCitiesList:List<DistanceBetweenCities>
    {
        public DistanceBetweenCitiesList() { }
        public DistanceBetweenCitiesList(IEnumerable<DistanceBetweenCities> list) : base(list) { }
        public DistanceBetweenCitiesList(IEnumerable<BaseEntity> list) : base(list.Cast<DistanceBetweenCities>().ToList()) { }
    }
}
