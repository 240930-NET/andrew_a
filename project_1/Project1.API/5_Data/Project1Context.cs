using Microsoft.EntityFrameworkCore;
using Project1.API.Model;

namespace Project1.API.Data;

public partial class Project1Context : DbContext {
    public Project1Context(){}
    public Project1Context(DbContextOptions<Project1Context> options) : base(options){}

    public virtual DbSet<Creature> Bestiary {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Creature>().HasData(
            new Creature {ID = 1, Name = "Giant Scorpion", Height = 3.0, Weight = 70.0, Blurb = "A giant arthopod covered in heavy scales and venomous barbs."},
            new Creature {ID = 2, Name = "Cactorb", Height = 1.0, Weight = 20.0, Blurb = "A carnivorous spherical cactus who catches small insects by rolling over them."},
            new Creature {ID = 3, Name = "Locustus", Height = 6.0, Weight = 80.0, Blurb = "This mummified priest commands swarms of locusts to gather food and treasure to his tomb.", Singleton = true}
        );
    }
}