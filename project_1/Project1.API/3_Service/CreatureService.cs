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
}