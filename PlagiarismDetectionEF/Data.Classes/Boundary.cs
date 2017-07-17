using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlagiarismDetectionEF.Data.Classes
{
    class Boundary
    {

        public int lower { get; set; }
        public int upper { get; set; }

        [Key, ForeignKey("stopNgram")]
        public int stopNgramID { get; set; }
        public StopNgram stopNgram { get; set; }
    }
}
    