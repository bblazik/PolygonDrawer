using System.Collections.Generic;

namespace TemplateSolution.Data.DataReaders
{
    public interface IDataReader
    {
        List<Models.Primitive> Read();
    }
}
