using System.Collections.Generic;

namespace Entities
{
    public class Category : Entity
    {      
        public string id
        {
            get;
            set;
        }
       
        public string name
        {
            get;
            set;
        }
       
        public string pluralName
        {
            get;
            set;
        }

       
        public string shortName
        {
            get;
            set;
        }

    
        public Icon icon
        {
            get;
            set;
        }

      
        public List<string> parents
        {
            get;
            set;
        }

      
        public bool primary
        {
            get;
            set;
        }

       
        public List<Category> categories
        {
            get;
            set;
        }
    }
}