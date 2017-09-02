using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlagiarismDetectionEF.Data.Classes
{
    class Document
    {
        public string name { get; set; }
        public int documentID { get; set; }
        public byte[] context { get; set; }

        [Required]
        public List<Word> words { get; set; }
        [Required]
        public List<ProfileStopWord> profiles { get; set; }

        public Document()
        {
            profiles = new List<ProfileStopWord>();
        }

    }
}
