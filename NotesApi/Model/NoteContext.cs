using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesApi.Model
{
    public class NoteContext : DbContext
    {
        public NoteContext(DbContextOptions<NoteContext> dbContextOptions):base(dbContextOptions) 
        {

        }

        public DbSet<Note> Notes { get; set; }
    }
}
