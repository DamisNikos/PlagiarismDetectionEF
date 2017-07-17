using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlagiarismDetectionEF.Data.Classes
{
    class Word
    {
        public int wordID { get; set; }
        public string word { get; set; }

        public int listOfWordsID { get; set; }
        public ListOfWords listOfWords { get; set; }
    }
}
