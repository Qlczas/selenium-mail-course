using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace EndToEndMailCourse._02
{
    [TestFixture]
    public class Workshop02Tests
    {
        private string testUrl = "https://suvroc.github.io/selenium-mail-course/02/workshop.html";

        [Test]
        public void ShouldTestWorkshop2Page()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl(testUrl);
            string name = "Test name";
            string comment = "Test comment";
            IWebElement nameResult = null,
                commentResult = null;

            #region TEST CODE

            IWebElement inputName = driver.FindElement(By.Id("taskNameInput"));
            IWebElement inputComment = driver.FindElement(By.Id("commentInput"));
            IWebElement showDetailsButton = driver.FindElement(By.Id("showDetailsButton"));

            inputName.SendKeys("Test name");
            showDetailsButton.Click();
            inputComment.SendKeys("Test comment");
            inputComment.SendKeys(Keys.Enter);

            #endregion

            nameResult = driver.FindElement(By.Id("savedTaskName"));
            commentResult = driver.FindElement(By.Id("savedComment"));

            Assert.NotNull(nameResult);
            Assert.AreEqual(nameResult.TagName, "div");
            Assert.AreEqual(nameResult.Text, name);
            Assert.IsTrue(nameResult.Displayed);

            Assert.NotNull(commentResult);
            Assert.AreEqual(commentResult.TagName, "div");
            Assert.AreEqual(commentResult.Text, comment);
            Assert.IsTrue(nameResult.Displayed);

            driver.Quit();
        }
    }
}
