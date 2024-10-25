using Project1.API.Data;
using Project1.API.Model;
using Microsoft.EntityFrameworkCore;

namespace Project1.API.Repository;

public class CreatureRepository : ICreatureRepository
{
    private readonly Project1Context _p1Context;

    public CreatureRepository(Project1Context p1Context) => _p1Context = p1Context;

    public IEnumerable<Creature> GetBestiary()
    {
        return _p1Context.Bestiary.ToList();
    }

    public Creature GetCreature(string s)
    {      
        bool isIntID = int.TryParse(s, out int id);
        if (isIntID) {
            return GetCreatureByID(id);
        } else {
            return GetCreatureByName(s);
        }
    }

    public Creature GetCreatureByID(int id)
    {
        List<Creature> bestiary = GetBestiary().ToList();
        foreach (Creature creature in bestiary) {
            if (creature.ID == id) {
                return creature;
            }
        }
        throw new SystemException("Unable to find creature with ID: "+id);
    }

    public Creature GetCreatureByName(string name)
    {
        List<Creature> bestiary = GetBestiary().ToList();
        foreach (Creature creature in bestiary) {
            if (name.Equals(creature.Name, StringComparison.OrdinalIgnoreCase)) {
                return creature;
            }
        }
        throw new SystemException("Unable to find creature with Name: "+name);
    }

    public Creature AddNewCreature(string name, string blurb, double weight, double height)
    {      
        Creature newCreature = new Creature {
            Name = name,
            Blurb = blurb,
            Weight = weight,
            Height = height,
        };
        _p1Context.Bestiary.Add(newCreature);
        _p1Context.SaveChanges();
        return newCreature;
    }

    public Creature DuplicateCreature(string id)
    {      
        Creature creature = GetCreature(id);
        Creature newCreature = creature.Duplicate();
        _p1Context.Bestiary.Add(newCreature);
        _p1Context.SaveChanges();
        return newCreature;
    }

    public Creature DeleteCreature(string id)
    {      
        Creature creature = GetCreature(id);
        _p1Context.Bestiary.Remove(creature);
        _p1Context.SaveChanges();
        return creature;
    }
}