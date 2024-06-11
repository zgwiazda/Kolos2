using APBD_kolos.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_kolos.Data;

public class DatabaseContext : DbContext
{
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Backpack> Backpacks { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<Character_title> CharacterTitles { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Title> Titles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Backpack>().HasData(new List<Backpack>
        {
            new Backpack
            {
                CharacterId = 1,
                ItemId = 1,
                Amount = 12
            },
            new Backpack
            {
                CharacterId = 2,
                ItemId = 2,
                Amount = 13
            }

        });
        modelBuilder.Entity<Character>().HasData(new List<Character>
        {
            new Character
            {
                Id = 1,
                FirstName = "Jan",
                LasttName = "Kowalski",
                CurrentWeight = 78,
                MaxWeight = 100
            },
            new Character
            {
                Id = 2,
                FirstName = "Ola",
                LasttName = "Nowak",
                CurrentWeight = 44,
                MaxWeight = 90
            },
        });
        
        modelBuilder.Entity<Character_title>().HasData(new List<Character_title>
        {
            new Character_title
            {
                CharacterId = 1,
                TitleId = 1,
                AcquiredAt = DateTime.Parse("2020-02-02")
            },
            new Character_title
            {
                CharacterId = 2,
                TitleId = 2,
                AcquiredAt = DateTime.Parse("2022-02-02")

            },
        });
        
        modelBuilder.Entity<Title>().HasData(new List<Title>
        {
            new Title
            {
                Id = 1,
                Name = "Szef"
            },
            new Title
            {
                Id = 2,
                Name = "Parobek"

            },
        });
    }



}