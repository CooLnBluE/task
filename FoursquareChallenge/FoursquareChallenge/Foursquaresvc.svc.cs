using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Entities;
using FoursquareChallenge.DataContracts;

namespace FoursquareChallenge
{
  
    public class Foursquaresvc : IFoursquaresvc
    {

        public SearchTipResult SearchTip(DataContracts.TipSearch input)
        {
            SearchTipResult result = new SearchTipResult();
            try
            {
                Core srv = new Core();
                var data = srv.SearchTip(input);
                result.result = new BaseResult
                {
                    isSuccesful = true                    
                };
                result.tipsList = data.Select(a=>a.text).ToList();
                return result;
            }
            catch(Exception ex)
            {
                result.result = new BaseResult
                {
                    isSuccesful = false,
                    resultMessage = ex.Message
                };
                return result;
            }
        }

        public SearchVenueByCategoryResult SearchVenueByCategory(VenueSearchCategory input)
        {
            SearchVenueByCategoryResult result = new SearchVenueByCategoryResult();

            try
            {
                if (input.category.Length < 3)
                {
                    result.result = new BaseResult
                    {
                        isSuccesful = false,
                        resultMessage = "Kategori en az 3 harf olmalıdır"
                    };

                    return result;
                }               
                Core srv = new Core();
                var data = srv.SearchVenues(input).Select(a => a.name).ToList();
                result.venueList = data;
                result.result = new BaseResult
                {
                    isSuccesful = true
                };
                return result;
            }
            catch(Exception ex)
            {
                result.result = new BaseResult
                {
                    isSuccesful = false,
                    resultMessage = ex.Message
                };
                return result;
            }

        }


        public SearchVenueByNameResult SearchVenueByName(VenueSearch input)
        {
            SearchVenueByNameResult result = new SearchVenueByNameResult();
            try
            {
                Core srv = new Core();
                var data = srv.SearchVenue(input);
                result.venueDetail = data;
                result.result = new BaseResult
                {
                    isSuccesful = true
                };
                return result;
            }
            catch(Exception ex)
            {
                result.result = new BaseResult
                {
                    isSuccesful = false,
                    resultMessage = ex.Message
                };
                return result;
            }
        }
    }
}
