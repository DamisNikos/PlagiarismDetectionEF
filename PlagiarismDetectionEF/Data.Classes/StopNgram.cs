using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlagiarismDetectionEF.Data.Classes
{
    class StopNgram
    {
        public int StopNgramID { get; set; }

        [Required]
        public string stopWordsInString { get; set; }
        [NotMapped]
        public List<StopWord> stopWords { get; set; }
        [Required]
        public Boundary boundary { get; set; }

        [ForeignKey("profileStopWord")]
        public int profileStopWordID { get; set; }
        public ProfileStopWord profileStopWord { get; set; }



        
    }
}
