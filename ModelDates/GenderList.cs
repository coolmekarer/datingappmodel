using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDates
{
    public class GenderList:List<Gender>
    {
        public GenderList() { }
        public GenderList(IEnumerable<Gender> list) : base(list) { }
        public GenderList(IEnumerable<BaseEntity> list) : base(list.Cast<Gender>().ToList()) { }
    }
}
