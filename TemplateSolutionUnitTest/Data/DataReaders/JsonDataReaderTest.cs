using Microsoft.VisualStudio.TestTools.UnitTesting;
using TemplateSolution.Data.DataReaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateSolution.Data.DataReaders.Tests
{
    [TestClass()]
    public class JsonDataReaderTest
    {
        [TestMethod()]
        public void WhenReadCorrectInputDataThenDataNotNull()
        {
            var x = new JsonDataReader("..\\..\\Input.json").Read();
            Assert.IsNotNull(x);
        }

        [TestMethod()]
        public void WhenReadIncorrectDataThenThrowError()
        {
            Assert.ThrowsException<FormatException>(() => new JsonDataReader("..\\..\\InputErrors.json").Read());
        }
    }
}