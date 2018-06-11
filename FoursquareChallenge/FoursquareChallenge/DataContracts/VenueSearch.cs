using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FoursquareChallenge.DataContracts
{
    [DataContract]
    public class VenueSearch
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public Location location { get; set; }

    }
}