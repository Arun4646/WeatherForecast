using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherForecast.Models
{
    public class WeatherApiResponseModel
    {
        public List<list> list { get; set; }
    }

    public class list
    {
        public string dt_txt { get; set; }
        public mains main { get; set; }
    } 

    public class mains
    {
        public long temp { get; set; }
    }
}
