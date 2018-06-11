using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FoursquareChallenge.DataContracts
{

    [DataContract]
    public class VenueSearchCategory
    {
        [DataMember]
        public string category { get; set; }

        [DataMember]
        public Location location { get; set; }
    }
}