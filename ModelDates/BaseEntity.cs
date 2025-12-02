using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDates
{
    public abstract class BaseEntity
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        } 
     
    }
}
