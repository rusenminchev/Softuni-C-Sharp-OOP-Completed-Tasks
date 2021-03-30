using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;

using Raiding.Core.Contracts;
using Raiding.Exceptions;
using Raiding.Factories;
using Raiding.IO;
using Raiding.IO.Contracts;
using Raiding.Models;

namespace Raiding.Core
{
    public class Engine : IEngine
    {
        private List<BaseHero> heroes;
        private HeroFactory heroFactory;
        private IReadable reader;
        private IWritable writer;

        public Engine()
        {
            this.heroes = new List<BaseHero>();
            this.heroFactory = new HeroFactory();
            this.reader = new Reader();
            this.writer = new Writer();
        }
        public void Run()
        {

            CreateHeroes();

            int bossPower = int.Parse(this.reader.ReadLine());
            int heroesTotalPower = 0;

            heroesTotalPower = DoTheRaid(heroesTotalPower);
            PrintOutput(bossPower, heroesTotalPower);
        }

        private void PrintOutput(int bossPower, int heroesTotalPower)
        {
            if (heroesTotalPower >= bossPower)
            {
                this.writer.WriteLine("Victory!");
            }
            else
            {
                this.writer.WriteLine("Defeat...");
            }
        }

        private int DoTheRaid(int heroesTotalPower)
        {
            foreach (var hero in this.heroes)
            {
                this.writer.WriteLine(hero.CastAbility());
                heroesTotalPower += hero.Power;
            }

            return heroesTotalPower;
        }

        private void CreateHeroes()
        {
            int n = int.Parse(this.reader.ReadLine());

            while (this.heroes.Count != n)
            {
                string heroName = this.reader.ReadLine();
                string heroType = this.reader.ReadLine();
                try
                {
                    BaseHero hero = heroFactory.CreateHero(heroType, heroName);
                    this.heroes.Add(hero);
                }
                catch (InvalidHeroTypeException iht)
                {
                    this.writer.WriteLine(iht.Message);
                }
            }
        }
    }
}
