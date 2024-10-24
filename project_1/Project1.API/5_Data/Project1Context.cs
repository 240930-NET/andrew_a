using Microsoft.EntityFrameworkCore;
using Project1.API.Model;

namespace Project1.API.Data;

public partial class Project1Context : DbContext {
    public Project1Context(){}
    public Project1Context(DbContextOptions<Project1Context> options) : base(options){}

    public virtual DbSet<Creature> Bestiary {get; set;}
}