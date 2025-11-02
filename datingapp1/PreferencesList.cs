using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1
{
    public class PreferencesList:List<Preferences>
    {
        public PreferencesList() { }
        public PreferencesList(IEnumerable<Preferences> list) : base(list) { }
        public PreferencesList(IEnumerable<BaseEntity> list) : base(list.Cast<Preferences>().ToList()) { }
    }
}
