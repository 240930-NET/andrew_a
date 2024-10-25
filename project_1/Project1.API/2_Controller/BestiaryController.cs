using Microsoft.AspNetCore.Mvc;
using Project1.API.Service;
using Project1.API.Model;

namespace Project1.API.Controller;

[Route("api/[controller]")]
[ApiController]
public class BestiaryController : ControllerBase
{
    private readonly ICreatureService _creatureService;

    public BestiaryController(ICreatureService creatureService) => _creatureService = creatureService;

    private string WriteCreatureName(Creature creature) {
        if (creature.Singleton) {
            return creature.Name;
        } else {
            return "The "+creature.Name;
        }
    }

    private string WriteCreatureBlurb(Creature creature) {
        return WriteCreatureName(creature)+". "+creature.Blurb;
    }

    private string WriteCreatureHeight(Creature creature, bool includeName = false) {
        if (includeName) {
            return WriteCreatureName(creature)+" is "+creature.Height+" feet tall.";
        } else {
            return "Height: "+creature.Height+" feet.";
        }
    }

    private string WriteCreatureWeight(Creature creature, bool includeName = false) {
        if (includeName) {
            return WriteCreatureName(creature)+" weighs "+creature.Weight+" pounds.";
        } else {
            return "Weight: "+creature.Weight+ " pounds.";
        }
    }

    private string WriteCreatureFullInfo(Creature creature) {
        return WriteCreatureBlurb(creature)+"\n"+WriteCreatureHeight(creature)+"\n"+WriteCreatureWeight(creature);
    }

    [HttpGet("/bestiary")]
    public IActionResult GetBestiary()
    {
        IEnumerable<Creature> bestiary = _creatureService.GetBestiary();
        return Ok(bestiary);
    }

    [HttpGet("/bestiary/{id}")]
    public IActionResult GetCreature(string id)
    {
        Creature creature = _creatureService.GetCreature(id);
        return Ok(creature);
    }

    [HttpGet("/bestiary/{id}/blurb")]
    public IActionResult GetCreatureBlurb(string id)
    {   
        Creature creature = _creatureService.GetCreature(id);
        string blurb = WriteCreatureBlurb(creature);
        return Ok(blurb);
    }

    [HttpGet("/bestiary/{id}/height")]
    public IActionResult GetCreatureHeight(string id)
    {   
        Creature creature = _creatureService.GetCreature(id);
        string height = WriteCreatureHeight(creature, true);
        return Ok(height);
    }

    [HttpGet("/bestiary/{id}/weight")]
    public IActionResult GetCreatureWeight(string id)
    {   
        Creature creature = _creatureService.GetCreature(id);
        string weight = WriteCreatureWeight(creature, true);
        return Ok(weight);
    }

    [HttpGet("/bestiary/{id}/fullinfo")]
    public IActionResult GetCreatureFullInfo(string id)
    {   
        Creature creature = _creatureService.GetCreature(id);
        string fullinfo = WriteCreatureFullInfo(creature);
        return Ok(fullinfo);
    }

    [HttpPost("/bestiary/edit/add/{name}@{blurb}@{height}@{weight}")]
    public IActionResult AddNewCreature(string name, string blurb, double weight, double height)
    {   
        Creature creature = _creatureService.AddNewCreature(name, blurb, weight, height);
        return Ok(creature);
    }

    [HttpPost("/bestiary/edit/duplicate/{id}")]
    public IActionResult DuplicateCreature(string id)
    {   
        Creature creature = _creatureService.DuplicateCreature(id);
        return Ok(creature);
    }

    [HttpDelete("/bestiary/edit/delete/{id}")]
    public IActionResult DeleteCreature(string id)
    {   
        Creature creature = _creatureService.DeleteCreature(id);
        return Ok(creature);
    }
}