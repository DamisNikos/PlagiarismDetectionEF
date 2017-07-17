using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlagiarismDetectionEF.Data.Classes
{
    class ProfileStopWord
    {
        public int ProfileStopWordID { get; set; }
        public canditateOrboundary profileType { get; set; }

        [Required]
        public List<StopNgram> ngrams { get; set; }

        public int documentID { get; set; }

        public Document document { get; set; }

    }
}
