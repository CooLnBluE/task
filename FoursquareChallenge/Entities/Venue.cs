using System;
using System.Collections.Generic;

namespace Entities
{
    public class Venue : Entity
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
     

      
        public Location location
        {
            get;
            set;
        }
      
     
       
        public bool verified
        {
            get;
            set;
        }
      
     


      
        public string description
        {
            get;
            set;
        }

     
        public Int64 createdAt
        {
            get;
            set;
        }
     

       
        public string shortUrl
        {
            get;
            set;
        }

       
        public string canonicalUrl
        {
            get;
            set;
        }     

     

       
        public string timeZone
        {
            get;
            set;
        }

        public double rating
        {
            get;
            set;
        }

        //public EntityGroups<User> hereNow
        //{
        //    get;
        //    set;
        //}
    }
}