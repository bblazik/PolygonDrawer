using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using TemplateSolution.Data.Models;

namespace TemplateSolution.Converters
{
    class CustomPrimitiveItemConverter : Newtonsoft.Json.Converters.CustomCreationConverter<Primitive>
    {
        public override Primitive Create(Type objectType)
        {
            throw new NotImplementedException();
        }

        public Primitive Create(Type objectType, JObject jObject)
        {
            var success = Enum.TryParse((string)jObject.Property("type"), true, out PrimitiveType type);
            if (!success)
            {
                throw new Exception($"Couldn't parse json object type properly {jObject}");
            }

            switch (type)
            {
                case PrimitiveType.Line:
                    return new Line();
                case PrimitiveType.Circle:
                    return new Circle();
                case PrimitiveType.Triangle:
                    return new Triangle();
                default:
                    throw new ApplicationException($"Type {type} is not supported!");
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jObject = JObject.Load(reader);
            var target = Create(objectType, jObject);
            serializer.Populate(jObject.CreateReader(), target);

            return target;
        }
    }
}
