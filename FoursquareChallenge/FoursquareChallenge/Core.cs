using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoursquareBusiness;
using FoursquareChallenge.DataContracts;
using AutoMapper;

namespace FoursquareChallenge
{
    public class Core
    {
        private const string clientId = "VSXIJTTIL3NUA0ZHCG1PZI35EZPOIQVKFXM3M1ZSAMT2RKDD";
        private const string clientSecret = "DZ2VUKTV1LSAV5F40NF4CIPBAUH1VH4UYAJ1QMRXQI2444TW";

        public List<Venue> SearchVenues(VenueSearchCategory input)
        {
            List<Venue> result = new List<Venue>();
            FoursquareBusiness.Service srv = new FoursquareBusiness.Service(clientId, clientSecret);
            List<Parameter> parameters = new List<Parameter>();

            if(!string.IsNullOrEmpty(input.category))
            {
                var categoryList = srv.GetVenueCategories();
                string categoryId = "";
                foreach (var item in categoryList)
                {
                    foreach(var detailedItem in item.categories)
                    {
                        if(detailedItem.name.Contains(input.category))
                            categoryId += item.id + ",";
                    }                   
                }               
                parameters.Add(new Parameter
                {
                    KeyName = "categoryId",
                    KeyValue = categoryId.Remove(categoryId.Length - 1)
                });
            }

            if (!string.IsNullOrEmpty(input.location.near))
            {
                parameters.Add(new Parameter
                {
                    KeyName = "near",
                    KeyValue = input.location.near
                });
            }
            else
            {
                if (!string.IsNullOrEmpty(input.location.latitude) && !string.IsNullOrEmpty(input.location.longtitude))
                {
                    parameters.Add(new Parameter
                    {
                        KeyName = "ll",
                        KeyValue = input.location.latitude.Replace(',', '.') + "," + input.location.longtitude.Replace(',', '.')
                    });
                }
            }
            result = srv.SearchVenues(parameters);
            return result;
        }

      

        public List<Tip> SearchTip(TipSearch input)
        {
            List<Parameter> parameters = new List<Parameter>();

            if (!string.IsNullOrEmpty(input.location.near))
            {
                parameters.Add(new Parameter
                {
                    KeyName = "near",
                    KeyValue = input.location.near
                });
            }
            else
            {
                if (!string.IsNullOrEmpty(input.location.latitude) && !string.IsNullOrEmpty(input.location.longtitude))
                {
                    parameters.Add(new Parameter
                    {
                        KeyName = "ll",
                        KeyValue = input.location.latitude.Replace(',', '.') + "," + input.location.longtitude.Replace(',', '.')
                    });
                }
            }
            if(!string.IsNullOrEmpty(input.name))
            {
                parameters.Add(new Parameter
                {
                    KeyName = "query",
                    KeyValue = input.name
                });
            }
            FoursquareBusiness.Service srv = new FoursquareBusiness.Service(clientId, clientSecret);
            var venueList = srv.SearchVenues(parameters);
            //var venueDetail = srv.GetVenue(venueList.Where(a => a.name == input.name).FirstOrDefault().id));
            var tips = srv.GetVenueTips(venueList.FirstOrDefault().id, null);
            return tips;
        }


        public Venue  SearchVenueByName(VenueSearch input)
        {
            List<Parameter> parameters = new List<Parameter>();

            if (!string.IsNullOrEmpty(input.location.near))
            {
                parameters.Add(new Parameter
                {
                    KeyName = "near",
                    KeyValue = input.location.near
                });
            }
            else
            {
                if (!string.IsNullOrEmpty(input.location.latitude) && !string.IsNullOrEmpty(input.location.longtitude))
                {
                    parameters.Add(new Parameter
                    {
                        KeyName = "ll",
                        KeyValue = input.location.latitude.Replace(',', '.') + "," + input.location.longtitude.Replace(',', '.')
                    });
                }
            }
            if (!string.IsNullOrEmpty(input.name))
            {
                parameters.Add(new Parameter
                {
                    KeyName = "query",
                    KeyValue = input.name
                });
            }
            FoursquareBusiness.Service srv = new FoursquareBusiness.Service(clientId, clientSecret);
            var venueData = srv.SearchVenues(parameters).FirstOrDefault();

            return venueData;
        }



        public VenueDTO SearchVenue(VenueSearch input)
        {
            var venueData = SearchVenueByName(input);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Entity, EntityDTO>();
                cfg.CreateMap<Entities.Location, LocationDTO>();
                cfg.CreateMap<Venue, VenueDTO>();
            });

            IMapper mapper = config.CreateMapper();
            var result = new VenueDTO();
            result = mapper.Map<Venue, VenueDTO>(venueData);          
            return result;
        }

    }
}