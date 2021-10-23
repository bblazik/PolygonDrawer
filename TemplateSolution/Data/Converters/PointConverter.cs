using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TemplateSolution.Converters
{
    public class PointConverter : JsonConverter
    {
        // Data should be designed differently. Like vortex array or st. e.g: "vortex": [...{2;3}]
        // It will be really hard to parse it effectivly in case of polygons. 
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
            ////TODO Add saving in same format. Not specified in specification - skiped 
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var values = ((string)reader.Value).Replace(',', '.').Split(';').Select(s => float.Parse(s)).ToList();
            var point = new Point(values[0], values[1]);

            return point;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Point);
        }
    }
}
