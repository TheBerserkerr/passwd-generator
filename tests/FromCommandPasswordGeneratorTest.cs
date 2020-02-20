
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PasswordGenerator.Tests
{
    [TestClass]
    public class FromCommandPasswordGeneratorTest
    {
        [TestMethod]
        public void UnitTest01()
        {
            var cmd = "gen len 12 alpha ll|ul";
        }

        [TestMethod]
        public void UnitTest02()
        {
            var cmd = "gen alpha ll|ul len 12";
        }

        [TestMethod]
        public void UnitTest03()
        {
            var cmd = "gen len 12 alpha ll|ul|";
        }

        [TestMethod]
        public void UnitTest04()
        {
            var cmd = "gen alpha ll|ul| len 12";
        }

        [TestMethod]
        public void UnitTest05()
        {
            var cmd = "gen alpha ll|ul| len 12";
        }

        [TestMethod]
        public void UnitTest06()
        {
            var cmd = "gen alpha 12 ll|ul| len 12";
        }

        private void MakeTest(string cmd)
        {
            var generator = new FromCommandPasswordGenerator(cmd);

            var generated = generator.Generate();
        }
    }
}