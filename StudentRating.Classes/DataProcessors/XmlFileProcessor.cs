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
        private string _pathToFile;

        public XmlFileProcessor(string pathToFile)
        {
            _xmlSerializer = new XmlSerializer(typeof(List<Grade>));
            _pathToFile = pathToFile;
        }

        public void Write(List<Grade> data)
        {
            FileStream fileStream = new FileStream(_pathToFile, FileMode.Create);
            using (fileStream)
            {
                _xmlSerializer.Serialize(fileStream, data);
            }
        }

        public List<Grade> Read()
        {
            FileStream fileStream = new FileStream(_pathToFile, FileMode.OpenOrCreate);
            List<Grade> data = null;
            using (fileStream)
            {
                data = (List<Grade>)_xmlSerializer.Deserialize(fileStream);
            }
            return data;
        }
    }
}
