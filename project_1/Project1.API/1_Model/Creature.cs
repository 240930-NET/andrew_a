using Microsoft.EntityFrameworkCore;

namespace Project1.API.Model;

public class Creature {
    public int ID {get; set;}
    public string Name {get; set;} = "Nameless";
    public double Height {get; set;} = -1.0;
    public double Weight {get; set;} = -1.0;
    public string Blurb {get; set;} = "There is no known info about this creature.";
    public bool Singleton {get; set;} = false;
    //public Biome Biome {get; set;}

    public Creature() {}
    protected Creature(Creature c){
        Name = c.Name;
        Height = c.Height;
        Weight = c.Weight;
        Blurb = c.Blurb;
        Singleton = c.Singleton;
    }

    public Creature Duplicate() {
        return new Creature(this);
    }
}