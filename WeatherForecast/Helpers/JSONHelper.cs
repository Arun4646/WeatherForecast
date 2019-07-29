using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecast.Helpers
{
    public class JSONHelper
    {
        Dictionary<string, long> preferredDates = new Dictionary<string, long>();

        public string DayCalculator(string date)
        {
            DateTime dateValue = Convert.ToDateTime(date);

            return dateValue.ToString("ddd");
        }

        public Dictionary<string, long> FindPreferredDay(Dictionary<string, long> AvailableDates, string preferredDay)
        {
            foreach(var item in AvailableDates)
            {
                string checkDay = DayCalculator(item.Key.Substring(0, 10));
                if (checkDay.Equals(preferredDay))
                {
                    preferredDates.Add(item.Key, item.Value);
                }
            }

            return preferredDates;
        }
    }
}
