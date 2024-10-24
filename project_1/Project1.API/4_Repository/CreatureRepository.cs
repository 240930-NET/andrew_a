using Project1.API.Data;
using Project1.API.Model;

namespace Project1.API.Repository;

public class CreatureRepository : ICreatureRepository
{
    private readonly Project1Context _p1Context;

    public CreatureRepository(Project1Context p1Context) => _p1Context = p1Context;

    public IEnumerable<Creature> GetBestiary()
    {
        return _p1Context.Bestiary.ToList();
    }
}