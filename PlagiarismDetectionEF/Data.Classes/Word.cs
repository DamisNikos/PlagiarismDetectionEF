using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlagiarismDetectionEF.Data.Classes
{
    class Word
    {
        public int wordID { get; set; }
        public string word { get; set; }

        [ForeignKey("document")]
        public int documentID { get; set; }
        public Document document { get; set; }
    }
}
