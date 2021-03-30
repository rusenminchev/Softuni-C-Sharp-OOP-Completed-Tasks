using System;
using NUnit.Framework;

//using FightingArena;

namespace Tests
{
    public class WarriorTests
    {
        private const int MIN_ATTACK_HP = 30;

        [SetUp]
        public void Setup()
        {
        
        }

        [Test]
        public void ConstructorShouldWorkProperly()
        {
            string expectedName = "Conan The Barbarian";
            int expectedDamage = 20;
            int expectedHP = 100;

            Warrior warrior = new Warrior(expectedName, expectedDamage, expectedHP);

            string actualName = warrior.Name;
            int actualDamage = warrior.Damage;
            int actualHP = warrior.HP;

            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedDamage, actualDamage);
            Assert.AreEqual(expectedHP, actualHP);
        }

        [TestCase(null)]
        [TestCase("   ")]
        public void NameShouldNotBeNullOrWhiteSpace(string expectedName)
        {
            int expectedDamage = 20;
            int expectedHP = 100;

            Assert.That(() => { Warrior warrior = new Warrior(expectedName, expectedDamage, expectedHP); },
            Throws
            .ArgumentException.With.Message.EqualTo
            ($"Name should not be empty or whitespace!"));
        }

        [TestCase(-1)]
        [TestCase(-30)]
        public void DamageShouldNotBeZeroOrNegative(int expectedDamage)
        {
            string expectedName = "Conan The Barbarian";
            int expectedHP = 100;

            Assert.That(() => { Warrior warrior = new Warrior(expectedName, expectedDamage, expectedHP); },
            Throws
            .ArgumentException.With.Message.EqualTo
            ($"Damage value should be positive!"));
        }

        [TestCase(-1)]
        [TestCase(-30)]
        public void HPShouldNotBeNegative(int expectedHP)
        {
            string expectedName = "Conan The Barbarian";
            int expectedDamage = 20;

            Assert.That(() => { Warrior warrior = new Warrior(expectedName, expectedDamage, expectedHP); },
           Throws
           .ArgumentException.With.Message.EqualTo
           ($"HP should not be negative!"));
        }

        [Test]
        public void AttackMethodShouldDecreaseHPIfSuccessfull()
        {
            Warrior firstWarrior = new Warrior("Conan The Barbarian", 20, 80);
            Warrior secondWarrior = new Warrior("The Barbarian from Diablo 2", 30, 60);

            int expectedFirstWarriorHP = firstWarrior.HP - secondWarrior.Damage;
            int expectedSecondWarriorHP = secondWarrior.HP - firstWarrior.Damage;

            firstWarrior.Attack(secondWarrior);

            int actualFirstWarriorHp = firstWarrior.HP;
            int actualSecondWarriorHp = secondWarrior.HP;

            Assert.AreEqual(expectedFirstWarriorHP, actualFirstWarriorHp);
            Assert.AreEqual(expectedSecondWarriorHP, actualSecondWarriorHp);
        }

        [Test]
        public void WhenAttackEnemyWithLowerHPThanWarriorDamageEnemyHpShouldBeZero()
        {
            Warrior firstWarrior = new Warrior("Conan The Barbarian", 40, 50);
            Warrior secondWarrior = new Warrior("The Barbarian from Diablo 2", 30, 39);

            int expectedSecondWarriorHP = 0;

            firstWarrior.Attack(secondWarrior);
            


            Assert.AreEqual(expectedSecondWarriorHP, secondWarrior.HP);
        }

        [Test]
        public void AttackShouldThrowExceptionIfTryToAttackWithEqualOrLessThan30HP()
        {
            Warrior firstWarrior = new Warrior("Conan The Barbarian", 20, 30);
            Warrior secondWarrior = new Warrior("The Barbarian from Diablo 2", 30, 60);


            Assert.That(() => firstWarrior.Attack(secondWarrior),
           Throws
           .InvalidOperationException.With.Message.EqualTo
           ($"Your HP is too low in order to attack other warriors!"));
        }

        [Test]
        public void AttackShouldThrowExceptionIfTryToAttackEnemyWithEqualOrLessThan30HP()
        {
            Warrior firstWarrior = new Warrior("Conan The Barbarian", 20, 50);
            Warrior secondWarrior = new Warrior("The Barbarian from Diablo 2", 30, 30);

            Assert.That(() => firstWarrior.Attack(secondWarrior),
            Throws
            .InvalidOperationException.With.Message.EqualTo
            ($"Enemy HP must be greater than {MIN_ATTACK_HP} in order to attack him!"));
        }

        [Test]
        public void AttackShouldThrowExceptionIfTryToAttackStrongerEnemy()
        {
            Warrior firstWarrior = new Warrior("Conan The Barbarian", 20, 35);
            Warrior secondWarrior = new Warrior("The Barbarian from Diablo 2", 36, 50);

            Assert.That(() => firstWarrior.Attack(secondWarrior),
            Throws
            .InvalidOperationException.With.Message.EqualTo
            ($"You are trying to attack too strong enemy"));
        }
    }
}