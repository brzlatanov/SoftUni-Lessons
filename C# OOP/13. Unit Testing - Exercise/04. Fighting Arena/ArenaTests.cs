using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Tests
{
    public class ArenaTests
    {
        public Arena arena;
        [SetUp]
        public void Setup()
        {
            arena = new Arena();
        }

        [Test]
        public void Ctor_InitializationShouldCreateAWarriorList()
        {
            Assert.That(arena.Warriors != null);
            Assert.That(arena.Warriors.Count == 0);
            Assert.That(arena.Warriors.GetType().Name == "List`1");
        }
        [Test]
        public void Ctor_InitializationShouldInitializeObject()
        {
            Assert.That(arena != null);
        }

        [Test]
        public void AddingWarriorsToArenaIncreasesCount()
        {
            int n = 3;

            for (int i = 0; i < n; i++)
            {
                arena.Enroll(new Warrior($"{i}", i+1, i));
            }

            Assert.That(arena.Count == n);
            Assert.That(arena.Warriors.FirstOrDefault(w => w.Name == "0") != null);
        }

        [Test]
        public void AddingWarriorsWithSameNameShouldThrowException()
        {
            Warrior achilles = new Warrior("Achilles", 100, 200);
            Warrior achilles2 = new Warrior("Achilles", 150, 250);
            arena.Enroll(achilles);

            Assert.Throws<InvalidOperationException>(() => arena.Enroll(achilles2));
        }
        [Test]
        [TestCase("Paris", "Menelaus")]
        public void AttackingWhenEitherAttackerOrDefenderIsNullShouldThrowException(string invalidAttacker, string invalidDefender)
        {
            Warrior achilles = new Warrior("Achilles", 100, 200);
            Warrior hector = new Warrior("Hector", 150, 250);
            arena.Enroll(achilles);
            arena.Enroll(hector);
            Assert.Throws<InvalidOperationException>(() => arena.Fight($"{invalidAttacker}", "Hector"),
                $"There is no fighter with name {invalidAttacker} enrolled for the fights!");
            Assert.Throws<InvalidOperationException>(() => arena.Fight("Achilles", $"{invalidDefender}"),
                $"There is no fighter with name {invalidDefender} enrolled for the fights!");
            Assert.Throws<InvalidOperationException>(() => arena.Fight($"{invalidAttacker}", $"{invalidDefender}"),
                $"There is no fighter with name {invalidDefender} enrolled for the fights!");

        }
        [Test]
        public void AttackingWithValidAttackerAndDefenderShouldExecuteProperly()
        {
            Warrior achilles = new Warrior("Achilles", 100, 200);
            Warrior hector = new Warrior("Hector", 150, 250);
            arena.Enroll(achilles);
            arena.Enroll(hector);
            arena.Fight("Hector", "Achilles");
            Assert.That(achilles.HP == 50);

        }
    }
}
