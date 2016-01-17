using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2
{
    class DialogProcessor
    {
        private const string DialogFilterString = "Файлы xml (*.xml)|*.xml|Все файлы (*.*)|*.*";
        private FileDialog _fileDialog;

        /// <summary>
        /// Runs new openfile dialog
        /// </summary>
        /// <returns>Stream to the file</returns>
        public Stream CreateOpenFileDialog()
        {
            _fileDialog = new OpenFileDialog();
            InitializeDialog();
            Stream streamToFile = CreateStream();
            return streamToFile;
        }

        /// <summary>
        /// Runs new save as dialog
        /// </summary>
        /// <returns>Stream to the file</returns>
        public Stream CreateSaveAsDialog()
        {
            _fileDialog = new SaveFileDialog();
            InitializeDialog();
            Stream streamToFile = CreateStream();
            return streamToFile;
        }

        /// <summary>
        /// Creates stream to the file by showing the dialog
        /// </summary>
        /// <returns>Stream to the file</returns>
        private Stream CreateStream()
        {
            if (_fileDialog.ShowDialog() == true)
            {
                if (_fileDialog is OpenFileDialog)
                {
                    return ((OpenFileDialog)_fileDialog).OpenFile();
                }
                return ((SaveFileDialog)_fileDialog).OpenFile();
            }
            return null;
        }

        /// <summary>
        /// Initializes dialog with basic settings
        /// </summary>
        private void InitializeDialog()
        {
            _fileDialog.Filter = DialogFilterString;
            _fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }
    }
}
