using System;
using System.Collections.Generic;

namespace Entities
{
    public class EntityGroups<T> : Entity where T : Entity
    {
        public Int64 count
        {
            get;
            set;
        }

        public string summary
        {
            get;
            set;
        }

        public List<EntityItems<T>> groups
        {
            get;
            set;
        }
    }
}