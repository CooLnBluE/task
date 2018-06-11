using System.Collections.Generic;

namespace Entities
{
    public class TimeFrame : Entity
    {
      
        public string days
        {
            get;
            set;
        }

      
        public bool includesToday
        {
            get;
            set;
        }

       
        public List<Open> open
        {
            get;
            set;
        }
    }
}