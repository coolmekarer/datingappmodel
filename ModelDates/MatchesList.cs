using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ModelDates
{
    public class MatchesList:List<Matches>
    {
        public MatchesList() { }
        public MatchesList(IEnumerable<Matches> list) : base(list) { }
        public MatchesList(IEnumerable<BaseEntity> list) : base(list.Cast<Matches>().ToList()) { }
    }
}
