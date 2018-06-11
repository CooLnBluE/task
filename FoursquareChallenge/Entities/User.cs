namespace Entities
{
    public class User : Entity
    {
    
        public string id
        {
            get;
            set;
        }

      
        public string firstName
        {
            get;
            set;
        }

      
        public string lastName
        {
            get;
            set;
        }

       
        public string gender
        {
            get;
            set;
        }

       
        public Icon photo
        {
            get;
            set;
        }

      
        public EntityGroups<User> friends
        {
            get;
            set;
        }

       
        public EntityItems<Tip> tips
        {
            get;
            set;
        }

       
        public string homeCity
        {
            get;
            set;
        }

     
        public string bio
        {
            get;
            set;
        }

  
        public Contact contact
        {
            get;
            set;
        }

       
        public bool pings
        {
            get;
            set;
        }

  
        public string type
        {
            get;
            set;
        }

      
        public string relationship
        {
            get;
            set;
        }
      
        public EntityItems<Venue> mayorships
        {
            get;
            set;
        }

       

        public EntityItems<User> following
        {
           get;
           set;
        }

      
        public EntityItems<User> followers
        {
            get;
            set;
        }
       
        public EntityItems<User> request
        {
            get;
            set;
        }       
    }
}