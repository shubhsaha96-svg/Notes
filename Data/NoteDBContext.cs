using Microsoft.EntityFrameworkCore;

namespace Notes.Data
{
    public class NoteDBContext: DbContext
    {
        public NoteDBContext(DbContextOptions<NoteDBContext> options) : base(options)
        {
        }
        public DbSet<Notes.Models.Note> Notes { get; set; }
    }
}
