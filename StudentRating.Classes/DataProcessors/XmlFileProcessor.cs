using System.Collections.Generic;
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
        private FileStream _fStream;

        public FileStream Stream 
        {
            get { return _fStream; }
            set { _fStream = value; }
        }

        public XmlFileProcessor(string pathToFile)
        {
            _xmlSerializer = new XmlSerializer(typeof(List<Grade>));
            _pathToFile = pathToFile;
        }

        public void Write(List<Grade> data)
        {
            _fStream = new FileStream(_pathToFile, FileMode.Create);
            using (_fStream)
            {
                _xmlSerializer.Serialize(_fStream, data);
            }
        }

        public List<Grade> Read()
        {
            _fStream = new FileStream(_pathToFile, FileMode.OpenOrCreate);
            List<Grade> data;
            using (_fStream)
            {
                data = (List<Grade>)_xmlSerializer.Deserialize(_fStream);
            }
            return data;
        }
    }
}
