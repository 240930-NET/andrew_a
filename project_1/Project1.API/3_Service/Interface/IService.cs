using Project1.API.Model;

namespace Project1.API.Service;

public interface ICreatureService
{
    IEnumerable<Creature> GetBestiary();
    Creature GetCreature(string id);
    Creature AddNewCreature(string name, string blurb, double weight, double height);
    Creature DuplicateCreature(string id);
    Creature DeleteCreature(string id);
}