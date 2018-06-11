using System;
using System.Collections.Generic;

namespace Entities
{
    public class EntityItems<T> : Entity where T : Entity
    {
        public string type
        {
            get;
            set;
        }

        public string name
        {
            get;
            set;
        }

        public Int64 count
        {
            get;
            set;
        }

        public List<T> items
        {
            get;
            set;
        }
    }
}