using System;
using NUnit.Framework;

namespace Tests
{
    public class WarriorTests
    {
        private Warrior testWarrior;
        private Warrior hector;

        [SetUp]
        public void Setup()
        {
            testWarrior = new Warrior("Achilles", 100, 200);
        }

        [Test]
        public void Ctor_ShouldInitializeInstanceWithProperValues()
        {
            Assert.That(testWarrior.Name == "Achilles");
            Assert.That(testWarrior.Damage == 100);
            Assert.That(testWarrior.HP == 200);
        }
        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("         ")]
        [TestCase(null)]
        public void NameSetterShouldSetNameFieldCorrectly(string name)
        {
            Assert.Throws<ArgumentException>(() => testWarrior = new Warrior(name, 100, 200));
        }
        [Test]
        [TestCase(0)]
        [TestCase(-54)]
        public void DamageSetterShouldSetDamageFieldCorrectly(int damage)
        {
            Assert.Throws<ArgumentException>(() => testWarrior = new Warrior("Achilles", damage, 200));
        }
        [Test]
        [TestCase(-1)]
        public void HPSetterShouldSetHPFieldCorrectly(int hp)
        {
            Assert.Throws<ArgumentException>(() => testWarrior = new Warrior("Achilles", 100, hp));
        }
        [Test]
        //[TestCase(30)]
        [TestCase(29)]
        public void AttackingWhenTooLowOnHPShouldThrowException(int hp)
        {
            hector = new Warrior("Hector", 100, 200);
            testWarrior = new Warrior("Achilles", 100, hp);
            Assert.Throws<InvalidOperationException>(() => testWarrior.Attack(hector), "Your HP is too low in order to attack other warriors!");
        }
        [Test]
        //[TestCase(30)]
        [TestCase(29)]
        public void AttackingWhenEnemyTooLowOnHPShouldThrowException(int hp)
        {
            hector = new Warrior("Hector", 100, hp);
            testWarrior = new Warrior("Achilles", 100, 200);
            Assert.Throws<InvalidOperationException>(() => testWarrior.Attack(hector), $"Enemy HP must be greater than 30 in order to attack him!");
        }
        [Test]
        public void AttackingWhenObjectHPIsLowerThanArgumentDamageShouldThrowException()
        {
            hector = new Warrior("Hector", 100, 200);
            testWarrior = new Warrior("Achilles", 100, 99);
            Assert.Throws<InvalidOperationException>(() => testWarrior.Attack(hector), $"You are trying to attack too strong enemy");
        }
        [Test]
        public void AttackingWarriorShouldReduceObjectHpForBoth()
        {
            hector = new Warrior("Hector", 100, 200);
            testWarrior = new Warrior("Achilles", 100, 200);
            testWarrior.Attack(hector);
            Assert.That(testWarrior.HP == 100);
            Assert.That(hector.HP == 100);
        }
        [Test]
        public void AttackingWarriorWithObjectAttackMoreThanWarriorHpShouldReduceWarriorHpToZero()
        {
            hector = new Warrior("Hector", 100, 200);
            testWarrior = new Warrior("Achilles", 201, 200);
            testWarrior.Attack(hector);
            Assert.That(hector.HP == 0);
            Assert.That(testWarrior.HP == 100);
        }
        [Test] 
        public void AttackingWarriorShouldReduceWarriorHp()
        {
            hector = new Warrior("Hector", 100, 200);
            testWarrior = new Warrior("Achilles", 150, 200);
            testWarrior.Attack(hector);
            Assert.That(hector.HP == 50);
        }
        [Test]
        public void AttackingWarriorWithSameAttackAsWarriorHPShouldMakeItZero()
        {
            hector = new Warrior("Hector", 100, 200);
            testWarrior = new Warrior("Achilles", 200, 200);
            testWarrior.Attack(hector);
            Assert.That(hector.HP == 0);
        }
    }
}