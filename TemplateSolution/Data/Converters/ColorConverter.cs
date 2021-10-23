using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TemplateSolution.Converters
{
    public class ColorConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
            ////TODO Add saving in same format. Not specified in specification - skiped 
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            Color color = new Color();
            var floatColor = ((string)reader.Value).Split(';').Select(s => byte.Parse(s)).ToList();
            color = Color.FromArgb(floatColor[0], floatColor[1], floatColor[2], floatColor[3]);
            return color;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Color);
        }
    }
}
