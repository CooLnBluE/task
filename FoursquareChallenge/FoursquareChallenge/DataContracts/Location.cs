using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FoursquareChallenge.DataContracts
{
    [DataContract]
    public class Location
    {
        public string latLong
        {
            get
            {
                return latitude + "," + longtitude;
            }
        }
        [DataMember]
        public string latitude { get; set; }

        [DataMember]
        public string longtitude { get; set; }

        [DataMember]
        public string near { get; set; }
    }
}
