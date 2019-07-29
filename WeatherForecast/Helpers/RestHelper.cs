using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace WeatherForecast.Helpers
{
    public class RestHelper
    {
        public static RestClient client;
        public static RestRequest restRequest;
        public static string baseUrl = "https://api.openweathermap.org/data/2.5/forecast";

        public static RestClient SetUrl()
        {
            return client = new RestClient(baseUrl);
        }

        public static RestRequest CreateRequest(string queryParameter)
        {
            restRequest = new RestRequest(Method.GET);
            restRequest.AddQueryParameter("q", queryParameter);
            restRequest.AddQueryParameter("appid", ConfigurationManager.AppSettings["ApiKey"]);
            restRequest.AddQueryParameter("units", "metric");

            return restRequest;
        }

        public static IRestResponse GetResponse()
        {
            return client.Execute(restRequest);
        }

    }
}
