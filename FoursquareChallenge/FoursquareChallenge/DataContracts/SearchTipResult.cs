using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FoursquareChallenge.DataContracts
{
    [DataContract]
    public class SearchTipResult
    {
        [DataMember]
        public BaseResult result { get; set; }
        [DataMember]
        public List<string> tipsList { get; set; }
    }
}