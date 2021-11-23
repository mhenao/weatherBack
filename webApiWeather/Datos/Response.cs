using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webApiWeather.Datos
{
    public class ResponseData
    {
        public string status { get; set; }
        public bool exito { get; set; }
        public string message { get; set; }
        public dynamic result { get; set; }

        public ResponseData()
        {
            status = "success";
        }
    }
}