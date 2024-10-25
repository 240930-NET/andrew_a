using Project1.API.Model;
using Project1.API.Repository;

namespace Project1.API.Service;

public class CreatureService : ICreatureService
{
    private readonly ICreatureRepository _creatureRepository;

    public CreatureService(ICreatureRepository creatureRepository) => _creatureRepository = creatureRepository;

    public IEnumerable<Creature> GetBestiary()
    {
        return _creatureRepository.GetBestiary();
    }

    public Creature GetCreature(string id)
    {      
        return _creatureRepository.GetCreature(id);
    }

    public Creature AddNewCreature(string name, string blurb, double weight, double height)
    {      
        return _creatureRepository.AddNewCreature(name, blurb, weight, height);
    }

    public Creature DuplicateCreature(string id)
    {      
        return _creatureRepository.DuplicateCreature(id);
    }

    public Creature DeleteCreature(string id)
    {      
        return _creatureRepository.DeleteCreature(id);
    }
}