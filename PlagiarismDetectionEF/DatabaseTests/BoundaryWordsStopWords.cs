using PlagiarismDetectionEF.Core;
using PlagiarismDetectionEF.Data.Classes;
using PlagiarismDetectionEF.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace PlagiarismDetectionEF.DatabaseTests
{
    class BoundaryWordsStopWords
    {
        public static void RunTestWrite() {
            Boundary boundary = new Boundary() { lower = 0, upper = 3 };
            string input = @"Files\Paper\original1.pdf";

            ListOfWords words = new ListOfWords();



            using (var context = new DocumentContext())
            {
                context.Database.Log = Console.WriteLine;

                context.ListOfWords.Add(words);
                words.listOfWords = DocumentParser.GetText(input);


                List<StopWord> listofStopWords = ProfileStopWordBuilder.GetStopWordPresentation(words.listOfWords);
                ProfileStopWord profile = new ProfileStopWord();
                profile = ProfileStopWordBuilder.GetProfileStopWord(listofStopWords, 11, canditateOrboundary.Canditate);


                context.StopNGrams.Add(profile.ngrams[0]);



                context.SaveChanges();
            }

            //using (var context = new DocumentContext())
            //{
            //    context.Database.Log = Console.WriteLine;
            //    var wordsList = context.StopNGrams
            //                            .Select(n => new { n.stopWords, n.boundary })
            //                            .ToList();

            //    var wordsList1 = context.ListOfWords
            //                            .Select(n => new { n.listOfWords })
            //                            .ToList();
            //}
        }


    }
}
