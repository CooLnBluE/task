using System.Collections.Generic;

namespace Entities
{
    public class Hour : Entity
    {
        public string status
        {
            get;
            set;
        }

        public bool isOpen
        {
            get;
            set;
        }

        public List<TimeFrame> timeframes
        {
            get;
            set;
        }

        public List<Segment> segments
        {
            get;
            set;
        }
    }
}