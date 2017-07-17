using PlagiarismDetectionEF.Data.Classes;
using System.Data.Entity;

namespace PlagiarismDetectionEF.Data.Model
{
    class DocumentContext : DbContext
    {
        //public DbSet<Document> Documents { get; set; }

        //public DbSet<ProfileStopWord> Profiles { get; set; }
        public DbSet<StopNgram> StopNGrams { get; set; }
        public DbSet<Word> Word { get; set; }

        public DbSet<StopWord> StopWords { get; set; }
        public DbSet<Boundary> Boundaries { get; set; }
        public DbSet<ListOfWords> ListOfWords { get; set; }

        public DocumentContext()
        : base("Data Source=172.26.165.171;Initial Catalog=DATABASE;Persist Security Info=True;User ID=sa;Password=Ceid@5202;MultipleActiveResultSets=True")
        {
        }
    }
}
