using System;
using System.Text;
using System.IO;
using Toxy;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using PlagiarismDetectionEF.Data.Classes;

namespace PlagiarismDetectionEF.Core
{
    class DocumentParser
    {
        public static List<Word> GetText(string path)
        {
            string text = null;
            string extension = Path.GetExtension(path);
            try
            {
                ParserContext context = new ParserContext(path);
                if (extension.Equals(".txt"))
                {
                    ITextParser parser = ParserFactory.CreateText(context);
                    text = parser.Parse().ToString().ToLower().Replace('\n', ' ').Replace('\r', ' ')
                .Replace('\t', ' ');
                }
                else if (extension.Equals(".pdf") || extension.Equals(".docx") || extension.Equals(".doc"))
                {
                    IDocumentParser parser = ParserFactory.CreateDocument(context);
                    text = parser.Parse().ToString().ToLower().Replace('\n', ' ').Replace('\r', ' ')
                .Replace('\t', ' ');
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception found at GetText()");
                Debug.WriteLine(e.Message);
            }
            text = RemovePunctuation(text);
            string[] words = text.Split(default(Char[]), StringSplitOptions.RemoveEmptyEntries);

            List<Word> listOfWords = new List<Word>();
            foreach (string word in words)
            {
                listOfWords.Add(new Word() { word = word });
            }
            return listOfWords;
        }

        //Removes punctuation
        private static string RemovePunctuation(string s)
        {
            var sb = new StringBuilder();

            foreach (char c in s)
            {
                if (!char.IsPunctuation(c))
                    sb.Append(c);
            }

            s = sb.ToString();
            return s;
        }

    }

}
