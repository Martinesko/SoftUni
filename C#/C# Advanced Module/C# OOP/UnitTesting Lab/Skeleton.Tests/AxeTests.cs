using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void LoosesDurabilityAfterAttack()
        {
            Axe axe = new Axe(1, 10);
            Dummy dummy = new Dummy(10, 10);
            axe.Attack(dummy);
            Assert.That(axe.DurabilityPoints == 9);
        }
        [Test]
        public void attackingWithABrokenAxe()
        {
            Assert.That(() =>
            {
                Axe axe = new Axe(1, 2);
                Dummy dummy = new Dummy(10, 1);
                axe.Attack(dummy);
                axe.Attack(dummy);
                axe.Attack(dummy);
            }, 
            Throws.Exception.TypeOf<InvalidOperationException>(), "Can't attack with broken axe" );
        }
    }
}