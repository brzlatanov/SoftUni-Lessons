using System;
using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Axe axe;
        private Dummy dummy;
        [SetUp]
        public void Initialize()
        {
            axe = new Axe(10, 20);
            dummy = new Dummy(20, 20);
        }
        [Test]
        public void Attack_DummyShouldLoseHp()
        {
            axe.Attack(dummy);
            Assert.That(dummy.Health == 10);
        }
        [Test]
        public void Attack_DeadDummyShouldThrowExceptionWhenAttacked()
        {
            dummy = new Dummy(0, 20);
            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
        }
        [Test]
        public void DeadDummyShouldGiveExperience()
        {
            dummy = new Dummy(0, 10);
            Assert.That(dummy.GiveExperience() == 10);
        }
        [Test]
        public void AliveDummyShouldNotGiveExperience()
        {
            dummy = new Dummy(11, 10);
            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
        }
    }
}