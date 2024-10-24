using Project1.API.Model;

namespace Project1.API.Service;

public interface ICreatureService
{
    IEnumerable<Creature> GetBestiary();
}