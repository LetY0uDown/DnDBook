using DnDBook.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Xamarin.Forms;

namespace DnDBook.Core.Database
{
    public class DatabaseContext : DbContext
    {
        const string PATH = "database.db";

        public DatabaseContext()
        {
            try
            {
                Database.EnsureCreated();
            }
            catch (Exception e)
            {
                 App.Current.MainPage.DisplayAlert("error", e.Message, "ok");
            }
        }

        public DbSet<Character> Characters { get; set; }
        public DbSet<Spell> Spells { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string filePath = DependencyService.Get<IDBPathBuilder>().BuiltPath(PATH);
            optionsBuilder.UseSqlite($"DataSource={filePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>().HasMany(c => c.Spells);

            base.OnModelCreating(modelBuilder);
        }
    }
}