using FluentAssertions;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System;
using TechTalk.SpecFlow;
using WeatherForecast.Helpers;
using WeatherForecast.Models;

namespace WeatherForecast
{
    [Binding]
    public class WeatherForecastApiSteps
    {
        public dynamic jsonResponse;
        Dictionary<string, long> DailyTemperature = new Dictionary<string, long>();
        Dictionary<string, long> PreferredDate = new Dictionary<string, long>();
        JSONHelper jsonHelper = new JSONHelper();

        [Given(@"I like to holiday in Sydney")]
        public void GivenILikeToHolidayInSydney()
        {
            RestHelper.SetUrl();
        }

        [When(@"I look up the weather forecast at '(.*)' in '(.*)'")]
        public void WhenILookUpTheWeatherForecastAtIn(string holidayLocation, string countryCode)
        {
            RestHelper.CreateRequest($"{holidayLocation},{countryCode}");
        }

        [Then(@"I receive the weather forecast")]
        public void ThenIReceiveTheWeatherForecast()
        {
            var apiResponse = RestHelper.GetResponse();

            apiResponse.StatusCode.Equals(HttpStatusCode.OK).Should().BeTrue("Api Response status code is not 200 OK");
            jsonResponse = JsonConvert.DeserializeObject(apiResponse.Content);
            string cityReturned = jsonResponse.city.name;
            cityReturned.Equals("Sydney").Should().BeTrue("Weather forecast for Sydney is not returned");
            var jsonResponseDetails = JsonConvert.DeserializeObject<WeatherApiResponseModel>(apiResponse.Content);

            foreach(var items in jsonResponseDetails.list)
            {
                DailyTemperature.Add(items.dt_txt, items.main.temp);
            }
        }

        [Then(@"I only like to holiday on '(.*)'")]
        public void ThenIOnlyLikeToHolidayOn(string preferredDay)
        {
            PreferredDate = jsonHelper.FindPreferredDay(DailyTemperature, preferredDay);
        }

        [Then(@"the temperature is warmer than '(.*)' degrees")]
        public void ThenTheTemperatureIsWarmerThanDegrees(int p0)
        {
            foreach(var item in PreferredDate)
            {
                if (item.Value > 10)
                {
                    System.Console.WriteLine($"Best early date for holiday is {item.Key.Substring(0,10)} and temperature is {item.Value}");
                    break;
                }
            }
        }
    }
}
