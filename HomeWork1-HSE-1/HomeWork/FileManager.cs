using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    class FileManager
    {
        /// <summary>
        /// Opens file and writes text into it
        /// </summary>
        /// <param name="path">Path, where file is located</param>
        /// <param name="filename">Name of the file to open</param>
        /// <param name="textToWrite">Text to write to the file</param>
        /// <returns></returns>
        public static bool WriteToFile(string path, string filename, List<String> textToWrite)
        {
            String fPath = path + "\\" + filename;
            StreamWriter writer = null;

            if (CreateOutputStream(path, filename, ref writer))
            {
                foreach (String element in textToWrite)
                {
                    writer.WriteLine(element);
                }
                writer.Close();
                return true;
            }
            writer.Close();
            return false;
        }

        /// <summary>
        /// Opens text file and gets its contents
        /// </summary>
        /// <param name="path">Path, where file is located</param>
        /// <returns>All text from file</returns>
        public static string ReadFromFile(string path)
        {
            StreamReader fReader = null;
            bool streamCreated = false;
            do
            {
                String filename = GetInputFilename(path);
                streamCreated = CreateInputStream(path, filename, ref fReader);
            }
            while (!streamCreated);
            string textFromFile = ReadAllLinesFromFile(fReader);
            fReader.Close();
            return textFromFile;
        }
        /// <summary>
        /// Reads all lines from the file 
        /// </summary>
        /// <param name="fReader"><Text input stream</param>
        /// <returns>Text string</returns>
        public static string ReadAllLinesFromFile(StreamReader fReader)
        {
            StringBuilder stringLines = new StringBuilder();
            while (!fReader.EndOfStream)
            {
                stringLines.Append(ReadLineFromFile(fReader));
            }
            return stringLines.ToString();
        }

        /// <summary>
        /// Reads one line from the file 
        /// </summary>
        /// <param name="fReader">Text input stream</param>
        /// <returns>Text string</returns>
        public static string ReadLineFromFile(StreamReader fReader)
        {
            try
            {
                return fReader.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка при чтении файла!\nКод ошибки: {0}", e.Message);
                return null;
            }
        }
        /// <summary>
        /// Creates text file output stream
        /// </summary>
        /// <param name="path">Path, where file is located</param>
        /// <param name="filename">Name of the file to open</param>
        /// <param name="fWriter">Text output stream</param>
        /// <returns>True if stream created successfully and false otherwise</returns>
        public static bool CreateOutputStream(string path, string filename, ref StreamWriter fWriter)
        {
            string fPath = path + "\\" + filename;
            try
            {
                fWriter = new StreamWriter(fPath);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка при записи файла!\nКод ошибки: {0}", e.Message);
                return false;
            }
        }

        /// <summary>
        /// Creates text file input stream
        /// </summary>
        /// <param name="path">Path, where file is located</param>
        /// <param name="filename">Name of the file to open</param>
        /// <param name="fReader">Text input stream</param>
        /// <returns>True if stream created successfully and false otherwise</returns>
        public static bool CreateInputStream(string path, string filename, ref StreamReader fReader)
        {
            string fullPathToFile = path + "\\" + filename;
            try
            {
                fReader = new StreamReader(fullPathToFile, System.Text.Encoding.Default);
                return true;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл не найден! Повторите попытку!");
                System.Threading.Thread.Sleep(1500);
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Неизвестная ошибка!\nКод ошибки: {0}", e.Message);
                System.Threading.Thread.Sleep(1500);
                return false;
            }
        }
        /// <summary>
        /// Asks user to input the filename in selected directory
        /// </summary>
        /// <param name="path">Path, where files are located</param>
        /// <returns>Filename input by user</returns>
        public static string GetInputFilename(string path)
        {
            Console.Clear();
            Console.WriteLine("Введите имя исходного файла \nФайл должен располагаться каталоге {0}\n", path);
            Console.WriteLine("Список текстовых документов в данном каталоге: ");

            string[] filesList = Directory.GetFiles(path, "*.txt");

            PrintFileList(filesList, path);

            Console.Write("\nИмя файла: ");
            string filename = Console.ReadLine();
            return filename;
        }
        /// <summary>
        /// Prints to console list of files in a directory
        /// </summary>
        /// <param name="filesList">Array with filenames</param>
        public static void PrintFileList(string[] filesList)
        {
            if (filesList.Length != 0)
            {
                foreach (string filename in filesList)
                {
                    Console.WriteLine(filename);
                }
            }
            else
            {
                Console.WriteLine("Файлы не найдены!");
            }
        }
        /// <summary>
        /// Prints to console list of files in a directory
        /// </summary>
        /// <param name="filesList">Array with filenames</param>
        /// <param name="path">Path where files are located</param>
        public static void PrintFileList(string[] filesList, string path)
        {
            if (filesList.Length != 0)
            {
                foreach (string filename in filesList)
                {
                    Console.WriteLine(filename.Remove(0, (path.Length + 1)));
                }
            }
            else
            {
                Console.WriteLine("Файлы не найдены!");
            }
        }
    }
}
