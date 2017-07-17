using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlagiarismDetectionEF.Data.Classes
{
    class StopNgram
    {
        public int StopNgramID { get; set; }

        [Required]
        public List<StopWord> stopWords { get; set; }

        [Required]
        public Boundary boundary { get; set; }

        //public int profileStopWordID { get; set; }
        //public ProfileStopWord profileStopWord { get; set; }


    }
}
