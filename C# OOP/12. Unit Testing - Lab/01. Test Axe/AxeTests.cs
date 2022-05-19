using System;
using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void AxeLosesDurabilityAfterAttack()
        {
            Axe axe = new Axe(5, 10);
            Dummy dummy = new Dummy(10, 5);
            axe.Attack(dummy);
            Assert.That(axe.DurabilityPoints == 9);
        }
        [Test]
        public void AttackingWithBrokenWeaponShouldThrowException()
        {
            Axe axe = new Axe(5, 0);
            Dummy dummy = new Dummy(10, 5);
            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
        }
    }
}