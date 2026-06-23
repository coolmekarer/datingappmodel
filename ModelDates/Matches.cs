using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDates
{
    public class Matches : BaseEntity
    {
        public User User1ID { get; set; }
        public User User2ID { get; set; }

        // This returns the "Other" user object
        public User GetOtherUser(int currentUserId)
        {
            if (User1ID == null || User2ID == null) return null;

            return (User1ID.Id == currentUserId) ? User2ID : User1ID;
        }
    }
}
