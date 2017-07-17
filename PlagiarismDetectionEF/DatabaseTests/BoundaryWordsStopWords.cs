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

            Document doc1 = ConverterToByteArray.FileToByteArray(input);
         

            ListOfWords words = new ListOfWords();
            words.listOfWords = DocumentParser.GetText(input);

            doc1.words = words;

            List<StopWord> listofStopWords = ProfileStopWordBuilder.GetStopWordPresentation(words.listOfWords);
            ProfileStopWord profile = new ProfileStopWord();
            profile = ProfileStopWordBuilder.GetProfileStopWord(listofStopWords, 11, canditateOrboundary.Canditate);


            doc1.profiles.Add(profile);

            //using (var context = new DocumentContext())
            //{
            //    context.Database.Log = Console.WriteLine;

            //    context.ListOfWords.Add(doc1.words);
            //    context.Profiles.Add(doc1.profiles[0]);

            //    foreach (StopNgram ngram in doc1.profiles[0].ngrams)
            //    {
            //        context.StopNGrams.Add(ngram);

            //    }

            //    context.Documents.Add(doc1);


            //    context.SaveChanges();
            //}

            using (var context = new DocumentContext())
            {
                context.Database.Log = Console.WriteLine;
                var wordsList = context.StopNGrams
                                        .Select(n => new { n.stopWordsInString, n.boundary })
                                        .ToList();

                var document = context.Documents
                                        .Select(n => new { n.name, n.context, n.profiles, n.words.listOfWords })
                                        .ToList();
                var document1 = context.Documents
                                       .Include(n=>n.words)  
                                       .Include(n=>n.profiles.Select(x=>x.ngrams))
                    .ToList();


            }
        }


    }
}
