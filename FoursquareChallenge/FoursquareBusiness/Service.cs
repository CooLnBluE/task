using Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Entities.Response;


namespace FoursquareBusiness
{
    public class Service
    {
        private enum HttpMethod
        {
            GET,
            POST
        }
        private string clientId = null;
        private string clientSecret = null;
        private string accessToken = null;
        private string apiUrl = "https://api.foursquare.com/v2";
        private string apiVersion = "20160801";

        public Service(string clientId, string clientSecret)
        {
            this.clientId = clientId;
            this.clientSecret = clientSecret;
        }

        private string Request(string url, HttpMethod httpMethod)
        {
            return Request(url, httpMethod, null);
        }

        private string Request(string url, HttpMethod httpMethod, string data)
        {
            string result = string.Empty;
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = httpMethod.ToString();

            if (data != null)
            {
                byte[] bytes = UTF8Encoding.UTF8.GetBytes(data.ToString());
                httpWebRequest.ContentLength = bytes.Length;
                Stream stream = httpWebRequest.GetRequestStream();
                stream.Write(bytes, 0, bytes.Length);
                stream.Dispose();
            }
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            StreamReader reader = new StreamReader(httpWebResponse.GetResponseStream());
            result = reader.ReadToEnd();
            reader.Dispose();

            return result;
        }

        private string SerializeDictionary(List<Parameter> parameterList)
        {
            StringBuilder parameters = new StringBuilder();
            foreach (var parameter in parameterList)
            {
                parameters.Append(parameter.KeyName + "=" + parameter.KeyValue + "&");
            }
            return parameters.Remove(parameters.Length - 1, 1).ToString();
        }

        private FourSquareSingleResponse<T> GetSingle<T>(string endpoint, bool unauthenticated) where T : Entity
        {
            return GetSingle<T>(endpoint, null, unauthenticated);
        }

        private FourSquareSingleResponse<T> GetSingle<T>(string endpoint, List<Parameter> parameters, bool unauthenticated) where T : Entity
        {
            string serializedParameters = "";
            if (parameters != null)
            {
                serializedParameters = "&" + SerializeDictionary(parameters);
            }

            string oauthToken = "";
            if (unauthenticated)
            {
                oauthToken = string.Format("client_id={0}&client_secret={1}", clientId, clientSecret);
            }
            else
            {
                oauthToken = string.Format("oauth_token={0}", accessToken);
            }

            string json = Request(string.Format("{0}{1}?{2}{3}&v={4}", apiUrl, endpoint, oauthToken, serializedParameters, apiVersion), HttpMethod.GET);
            FourSquareSingleResponse<T> fourSquareResponse = JsonConvert.DeserializeObject<FourSquareSingleResponse<T>>(json);
            return fourSquareResponse;
        }

        private FourSquareMultipleVenuesResponse<T> GetMultipleVenues<T>(string endpoint, List<Parameter> parameters, bool unauthenticated) where T : Entity
        {
            string serializedParameters = "";
            if (parameters != null)
            {
                serializedParameters = "&" + SerializeDictionary(parameters);
            }

            string oauthToken = "";
            if (unauthenticated)
            {
                oauthToken = string.Format("client_id={0}&client_secret={1}", clientId, clientSecret);
            }
            else
            {
                oauthToken = string.Format("oauth_token={0}", accessToken);
            }

            string json = Request(string.Format("{0}{1}?{2}{3}&v={4}", apiUrl, endpoint, oauthToken, serializedParameters, apiVersion), HttpMethod.GET);
            var fourSquareResponse = JsonConvert.DeserializeObject<FourSquareMultipleVenuesResponse<T>>(json);
            return fourSquareResponse;
        }


     
        public Venue GetVenue(string venueId)
        {
            return GetSingle<Venue>("/venues/" + venueId, true).response["venue"];
        }

        public List<Venue> SearchVenues(List<Parameter> parameters)
        {
            return GetMultipleVenues<Venue>("/venues/search", parameters, true).response.venues;
        }

        public List<Tip> GetVenueTips(string venueId, List<Parameter> parameters)
        {
            EntityItems<Tip> tips = GetSingle<EntityItems<Tip>>("/venues/" + venueId + "/tips", parameters, true).response["tips"];
            return tips.items;
        }

        public List<Category> GetVenueCategories()
        {
            return GetMultiple<Category>("/venues/categories", true).response["categories"];
        }

        private FourSquareMultipleResponse<T> GetMultiple<T>(string endpoint, bool unauthenticated) where T : Entity
        {
            return GetMultipleDetail<T>(endpoint, unauthenticated);
        }
        private FourSquareMultipleResponse<T> GetMultipleDetail<T>(string endpoint, bool unauthenticated) where T : Entity
        { 
            string oauthToken = string.Format("client_id={0}&client_secret={1}", clientId, clientSecret);
            string json = Request(string.Format("{0}{1}?{2}&v={3}", apiUrl, endpoint, oauthToken, apiVersion), HttpMethod.GET);
            FourSquareMultipleResponse<T> fourSquareResponse = JsonConvert.DeserializeObject<FourSquareMultipleResponse<T>>(json);
            return fourSquareResponse;
        }

    }
}
