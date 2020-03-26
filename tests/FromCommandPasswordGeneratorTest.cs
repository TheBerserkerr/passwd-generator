
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordGenerator.Analyze.Exception;

namespace PasswordGenerator.Tests
{
    [TestClass]
    public class FromCommandPasswordGeneratorTest
    {
        [TestMethod]
        public void UnitTest01()
        {
            var cmd = "gen len 12 alpha ll|ul";

            var pass = MakeTest(cmd);

            Assert.AreEqual(pass.Length, 12);
        }

        [TestMethod]
        public void UnitTest02()
        {
            var cmd = "gen alpha ll|ul len 12";
            var pass = MakeTest(cmd);

            Assert.AreEqual(pass.Length, 12);
        }

        [TestMethod]
        public void UnitTest03()
        {
            var exception = Assert.ThrowsException<ParserException>(() => {
                var cmd = "gen len 12 alpha ll|ul|";
                MakeTest(cmd);
            });

            Assert.AreEqual(exception.Message, "Invalid token <End> expected <Identifier>");
        }

        [TestMethod]
        public void UnitTest04()
        {
            var exception = Assert.ThrowsException<ParserException>(() => {
                var cmd = "gen alpha ll|ul| len 12";
                MakeTest(cmd);
            });

            Assert.AreEqual(exception.Message, "Invalid token <Length> expected <Identifier>");
        }

        [TestMethod]
        public void UnitTest05()
        {
            var exception = Assert.ThrowsException<ParserException>(() => {
                var cmd = "gen alpha ll|ul| len 12";
                MakeTest(cmd);
            });

            Assert.AreEqual(exception.Message, "Invalid token <Length> expected <Identifier>");
        }

        [TestMethod]
        public void UnitTest06()
        {
            var exception = Assert.ThrowsException<ParserException>(() => {
                var cmd = "gen alpha 12 ll|ul| len 12";
                MakeTest(cmd);
            });

            Assert.AreEqual(exception.Message, "Invalid token <Number> expected <Identifier>");
        }

        private string MakeTest(string cmd)
        {
            var generator = new FromCommandPasswordGenerator(cmd);

            var generated = generator.Generate();

            return generated.FirstOrDefault();
        }
    }
}