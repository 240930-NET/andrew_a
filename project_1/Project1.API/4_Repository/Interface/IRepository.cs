using Project1.API.Model;

namespace Project1.API.Repository;

public interface ICreatureRepository
{
    IEnumerable<Creature> GetBestiary();
    Creature GetCreatureByID(int id);
    Creature GetCreatureByName(string name);
    Creature GetCreature(string s);
    Creature AddNewCreature(string name, string blurb, double weight, double height);
    Creature DuplicateCreature(string id);
    Creature DeleteCreature(string id);
}