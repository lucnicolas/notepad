using System;
using Microsoft.EntityFrameworkCore;
using Notepad.Models;
using Path = System.IO.Path;

namespace Notepad.Data
{
    public class DataContext : DbContext
    {
        private static readonly string directory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        public DbSet<NoteModel> Notes { get; set; }

        public DataContext()
            :base()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string filePath = Path.Combine(directory, "Notepad.db3");
            optionsBuilder.UseSqlite($"filename={filePath}");
        }
    }
}