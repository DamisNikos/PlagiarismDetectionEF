using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlagiarismDetectionEF.Data.Classes
{
    class ListOfWords
    {
        [Required]
        public List<Word> listOfWords { get; set; }

        [Key,ForeignKey("document")]
        public int documentID { get; set; }
        public Document document { get; set; }

        public ListOfWords() { listOfWords = new List<Word>(); }
    }
}
