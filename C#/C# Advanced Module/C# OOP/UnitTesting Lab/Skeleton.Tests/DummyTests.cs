using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void DummyLosesHealthIfAttacked()
        {
            Dummy dummy = new Dummy(10, 10);
            Axe axe = new Axe(1, 2);
            axe.Attack(dummy);
            Assert.That(dummy.Health == 9);
        }
        [Test]
        public void DeadDummyThrowsAnExceptionIfAttacked()
        {
            Assert.That(() =>
            {
                Dummy dummy = new Dummy(2, 10);
                Axe axe = new Axe(1, 10);
                axe.Attack(dummy);
                axe.Attack(dummy);
                axe.Attack(dummy);
            },
           Throws.Exception.TypeOf<InvalidOperationException>());
        }
        [Test]
        public void DeadDummyCanGiveXP()
        {
            Dummy dummy = new Dummy(0, 10);
            Assert.That(dummy.GiveExperience() == 10);
        }
        [Test]
        public void AliveDummyCantGiveXP()
        {
            Assert.That(() =>
            {
                Dummy dummy = new Dummy(1, 10);
                dummy.GiveExperience();
            }, Throws.Exception.TypeOf<InvalidOperationException>(), "Target is not dead.");
        }


    }
}