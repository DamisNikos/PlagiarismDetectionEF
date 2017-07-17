using System.IO;
using PlagiarismDetectionEF.Data.Classes;
using PlagiarismDetectionEF.Core;
using System.Collections.Generic;
using PlagiarismDetectionEF.Data.Model;
using System;
using PlagiarismDetectionEF.DatabaseTests;

namespace PlagiarismDetectionEF
{
    class Program
    {
        static void Main(string[] args)
        {


            BoundaryWordsStopWords.RunTestWrite();
            //string inputs = @"Files\Inputs\taskd";

            //string[] inputFiles = Directory.GetFiles(inputs, "*.pdf", SearchOption.AllDirectories);

            //int n1 = 11;
            //foreach (string inputFile in inputFiles)
            //{

            //    Document newDocument = ConverterToByteArray.FileToByteArray(inputFile);
            //    newDocument.words.listOfWords = DocumentParser.GetText(newDocument.name);

            //    List<StopWord> stopWords = ProfileStopWordBuilder.GetStopWordPresentation(newDocument.words.listOfWords);
            //    newDocument.profiles.Add(ProfileStopWordBuilder.GetProfileStopWord(stopWords,n1 ,canditateOrboundary.Canditate));

            //    //    using (var context = new DocumentContext())
            //    //    {
            //    //        context.Database.Log = Console.WriteLine;
            //    //        context.Documents.Add(newDocument);
            //    //        context.SaveChanges();
            //    //    }
            //}

        }
    }
}
