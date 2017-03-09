using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Web;

namespace EndToEndMailCourse._01
{
    [TestFixture]
    public class Workshop01Tests
    {
        private string testUrl = "https://suvroc.github.io/selenium-mail-course/01/workshop.html";
        private string testMantis = "https://sourceforge.net/projects/mantisbt/files/mantis-stable/";

        [Test]
        public void Mantis()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl(testMantis);


            string TableID = "files_list";
            IWebElement baseTable = driver.FindElement(By.Id(TableID));
            IList<IWebElement> tableRows = baseTable.FindElements(By.TagName("tr"));

            IWebElement tablecell = driver.FindElement(By.XPath("//td[@headers='files_downloads_h']"));
            IList<IWebElement> colDownloads = baseTable.FindElements(By.XPath("//td[@headers='files_downloads_h']"));
            IList<IWebElement> colVersion = baseTable.FindElements(By.XPath("//th[@headers='files_name_h']"));
            //List<IWebElement> elements = colDownloads.ToList();
            //var mksi = elements.ToString().Max();
            var max2 = colDownloads.Select(x => int.Parse(x.Text.Trim().Replace(",", string.Empty))).OrderByDescending(x => x).ElementAt(1);
            //var max3 = colDownloads.OrderByDescending().ElementAt(1);
            //var max2 = colDownloads.Select(x => int.Parse(x.Text.Trim())).Max();
            var i = 0;
            foreach (var row in colDownloads)
            {

                var lista = colDownloads[i];
                var el4 = colDownloads[4];

                var wynik = lista.Text;
                var max = colDownloads.Select(x => int.Parse(x.Text.Trim())).Max();
                i++;
            }

            var number = colDownloads[4];


            int index = 0;
            //var stringi = baseTable2.Text.ToString();
            //var maks = stringi.Max();
            //var stringi2 = tableCols2.ToString().Max();
            //int maximum = tableCols.ToString().Max();
            //var maximum2 = tableCols2.ToString().Max();
            //int rowsCount = tableRows.Count;
            //int columnsCount = tableCols.Count;
            //string[] cellValue;
            //var list = tableCols.ToList();
            ////var maxList = list.Max();
            ////var newList = tableCols.OrderByDescending(x => x.tableCols).ToList();



            //for (int i = 2; i <= rowsCount; i++)
            //{
            //    for (int k = 1; k <= columnsCount; k++)
            //    {
            //        cellValue = baseTable.Text.ToString();

            //        if (k == 3)
            //        {
            //            var maxValue = cellValue.ToString().Max();
            //            Console.WriteLine("The maximum is: {0}", maxValue);
            //            Console.ReadKey();
            //        }
            //    }
            //}
        }


        [Test]
        public void ShouldTestFirstName()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl(testUrl);
            string value = "";
            IWebElement element = null;

            #region TEST CODE
            element = driver.FindElementByName("firstName");
            value = element.GetAttribute("value");
            #endregion

            Assert.IsNotNull(element);
            Assert.IsTrue(element is IWebElement);
            Assert.AreEqual(value, "Terry");

            driver.Quit();
        }

        [Test]
        public void ShouldTestLastName()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl(testUrl);
            string value = "";
            IWebElement element = null;

            #region TEST CODE
            element = driver.FindElementByName("lastName");
            value = element.GetAttribute("value");
            #endregion

            Assert.IsNotNull(element);
            Assert.IsTrue(element is IWebElement);
            Assert.AreEqual(value, "Pratchett");

            driver.Quit();
        }

        [Test]
        public void ShouldTestCountry()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl(testUrl);
            string value = "";
            IWebElement element = null;

            #region TEST CODE
            element = driver.FindElementByName("country");
            value = element.GetAttribute("value");
            #endregion

            Assert.IsNotNull(element);
            Assert.IsTrue(element is IWebElement);
            Assert.AreEqual(value, "England");

            driver.Quit();
        }

        [Test]
        public void ShouldTestActiveCheckbox()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl(testUrl);
            bool value = true;
            IWebElement element = null;

            #region TEST CODE
            element = driver.FindElementById("isActive");
            value = element.Enabled;
            #endregion

            Assert.IsNotNull(element);
            Assert.IsTrue(element is IWebElement);
            Assert.AreEqual(element.Enabled, false);
            Assert.AreEqual(value, false);

            driver.Quit();
        }

        [Test]
        public void ShouldTestCommentInput()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl(testUrl);
            string value = "";
            IWebElement element = null;

            #region TEST CODE
            element = driver.FindElementById("commentInput");
            value = element.GetAttribute("value");
            #endregion

            Assert.IsNotNull(element);
            Assert.IsTrue(element is IWebElement);
            Assert.AreEqual(value, "");

            driver.Quit();
        }

        [Test]
        public void ShouldTestDetailsLink()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl(testUrl);
            IWebElement element = null;

            #region TEST CODE
            element = driver.FindElementByLinkText("Details");
            #endregion

            Assert.IsNotNull(element);
            Assert.IsTrue(element is IWebElement);
            Assert.AreEqual(element.GetAttribute("href"), @"https://en.wikipedia.org/wiki/Terry_Pratchett");

            driver.Quit();
        }

        [Test]
        public void ShouldTestListOfBooksLink()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl(testUrl);

            IWebElement element = null;

            #region TEST CODE
            element = driver.FindElementByPartialLinkText("List");
            #endregion

            Assert.IsNotNull(element);
            Assert.IsTrue(element is IWebElement);
            Assert.AreEqual(element.GetAttribute("href"), @"https://www.terrypratchettbooks.com/books/");

            driver.Quit();
        }
    }
}
