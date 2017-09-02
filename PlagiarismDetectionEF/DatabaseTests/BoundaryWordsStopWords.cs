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
            string input = @"Files\Paper\original1.pdf";

            Document doc1 = ConverterToByteArray.FileToByteArray(input);


            List<Word> words = new List<Word>();
            words = DocumentParser.GetText(input);

            doc1.words = words;

            List<StopWord> listofStopWords = ProfileStopWordBuilder.GetStopWordPresentation(words);
            ProfileStopWord profile = new ProfileStopWord();
            profile = ProfileStopWordBuilder.GetProfileStopWord(listofStopWords, 11, canditateOrboundary.Canditate);


            doc1.profiles.Add(profile);
            //                                     Inserting to database
            using (var context = new DocumentContext())
            {
                context.Database.Log = Console.WriteLine;

                context.Profiles.Add(doc1.profiles[0]);

                foreach (StopNgram ngram in doc1.profiles[0].ngrams)
                {
                    context.StopNGrams.Add(ngram);
                }
                foreach (Word word in doc1.words)
                {
                    context.Word.Add(word);
                }
                context.Documents.Add(doc1);

                context.SaveChanges();
            }
            //                                       Reading from database
            //using (var context = new DocumentContext())
            //{
            //    context.Database.Log = Console.WriteLine;

            //    var document = context.Documents
            //                            .Select(n => new { n.name, n.context, n.profiles, n.words })
            //                            .ToList();
            //    var document1 = context.Documents
            //                           .Include(n => n.words)
            //                           .Include(n => n.profiles.Select(x => x.ngrams))
            //        .ToList();
            //}
        }


    }
}
