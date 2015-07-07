using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
    class Repository
    {
        /// <summary>
        /// Initializes a new instance of the Repository class
        /// </summary>
        /// 
        public Repository()
        {
            _matchList = new BindingList<Match>();
        }

        private BindingList<Match> _matchList;

        /// <summary>
        /// Gets matchlist
        /// </summary>
        public BindingList<Match> MatchList
        {
            get { return _matchList; }
            set { _matchList = value; }
        }

        private string _pathToFile;

        /// <summary>
        /// Gets path of the opened file
        /// </summary>
        public string PathToFile
        {
            get { return _pathToFile; }
            set { _pathToFile = value; }
        }

        /// <summary>
        /// Cleans all data from repository
        /// </summary>
        public void Clean()
        {
            _matchList = new BindingList<Match>();
            PathToFile = null;
        }

        /// <summary>
        /// Reads match list from xml file
        /// </summary>
        /// <param name="fStream">Stream to the file</param>
        /// <returns>Return value indicates whether file reading succeeded</returns>
        public bool ReadFromXml(FileStream fStream)
        {
            _pathToFile = fStream.Name;
            FileProcessor fileProcessor = new FileProcessor(fStream);
            _matchList = fileProcessor.ReadXmlFile();
            return (_matchList != null) ? true : false;
        }

        /// <summary>
        /// Gets maximum math id in the match list
        /// </summary>
        /// <returns>Maximum id</returns>
        public int ReturnMaxId()
        {
            int max = 0;
            foreach (Match match in _matchList)
            {
                if ((match.Id) > max)
                {
                    max = match.Id;
                }
            }
            return max;
        }

        /// <summary>
        /// Writes matchlist to the xml file
        /// </summary>
        /// <returns>Return value indicates whether file writing succeeded</returns>
        public bool WriteToXml()
        {
            if (!String.IsNullOrEmpty(_pathToFile))
            {
                FileProcessor fileProcessor = new FileProcessor(_pathToFile);
                return fileProcessor.WriteXmlFile(_matchList);
            }
            return false;
        }

        /// <summary>
        /// Writes matchlist to the xml file
        /// </summary>
        /// <param name="fStream">Stream to the file</param>
        /// <returns>Return value indicates whether file writing succeeded</returns>
        public bool WriteToXml(FileStream fStream)
        {
            _pathToFile = fStream.Name;
            FileProcessor fileProcessor = new FileProcessor(fStream);
            return fileProcessor.WriteXmlFile(_matchList);
        }
    }
}
