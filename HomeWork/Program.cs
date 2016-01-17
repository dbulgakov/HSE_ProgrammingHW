using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Выполнил студент группы #175
Булгаков Дмитрий
Вариант #6
Задание: 
Дан текстовый файл с несколькими предложениями. Предложения заканчиваются
точкой. Слова в предложения отделяются друг от друга пробелами и запятыми. 
Последовательно скопировать в выходной файл самые короткие слова в каждом предложении.
*/
namespace HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "КДЗ Булгаков Дмитрий БМ175";
            string myDocumentsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string answer;
            do
            {
                string allTextFromFile = FileManager.ReadFromFile(myDocumentsDirectory);
                if (allTextFromFile.Length > 0)
                {
                    if (!ProcessData.CheckText(allTextFromFile))
                    {
                        Console.WriteLine("Текст в исходном файле отформатирован неверно.");
                    }
                    String[] sentencesArray = allTextFromFile.Split(new String[] { ".", "!", "?", "!?", "?!" }, StringSplitOptions.None);
                    List<string> listOfShortesWords = ProcessData.FindShortestWord(sentencesArray);
                    FileManager.WriteToFile(myDocumentsDirectory, "result.txt", listOfShortesWords);
                    Console.WriteLine("Результат записан в файл result.txt.");
                }
                else
                {
                    Console.WriteLine("Исходный файл пуст!");
                }
                Console.Write("Повторить выполнение программы?(Y/N): ");
                answer = Console.ReadLine();
            }
            while (answer.Equals("Y") || answer.Equals("y"));

            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
