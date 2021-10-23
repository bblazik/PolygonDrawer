using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using TemplateSolution.Converters;
using TemplateSolution.Data.Models;

namespace TemplateSolution.Data.DataReaders
{
    public class JsonDataReader : IDataReader
    {
        public string Path { get; private set; }

        public JsonDataReader(string path)
        {
            Path = path;
        }

        public List<Primitive> Read()
        {
            try
            {
                //It load data into memory. In case of large files it might be changed to streams;
                var content = File.ReadAllText(Path);
                var primitives = JsonConvert.DeserializeObject<List<Primitive>>(content, new CustomPrimitiveItemConverter());
                return primitives;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw e;
            }
        }
    }
}
