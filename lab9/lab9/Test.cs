using NUnit.Framework;

namespace lab9
{
    public class Tests : Browser
    {
        [SetUp]
        public void Setup()
        {
            InitBrowser();
            OpenURL("https://skiplagged.com/flights/MSQ/2021-12-27");
        }

        [TearDown]
        public void TearDown()
        {
            CloseBrowser();
        }


        [Test]
        public void Test1()
        {
            var commands = new Commands();
            commands.InputText("src-input", "NYC");
            commands.InputText("dst-input", "WAW");
            commands.Click("blue-btn");
            Assert.IsTrue(commands.FindElement("trip-list").Displayed);

        }
    }
}