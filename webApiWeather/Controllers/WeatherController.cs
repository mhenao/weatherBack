using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using webApiWeather.Models;

namespace webApiWeather.Controllers
{
    [EnableCors(origins: "http://localhost:3000", headers:"*",methods:"*")]
    public class WeatherController : ApiController
    {
        //[Route("api/weather")]
        //[HttpGet]
        //public async string QueryWeather(string cityName)


        public async Task<object> QueryWeather(string cityNameNews)
        {
            try
            {
                var url = $"http://api.weatherapi.com/v1/current.json?key=63caf55239794a4c8c784050211111&q={cityNameNews}";
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(url);
                //HttpResponseMessage response = await httpClient.GetAsync(url);
                if (response != null)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(jsonString);
                    return JsonConvert.DeserializeObject<object>(jsonString);
                }
                else
                {
                    Object error = new
                    {
                        error = "API offSet"
                    };
                    return error;
                }
            }
            catch (Exception ex)
            {
                Object error = new
                {
                    error = ex
                };
                return error;
            }

        }


        public async Task<object> QueryNews(string cityNameNews)
        {
            try
            {
                var url = $"https://newsapi.org/v2/top-headlines/sources?city={cityNameNews}&apiKey=e3ee4e69cddd44f685c8984352b3f74e";
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(url);
                //HttpResponseMessage response = await httpClient.GetAsync(url);
                if (response != null)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<object>(jsonString);
                }
                else
                {
                    return await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                Object error = new
                {
                    error = ex
                };
                return  error;
            }

        }

        public async Task<object> QueryData(string cityNameNews)
        {
            // string[] dataResponse;
            object Weather = await this.QueryWeather(cityNameNews);
            object News = await this.QueryNews(cityNameNews);

            Object dataResponse = new
            {
                weather = Weather,
                news=News
            };
            return dataResponse;

        }


        [Route("api/querys")]
        [HttpPost]
        public async Task<object> Querys(Weather weather)
        {
            return await this.QueryData("BOG");

        }

        [Route("api/create")]
        [HttpPost]
        public async Task<object> Create(Weather weather)
        {
            Console.WriteLine("Hola soy la consola");
            Weather.Add(weather);
            return await this.QueryData(weather.city_name);
            
        }
    }
}