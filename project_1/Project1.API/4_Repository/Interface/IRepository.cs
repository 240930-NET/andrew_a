using Project1.API.Model;

namespace Project1.API.Repository;

public interface ICreatureRepository
{
    IEnumerable<Creature> GetBestiary();
}