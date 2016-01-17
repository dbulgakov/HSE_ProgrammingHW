using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Microsoft.Win32;
using System.Windows;
using System.ComponentModel;

namespace HomeWork2
{
    class FileProcessor
    {
        /// <summary>
        /// Initializes a new instance of the FileProcessor class
        /// </summary>
        /// <param name="fStream">Stream to the file</param>
        public FileProcessor(FileStream fStream)
        {
            _dataContract = new DataContractSerializer(typeof(BindingList<Match>));
            _fileStream = fStream;
        }
        /// <summary>
        /// Initializes a new instance of the FileProcessor class
        /// </summary>
        /// <param name="pathToFile">Full path to the file</param>
        public FileProcessor(string pathToFile)
        {
            _dataContract = new DataContractSerializer(typeof(BindingList<Match>));
            _fileStream = new FileStream(pathToFile, FileMode.OpenOrCreate);
        }

        private DataContractSerializer _dataContract;
        private FileStream _fileStream;

        /// <summary>
        /// Reads list of matches from the xml file
        /// </summary>
        /// <returns>List of matches</returns>
        public BindingList<Match> ReadXmlFile()
        {
            BindingList<Match> listFromFile = null;
            using (_fileStream)
            {
                if (_fileStream != null)
                {
                    try
                    {
                        listFromFile = (BindingList<Match>)_dataContract.ReadObject(_fileStream);
                    }
                    catch 
                    {
                        MessageBox.Show("Невозможно произвести чтение из файла!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            return listFromFile;            
        }

        /// <summary>
        /// Writes match list to the xml file
        /// </summary>
        /// <param name="matchList">List of matches</param>
        /// <returns>Return value indicates whether file writing succeeded</returns>
        public bool WriteXmlFile(BindingList<Match> matchList)
        {
            using (_fileStream)
            {
                if (_fileStream != null)
                {
                    try
                    {
                        _dataContract.WriteObject(_fileStream, matchList);
                        return true;
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно произвести запись в файл!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                return false;
            }
        }
    }
}
