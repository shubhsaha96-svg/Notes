using System.ComponentModel.DataAnnotations;

namespace Notes.Models
{
    public class Note
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string NotesTitle { get; set; }


        [Required]
        [DataType(DataType.MultilineText)]
        public string NotesContent { get; set; }
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
    }
}
