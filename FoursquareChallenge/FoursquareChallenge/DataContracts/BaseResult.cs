using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FoursquareChallenge.DataContracts
{

    [DataContract]
    public class BaseResult
    {
        [DataMember]
        public bool isSuccesful { get; set; }
        [DataMember]
        public string resultMessage { get; set; }
    }
}