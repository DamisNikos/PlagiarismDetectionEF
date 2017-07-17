using System.Collections.Generic;

namespace PlagiarismDetectionEF.Data.Classes
{
    class Document
    {
        public string name { get; set; }
        public int documentID { get; set; }
        public byte[] context { get; set; }


        public ListOfWords words { get; set; }
        public List<ProfileStopWord> profiles { get; set; }

        public Document()
        {
            profiles = new List<ProfileStopWord>();
        }

    }
}
