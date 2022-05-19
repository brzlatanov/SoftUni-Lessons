using System;
using System.Linq;
using NUnit.Framework;
[TestFixture]
public class HeroRepositoryTests
{
    public Hero hero;
    public Hero hero2;
    public HeroRepository heroRepository;
    [SetUp]
    public void Initialize_HeroAndRepository()
    {
        hero = new Hero("Achilles", 99);
        hero2 = new Hero("Hector", 50);
        heroRepository = new HeroRepository();
    }
    [Test]
    public void Hero_CtorMustInitializeNameFieldCorrectly()
    {
        Assert.That(hero.Name == "Achilles");
    }
    [Test]
    public void Hero_CtorMustInitializeHeroLevelCorrectly()
    {
        Assert.That(hero.Level == 99);
    }

    [Test]
    public void HeroRepository_CtorMustInitializeObject()
    {
        Assert.That(heroRepository.Heroes != null);
    }

    [Test]
    public void HeroRepository_CreatingNullHeroShouldThrowException()
    {
        Hero hero2 = null;
        Assert.Throws<ArgumentNullException>(() => heroRepository.Create(hero2), "Hero is null");
    }
    [Test]
    public void HeroRepository_CreatingExistingHeroShouldThrowException()//Indirectly tests Create method too
    {
        heroRepository.Create(hero);
        Hero hero2 = new Hero("Achilles", 100);
        Assert.Throws<InvalidOperationException>(() => heroRepository.Create(hero2), $"Hero with name {hero2.Name} already exists");
    }
    [Test]
    public void HeroRepository_CreateHeroShouldAddHeroToRepository()
    {
        heroRepository.Create(hero);
        Assert.That(heroRepository.Heroes.Contains(hero));
    }
    [Test]
    public void HeroRepository_GetHeroShouldReturnHero()
    {
        heroRepository.Create(hero);
        Hero heroResult = heroRepository.GetHero("Achilles");
        Assert.AreSame(heroResult, hero);
        Assert.That(heroRepository.Heroes.Contains(hero));
    }
    [Test]
    public void HeroRepository_CreateHeroShouldReturnTheProperMessage()
    {
        string result = heroRepository.Create(hero);
        Assert.That(result == $"Successfully added hero {hero.Name} with level {hero.Level}");
    }

    [Test]
    [TestCase("")]
    [TestCase(" ")]
    [TestCase(null)]
    public void HeroRepository_RemoveShouldThrowExceptionOnNullOrEmptySpaceArgument(string argument)
    {
        heroRepository.Create(hero);
        Assert.Throws<ArgumentNullException>(() => heroRepository.Remove(argument), "Name cannot be null");
    }

    [Test]
    public void HeroRepository_RemoveShouldRemoveTheRespectiveHeroAndReturnTrue()
    {
        heroRepository.Create(hero);
        heroRepository.Create(hero2);
        bool result = heroRepository.Remove("Hector");
        Assert.That(result == true);
    }
    [Test]
    public void HeroRepository_RemoveShouldReturnFalseIfHeroDoesNotExist()
    {
        heroRepository.Create(hero);
        heroRepository.Create(hero2);
        bool result = heroRepository.Remove("Paris");
        Assert.That(result == false);
    }
    [Test]
    public void HeroRepository_GetHighestLevelShouldReturnHighestLevelHero()
    {
        heroRepository.Create(hero2);
        heroRepository.Create(hero);
        Hero result = heroRepository.GetHeroWithHighestLevel();
        Assert.AreSame(result, hero);
    }
}