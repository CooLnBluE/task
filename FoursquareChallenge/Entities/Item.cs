using System;


namespace Entities
{
    public class Item : Entity
    {
      
        public string id
        {
            get;
            set;
        }

       
        public User user
        {
            get;
            set;
        }

      
        public Venue venue
        {
            get;
            set;
        }

      
        public Tip tip
        {
            get;
            set;
        }

        
        public string note
        {
            get;
            set;
        }

      
        public Int64 createdAt
        {
            get;
            set;
        }

     
       
    }
}