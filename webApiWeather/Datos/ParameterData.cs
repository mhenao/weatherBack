using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webApiWeather.Datos
{
    public class ParameterData
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public bool Output { get; set; }

        public ParameterData(string name, object value)
        {
            Name = name;
            Value = value;
            Output = false;
        }

        public ParameterData(string name)
        {
            Name = name;
            Output = true;
        }

    }
}