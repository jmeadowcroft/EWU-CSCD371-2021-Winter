using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class JesterTests
    {
        [TestMethod]
        public void Contructor_NullOutput_Throws()
        {
            var ex = Assert.ThrowsException<ArgumentNullException>(() => new Jester(null, Mock.Of<IJokeService>()));
            Assert.AreEqual("output", ex.ParamName);
        }

        [TestMethod]
        public void Contructor_NullJokeService_Throws()
        {
            var ex = Assert.ThrowsException<ArgumentNullException>(() => new Jester(Mock.Of<IOutput>(), null));
            Assert.AreEqual("jokeService", ex.ParamName);
        }

        [TestMethod]
        public void TellJoke_ChuckNorrisJoke_Retries()
        {
            // Arrange
            string chuckNorrisJoke = "Something something Chuck Norris";
            string validJoke = "This is funny";
            var output = new Mock<IOutput>();
            output.Setup(x => x.WriteLine(validJoke));
            var jokeService = new Mock<IJokeService>();

            jokeService.SetupSequence(x => x.GetJoke())
                .Returns(chuckNorrisJoke)
                .Returns(validJoke);
            
            var jester = new Jester(output.Object, jokeService.Object);

            // Act
            jester.TellJoke();

            // Assert
            jokeService.Verify(x => x.GetJoke(), Times.Exactly(2));
            output.VerifyAll();
        }

        [TestMethod]
        public void TellJoke_ValidJoke_Displays()
        {
            // Arrange
            string validJoke = "This is funny";
            var output = new Mock<IOutput>();
            output.Setup(x => x.WriteLine(validJoke));
            var jokeService = new Mock<IJokeService>();
            jokeService.Setup(x => x.GetJoke()).Returns(validJoke);

            var jester = new Jester(output.Object, jokeService.Object);

            // Act
            jester.TellJoke();

            // Assert
            jokeService.VerifyAll();
            output.VerifyAll();
        }
    }
}
