using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1
{
    public class PhotosList:List<Photos>
    {
        public PhotosList() { }
        public PhotosList(IEnumerable<Photos> list) : base(list) { }
        public PhotosList(IEnumerable<BaseEntity> list) : base(list.Cast<Photos>().ToList()) { }
    }
}
