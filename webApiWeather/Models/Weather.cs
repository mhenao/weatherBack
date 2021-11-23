using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webApiWeather.Datos;

namespace webApiWeather.Models
{
    public class Weather
    {
        public int q_id { get; set; }
        public string city_name { get; set; }
        public string city_info { get; set; }
        public DateTime created_at { get; set; }

        public static ResponseData Add(Weather weather)
        {
            List<ParameterData> parametersData = new List<ParameterData>
        {
            new ParameterData("@city_name",weather.city_name),
            new ParameterData("@city_info",weather.city_info),
            new ParameterData("@created_at",weather.created_at)
        };
            return DBdata.Ejecutar("Queryi_add", parametersData);
        }

    }

   
}