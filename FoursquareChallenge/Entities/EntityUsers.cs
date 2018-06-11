using System;

namespace Entities
{
    public class EntityUsers : Entity
    {
        public Int64 count
        {
            get;
            set;
        }

        public User user
        {
            get;
            set;
        }
    }
}
