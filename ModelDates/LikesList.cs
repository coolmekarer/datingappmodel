using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDates
{
    public class LikesList : List<Likes>
    {
        public LikesList() { }
        public LikesList(IEnumerable<Likes> list) : base(list) { }
        public LikesList(IEnumerable<BaseEntity> list) : base(list.Cast<Likes>().ToList())
        {
        }
    }
}
