using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    class ProcessData
    {
        /// <summary>
        /// Finds the shortest word in a list of sentences
        /// </summary>
        /// <param name="sentencesArray">List of sentences to find the shortest word in</param>
        /// <returns>List of the shortest words</returns>
        public static List<string> FindShortestWord(string[] sentencesArray)
        {
            List<string> listOfShortesWords = new List<string>();
            for (int i = 0; i < sentencesArray.Length; i++)
            {
                if (!String.IsNullOrWhiteSpace(sentencesArray[i]))
                {
                    string min = FindShortestWord(sentencesArray[i]);
                    listOfShortesWords.Add(min);
                }
            }
            return listOfShortesWords;
        }

        /// <summary>
        /// Finds the shortest word in a sentence
        /// </summary>
        /// <param name="sentence">Sentence to find the shortest word in</param>
        /// <returns>Shortest word</returns>
        public static string FindShortestWord(string sentence)
        {
            string shortestWord = null;
            sentence = sentence.Trim();
            string[] words = sentence.Split(new char[] {' ', ',', ':', '-'});
            shortestWord = words[0].Trim();
            for (int i = 0; i < words.Length; i++)
            {
                string tmp = words[i].Trim();
                if ((shortestWord.Length > tmp.Length) && (!String.IsNullOrEmpty(tmp)))
                {
                    shortestWord = tmp;
                }
            }
            return shortestWord;
        }
        /// <summary>
        /// Checks whether file formated correctly
        /// </summary>
        /// <param name="text">Text to check</param>
        /// <returns>True if file formated correctly, false otherwise</returns>
        public static bool CheckText(string text)
        {
            if (!text.Contains('.') && (!text.Contains('!')) && (!text.Contains('?')) && (!text.Contains("?!")) && (!text.Contains("!?")))
            {
                return false;
            }
            return true;
        }
    }
}
