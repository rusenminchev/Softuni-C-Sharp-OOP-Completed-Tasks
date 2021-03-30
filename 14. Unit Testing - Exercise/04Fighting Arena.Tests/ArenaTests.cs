using System;
using NUnit.Framework;

//using FightingArena;

namespace Tests
{
    public class ArenaTests
    {
        private Warrior firstWarrior;
        private Warrior secondWarrior;
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
            this.firstWarrior = new Warrior("Conan The Barbarian", 20, 80);
            this.secondWarrior = new Warrior("The Barbarian from Diablo 2", 30, 60);
        }

        [Test]
        public void TestIfConstructorWorksProperly()
        {
            int expectedWarriorsCount = 0;

            int actualWarriorsCount = arena.Warriors.Count;

            Assert.AreEqual(expectedWarriorsCount, actualWarriorsCount);
        }

        [Test]
        public void EnrollMethodShouldAddNewWarriorToTheArenaAndEncreaseTheCount()
        {
            this.arena.Enroll(this.firstWarrior);

            Assert.That(this.arena.Warriors, Has.Member(firstWarrior));    
        }

        [Test]
        public void EnrollShouldEncreaseTheCountWhenAddNewWarrior()
        {
            int expectedCount = arena.Count + 1;

            this.arena.Enroll(this.firstWarrior);

            int actualCount = arena.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void EnrollMethodShouldThrowExceptionIfAddAnExistingWarrior()
        {
            this.arena.Enroll(this.firstWarrior);

            Assert.That(() => this.arena.Enroll(this.firstWarrior),
                Throws
                .InvalidOperationException.With.Message
                .EqualTo("Warrior is already enrolled for the fights!"));
        }

        [Test]
        public void FightMethodShouldCheckIfWarriorsExistandEnvokeAttackMethod()
        {
            this.arena.Enroll(this.firstWarrior);
            this.arena.Enroll(this.secondWarrior);

            int expenctedFirstWarriorHP = this.firstWarrior.HP - this.secondWarrior.Damage;
            int expenctedSecondWarriorHP = this.secondWarrior.HP - this.firstWarrior.Damage;

            arena.Fight(this.firstWarrior.Name, this.secondWarrior.Name);

            int actualFirstWarriorHP = this.firstWarrior.HP;
            int actualSecondWarriorHP = this.secondWarrior.HP;

            Assert.AreEqual(expenctedFirstWarriorHP, actualFirstWarriorHP);
            Assert.AreEqual(expenctedSecondWarriorHP, actualSecondWarriorHP);
        }

        [Test]
        public void FightMethodShouldThrowExceptionIfTheAttackerDoesNotExist()
        {
            this.arena.Enroll(this.firstWarrior);
            this.arena.Enroll(this.secondWarrior);

            string attackerName = "Sasho Roman";
            string deffenderName = "The Barbarian from Diablo 2";

            Assert.That(() => arena.Fight(attackerName, deffenderName),
               Throws
               .InvalidOperationException.With.Message
               .EqualTo($"There is no fighter with name {attackerName} enrolled for the fights!"));
        }

        [Test]
        public void FightMethodShouldThrowExceptionIfTheDeffenderDoesNotExist()
        {
            this.arena.Enroll(this.firstWarrior);
            this.arena.Enroll(this.secondWarrior);

            string attackerName = "Conan The Barbarian";
            string deffenderName = "Fiki Storaro";

            Assert.That(() => arena.Fight(attackerName, deffenderName),
               Throws
               .InvalidOperationException.With.Message
               .EqualTo($"There is no fighter with name {deffenderName} enrolled for the fights!"));
        }
    }
}
