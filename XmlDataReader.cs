using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SeleniumNUnitExample;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace SeleniumNUnitExample
    {
        public class XmlDataReader
        {
            public static IEnumerable<TestData> ReadTestData(string filePath)
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException($"The file {filePath} does not exist");
                }
                var serializer = new XmlSerializer(typeof(List<TestData>), new XmlRootAttribute("TestCases"));
                using (var reader = new StreamReader(filePath))
                {
                    return (List<TestData>)serializer.Deserialize(reader);
                }
            }
        }

        public class TestData
        {
            public string SearchTerm { get; set; }
        }
    }

