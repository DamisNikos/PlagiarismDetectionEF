using PlagiarismDetectionEF.Data.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlagiarismDetectionEF.Core
{
    class ProfileStopWordBuilder
    {
        //Step-1
        //1.Get the normalized(all lowercase, no punctuation) text presentation
        //2.Create the stopNword presentation
        //3.Return the stopNword presentation
        public static List<StopWord> GetStopWordPresentation(List<Word> docWords)
        {
            List<Word> top50words = DocumentParser.GetText(@"Files\\Top50UsedWords.docx");

            List<StopWord> StopWordPresentation = new List<StopWord>();

            //iterate through all document's words in text presentation
            for (int i = 0; i < docWords.Count; i++)
            {
                foreach (Word commonWord in top50words)
                {
                    //if match is found add this word in the stopNword presentation
                    if (docWords[i].word.Equals(commonWord.word))
                    {
                        StopWordPresentation.Add(new StopWord() { index = i, word = docWords[i].word });
                    }
                }
            }
            return StopWordPresentation;
        }


        //Step-2
        //1.Get the stopNword presentation
        //2.Calculate the size of nGram presentation
        //3.Create the document's profile in n-gram stopNword        
        public static ProfileStopWord GetProfileStopWord(List<StopWord> swPresentation, int nGramSize, canditateOrboundary type)
        {
            //calculate the size of nGram presentation
            int targetIndex = swPresentation.Count + 1 - nGramSize;
            List<StopNgram> docProfile = new List<StopNgram>();
            //iterate through each n-gram
            for (int i = 0; i < targetIndex; i++)
            {
                StopNgram ngram = new StopNgram() {stopWords = new List<StopWord>() };
                
                //add words to each n-gram
                for (int j = 0; j < nGramSize; j++)
                {
                    ngram.stopWords.Add(swPresentation[i + j]);
                }
                //calculate the first and last index (in document's words) of the ngram
                Boundary boundary = new Boundary()
                {
                    lower = ngram.stopWords[0].index,
                    upper = ngram.stopWords[nGramSize - 1].index
                };
                ngram.boundary = boundary;
                //add current n-gram to the profile
                ngram.stopWords = ngram.stopWords.ToList(); 
                docProfile.Add(ngram);
            }
            ProfileStopWord profile = new ProfileStopWord() {profileType= type, ngrams=docProfile.ToList()}; 
            return profile;
        }
        
    }
}
