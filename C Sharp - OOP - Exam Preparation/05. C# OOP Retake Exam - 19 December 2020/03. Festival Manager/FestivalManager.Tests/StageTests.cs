// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 

using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
//using FestivalManager.Entities;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client.Interfaces;

namespace FestivalManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
	public class StageTests
    {
        private Stage stage;
        private Performer firstPerformer;
        private Performer secondPerformer;
        private Song firstSong;
        private Song secondSong;
        [SetUp]
        public void Setup()
        {
             this.stage = new Stage();
            this.firstPerformer = new Performer("Ivan", "Ivanov", 19);
            this.secondPerformer = new Performer("Ivancho", "Ivanov", 30);

            this.firstSong = new Song("Ветрове", new TimeSpan(0, 3, 30));
            this.secondSong = new Song("Бурни Нощи", new TimeSpan(0, 2, 30));

        }

        [Test]
	    public void ConstructorIsWorkingCorrectly()
        {
            Stage stage = new Stage();

 
            int expectedPerformersCount = 0;

            int actual = stage.Performers.Count;
            

            Assert.AreEqual(expectedPerformersCount, actual);
        }


        [Test]
        public void AddPerformerMethodIsWorkingCorrectly()
        {
            Stage stage = new Stage();

            Performer performer = new Performer("Ivan", "Ivanov", 20);

            stage.AddPerformer(performer);

            int expectedPerformersCount = 1;

            int actual = stage.Performers.Count;

            Assert.AreEqual(expectedPerformersCount, actual);
        }


        [Test]
        public void AddPerformerMethodShouldThrowExceptionIfNameIsNull()
        {
            Stage stage = new Stage();

            Performer performer = null;

            Assert.That(() => stage.AddPerformer(performer),
                Throws.ArgumentNullException);



        }

        [Test]
        public void AddPerformerMethodShouldThrowExceptionIfAgeIsBelow18()
        {
            Stage stage = new Stage();

            Performer performer = new Performer("Ivan", "Ivanov", 16);

            Assert.That(() => stage.AddPerformer(performer),
                Throws.ArgumentException);


        }

        [Test]
        public void AddSongMethodIsWorkingCorrectly()
        {
            Stage stage = new Stage();

            Song song = new Song("wind of change", TimeSpan.MaxValue);

            stage.AddSong(song);

            int expectedPerformersCount = 1;

            int actual = 1;

            Assert.AreEqual(expectedPerformersCount, actual);
        }

        [Test]
        public void AddSongShouldThrowException()
        {
            Stage stage = new Stage();

            Song song = new Song("wind of change", TimeSpan.MinValue);

            Assert.That(() => stage.AddSong(song),
                Throws.ArgumentException);
            

        }

        [Test]
        public void AddSongToPerformerIsWorkingCorrectly()
        {
            string songName = this.firstSong.Name;
            string performerName = this.firstPerformer.FullName;

            this.stage.AddPerformer(this.firstPerformer);
            this.stage.AddPerformer(this.secondPerformer);
            this.stage.AddSong(this.firstSong);
            this.stage.AddSong(this.secondSong);

            string expectedResult = $"{this.firstSong.ToString()} will be performed by {performerName}";
            string result = this.stage.AddSongToPerformer(songName, performerName);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void AddSongToPerformerShouldThrowExceptionIfPerformerIsNotInTheCollection()
        {
            string songName = "The 8th Mile";
            string performerName = "Volodya";

            Assert.That(() => this.stage.AddSongToPerformer(songName, performerName),
                    Throws.ArgumentException.With.Message.EqualTo("There is no performer with this name."));

        }

        [Test]
        public void PlayIsWorkingCorrectly()
        {
            this.stage.AddPerformer(this.firstPerformer);
            this.stage.AddPerformer(this.secondPerformer);

            this.stage.AddSong(this.firstSong);
            this.stage.AddSong(this.secondSong);

            this.stage.AddSongToPerformer(this.firstSong.Name, this.firstPerformer.FullName);
            this.stage.AddSongToPerformer(this.secondSong.Name, this.secondPerformer.FullName);


            string expected = $"{2} performers played {2} songs";
            string actual = this.stage.Play();

            Assert.AreEqual(expected, actual);

        }
    }
}