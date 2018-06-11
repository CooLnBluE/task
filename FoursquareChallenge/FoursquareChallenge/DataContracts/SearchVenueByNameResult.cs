using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FoursquareChallenge.DataContracts
{
    [DataContract]
    public class SearchVenueByNameResult
    {
        [DataMember]
        public BaseResult result { get; set; }
        [DataMember]
        public VenueDTO venueDetail { get; set; }
    }

    [DataContract]
    public class VenueDTO: EntityDTO
    {
        [DataMember]
        public string id
        {
            get;
            set;
        }

        [DataMember]
        public string name
        {
            get;
            set;
        }


        [DataMember]
        public LocationDTO location
        {
            get;
            set;
        }


        [DataMember]
        public bool verified
        {
            get;
            set;
        }




        [DataMember]
        public string description
        {
            get;
            set;
        }

        [DataMember]
        public Int64 createdAt
        {
            get;
            set;
        }


        [DataMember]
        public string shortUrl
        {
            get;
            set;
        }

        [DataMember]
        public string canonicalUrl
        {
            get;
            set;
        }



        [DataMember]
        public string timeZone
        {
            get;
            set;
        }
        [DataMember]
        public double rating
        {
            get;
            set;
        }

      
    }

    [DataContract]
    public class LocationDTO : EntityDTO
    {
        [DataMember]
        public string address
        {
            get;
            set;
        }
        [DataMember]
        public string crossStreet
        {
            get;
            set;
        }

        [DataMember]
        public string city
        {
            get;
            set;
        }
        [DataMember]
        public string state
        {
            get;
            set;
        }
        [DataMember]
        public string postalCode
        {
            get;
            set;
        }
        [DataMember]
        public string country
        {
            get;
            set;
        }
        [DataMember]
        public double lat
        {
            get;
            set;
        }
        [DataMember]
        public double lng
        {
            get;
            set;
        }
        [DataMember]
        public int distance
        {
            get;
            set;
        }
        [DataMember]
        public string cc
        {
            get;
            set;
        }
        [DataMember]
        public string[] formattedAddress
        {
            get;
            set;
        }
    }

    [DataContract]
    public abstract class EntityDTO
    {

    }
}