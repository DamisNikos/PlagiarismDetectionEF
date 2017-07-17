namespace PlagiarismDetectionEF.Data.Classes
{
    class StopWord
    {
 
        public int stopWordID { get; set; }
        public int index { get; set; }
        public string word { get; set; }

        public int stopNgramID { get; set; }
        public StopNgram stopNgram { get; set; }
    }
}
