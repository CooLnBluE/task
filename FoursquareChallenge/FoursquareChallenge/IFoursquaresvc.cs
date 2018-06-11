using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using Entities;
using FoursquareChallenge.DataContracts;

namespace FoursquareChallenge
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFoursquaresvc" in both code and config file together.
    [ServiceContract]
    public interface IFoursquaresvc
    {
        [OperationContract]
        SearchVenueByCategoryResult SearchVenueByCategory(VenueSearchCategory input);
        [OperationContract]
        SearchVenueByNameResult SearchVenueByName(VenueSearch input);
        [OperationContract]
        SearchTipResult SearchTip(TipSearch input);
    }
}




 
