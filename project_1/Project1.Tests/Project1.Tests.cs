using Moq;
using Project1.API.Model;
using Project1.API.Repository;
using Project1.API.Service;

namespace Project1.TESTS;

public class BestiaryTests
{
    [Fact]
    public void GetBestiaryTest()
    {
        //Arrange
        Mock<ICreatureRepository> mockRepo = new();
        CreatureService creatureService = new(mockRepo.Object);

        List<Creature> bestiary = [
            new Creature{ID = 1, Name = "Mr. X", Weight=250.0d, Height=6.0d, Blurb = "He's big and heavy!"},
            new Creature{ID = 2, Name = "Mr. Y", Weight=75.0d, Height=4.5d, Blurb = "He's small and mean!"},
            new Creature{ID = 3, Name = "Mr. Z", Weight=125.0d, Height=6.5d, Blurb = "He's tall and crafty!"}
        ];

        mockRepo.Setup(repo => repo.GetBestiary()).Returns(bestiary);

        //Act
        var returnedList = creatureService.GetBestiary();

        //Assert
        Assert.NotEmpty(returnedList);
        Assert.Equal(3, returnedList.Count());
        Assert.Contains(returnedList, creature => creature.Name.Equals("Mr. X"));
    }

    [Fact]
    public void GetCreatureTest()
    {
        //Arrange
        Mock<ICreatureRepository> mockRepo = new();
        CreatureService creatureService = new(mockRepo.Object);

        List<Creature> bestiary = [
            new Creature{ID = 1, Name = "Mr. X", Weight=250.0d, Height=6.0d, Blurb = "He's big and heavy!"},
            new Creature{ID = 2, Name = "Mr. Y", Weight=75.0d, Height=4.5d, Blurb = "He's small and mean!"},
            new Creature{ID = 3, Name = "Mr. Z", Weight=125.0d, Height=6.5d, Blurb = "He's tall and crafty!"}
        ];

        mockRepo.Setup(repo => repo.GetCreature("Mr. X")).Returns(bestiary.Find(c => c.Name.Equals("Mr. X"))!);
        mockRepo.Setup(repo => repo.GetCreature("mR. Y")).Returns(bestiary.Find(c => c.Name.Equals("Mr. Y"))!);
        mockRepo.Setup(repo => repo.GetCreature("3")).Returns(bestiary.Find(c => c.Name.Equals("Mr. Z"))!);

        //Act
        var mrX = creatureService.GetCreature("Mr. X");
        var mrY = creatureService.GetCreature("mR. Y");
        var mrZ = creatureService.GetCreature("3");

        //Assert
        Assert.Equal("Mr. X", mrX.Name);
        Assert.Equal("Mr. Y", mrY.Name);
        Assert.Equal("Mr. Z", mrZ.Name);
    }

    [Fact]
    public void DeleteCreatureTest()
    {
        //Arrange
        Mock<ICreatureRepository> mockRepo = new();
        CreatureService creatureService = new(mockRepo.Object);

        List<Creature> bestiary = [
            new Creature{ID = 1, Name = "Mr. X", Weight=250.0d, Height=6.0d, Blurb = "He's big and heavy!"},
            new Creature{ID = 2, Name = "Mr. Y", Weight=75.0d, Height=4.5d, Blurb = "He's small and mean!"},
            new Creature{ID = 3, Name = "Mr. Z", Weight=125.0d, Height=6.5d, Blurb = "He's tall and crafty!"}
        ];
        mockRepo.Setup(repo => repo.DeleteCreature("Mr. X")).Returns(bestiary.Find(c => c.Name.Equals("Mr. X"))!);
        mockRepo.Setup(repo => repo.DeleteCreature("3")).Returns(bestiary.Find(c => c.Name.Equals("Mr. Z"))!);

        //Act
        var mrX = creatureService.DeleteCreature("Mr. X");
        bestiary.RemoveAt(0);
        var length1 = bestiary.Count();
        var mrZ = creatureService.DeleteCreature("3");
        bestiary.RemoveAt(1);
        var length2 = bestiary.Count();

        //Assert
        Assert.Equal("Mr. X", mrX.Name);
        Assert.Equal(2, length1);
        Assert.Equal("Mr. Z", mrZ.Name);
        Assert.Equal(1, length2);
    }

    [Fact]
    public void DuplicateCreatureTest()
    {
        //Arrange
        Mock<ICreatureRepository> mockRepo = new();
        CreatureService creatureService = new(mockRepo.Object);

        List<Creature> bestiary = [
            new Creature{ID = 1, Name = "Mr. X", Weight=250.0d, Height=6.0d, Blurb = "He's big and heavy!"},
            new Creature{ID = 2, Name = "Mr. Y", Weight=75.0d, Height=4.5d, Blurb = "He's small and mean!"},
            new Creature{ID = 3, Name = "Mr. Z", Weight=125.0d, Height=6.5d, Blurb = "He's tall and crafty!"}
        ];
        mockRepo.Setup(repo => repo.DuplicateCreature("Mr. X")).Returns(bestiary.Find(c => c.Name.Equals("Mr. X"))!);
        mockRepo.Setup(repo => repo.DuplicateCreature("3")).Returns(bestiary.Find(c => c.Name.Equals("Mr. Z"))!);

        //Act
        var mrX = creatureService.DuplicateCreature("Mr. X");
        bestiary.Add(mrX);
        var length1 = bestiary.Count();
        var mrZ = creatureService.DuplicateCreature("3");
        bestiary.Add(mrZ);
        var length2 = bestiary.Count();

        //Assert
        Assert.Equal("Mr. X", mrX.Name);
        Assert.Equal(4, length1);
        Assert.Equal("Mr. Z", mrZ.Name);
        Assert.Equal(5, length2);
    }

    [Fact]
    public void AddNewCreatureTest()
    {
        //Arrange
        Mock<ICreatureRepository> mockRepo = new();
        CreatureService creatureService = new(mockRepo.Object);

        List<Creature> bestiary = [
            new Creature{ID = 1, Name = "Mr. X", Weight=250.0d, Height=6.0d, Blurb = "He's big and heavy!"},
            new Creature{ID = 2, Name = "Mr. Y", Weight=75.0d, Height=4.5d, Blurb = "He's small and mean!"},
            new Creature{ID = 3, Name = "Mr. Z", Weight=125.0d, Height=6.5d, Blurb = "He's tall and crafty!"}
        ];

        Creature mrV = new Creature{ID = 4, Name = "Mr. V", Weight=150.0d, Height=7.0d, Blurb="What the heck is this guy doing here?"};
        Creature mrW = new Creature{ID = 5, Name = "Mr. W", Weight=999.0d, Height=999.0d, Blurb="Oh no..."};

        mockRepo.Setup(repo => repo.AddNewCreature("Mr. V", "What the heck is this guy doing here?", 150.0d, 7.0d)).Returns(mrV);
        mockRepo.Setup(repo => repo.AddNewCreature("Mr. W", "Oh no...", 999.0d, 999.0d)).Returns(mrW);

        //Act
        var mrVNew = creatureService.AddNewCreature("Mr. V", "What the heck is this guy doing here?", 150.0d, 7.0d);
        bestiary.Add(mrVNew);
        var mrWNew = creatureService.AddNewCreature("Mr. W", "Oh no...", 999.0d, 999.0d);
        bestiary.Add(mrWNew);

        //Assert
        Assert.Equal(5, bestiary.Count());
        Assert.Equal("Mr. V", mrVNew.Name);
        Assert.Equal("Mr. W", mrWNew.Name);
    }
}