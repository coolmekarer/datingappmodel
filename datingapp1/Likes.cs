using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datingapp1
{
    public class Likes : BaseEntity
    {
      
        public User Liker { get; set; }
      
        public User LikedUser { get; set; }
    }
}
