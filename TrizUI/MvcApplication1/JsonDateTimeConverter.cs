using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace MvcApplication1
{
    /// <summary> 
    /// Json日期带T格式转换 
    /// </summary> 
    public class JsonDateTimeConverter : IsoDateTimeConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            DateTime dataTime;
            if (DateTime.TryParse(reader.Value.ToString(), out dataTime))
            {
                return dataTime;
            }
            else
            {
                return existingValue;
            }
        }

        public JsonDateTimeConverter()
        {
        }

    }
}