namespace Entities
{
    public class Photo : Entity
    {
      
        public string id
        {
            get;
            set;
        }

       
        public string createdAt
        {
            get;
            set;
        }

       
        public string prefix
        {
            get;
            set;
        }

      
        public string suffix
        {
            get;
            set;
        }

       
        public int width
        {
            get;
            set;
        }

       
        public int height
        {
            get;
            set;
        }

       
        public string url
        {
            get;
            set;
        }

       
        public EntityItems<Dimension> sizes
        {
            get;
            set;
        }

        
        public Source source
        {
            get;
            set;
        }

        public string visibility
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
      
    }   
}