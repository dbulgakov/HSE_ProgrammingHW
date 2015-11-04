using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentRating.Classes.Interfaces;
using System.IO;
using System.Xml.Serialization;
using StudentRating.Classes.Domain;

namespace StudentRating.Classes.DataProcessors
{
    public class XmlFileProcessor : IDataProcessor
    {
        private XmlSerializer _xmlSerializer;
        private FileStream _fileStream;

        public XmlFileProcessor(string pathToFile)
        {
            _xmlSerializer = new XmlSerializer(typeof(List<Grade>));
            _fileStream = new FileStream(pathToFile, FileMode.OpenOrCreate);
        }

        public void Write(List<Grade> data)
        {
            using (_fileStream)
            {
                _xmlSerializer.Serialize(_fileStream, data);
            }
        }

        public List<Grade> Read()
        {
            List<Grade> data = null;
            using (_fileStream)
            {
                data = (List<Grade>)_xmlSerializer.Deserialize(_fileStream);
            }
            return data;
        }
    }
}
