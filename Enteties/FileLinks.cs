using System.ComponentModel.DataAnnotations.Schema;

namespace TestAppFile.Enteties
{
    public class FileLinks
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int ParentId { get; set; }
        public int childId { get; set; }
    }
}
