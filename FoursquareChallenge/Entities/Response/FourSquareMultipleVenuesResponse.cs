



using Entities;

namespace Entities.Response
{
    public class FourSquareMultipleVenuesResponse<T> : FourSquareResponse where T : Entity
    {
        public VenueResponse<T> response
        {
            get;
            set;
        }
    }
}