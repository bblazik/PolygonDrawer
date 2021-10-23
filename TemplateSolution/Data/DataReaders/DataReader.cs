using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateSolution.Data.DataReaders
{
    public static class DataReader
    {
        // Can be abstracted more with some configuration.
        public static List<Data.Models.Primitive> ReadData(IDataReader dataReader)
        {
            try
            {
                var data = dataReader.Read();
                return data;
            }
            catch (Exception e)
            {
                Trace.WriteLine($"There was an aerror during reading data. : {e.Message}"); // Any other logger here.
                throw e;
            }
        }
    }
}
