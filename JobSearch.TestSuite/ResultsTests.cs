using Golem;
using NUnit.Framework;
using JobSearch.PageObjects.ZipRecruiter;
using JobSearch.PageObjects.Dice;
using JobSearch.PageObjects.Indeed;
using JobSearch.Helpers;

namespace JobSearch.TestSuite
{
    public class ResultsTests : WebDriverTestBase
    {
        [Test]
        //[TestCase("https://www.ziprecruiter.com", "DevOps", "Colorado", TestName = "DevOps")]
        //[TestCase("https://www.ziprecruiter.com", "Selenium", "Colorado", TestName = "Selenium")]
        [TestCase("https://www.ziprecruiter.com", "Facilities", "Colorado", TestName = "Facilities")]
        public void ZipWriteResultsTests(string url, string searchWord, string location)
        {
            driver.Navigate().GoToUrl(url);
            var listing = new ZipHomePage()
                .GoToSearchPage(searchWord, location)
                .GetListings(searchWord);
            new FileLogger($"..\\..\\reports\\{TestContext.CurrentContext.Test.Name.ToLower()}_test-report.html").Write(listing, true);
        }

        [Test]
        //[TestCase("https://www.indeed.com", "DevOps", "Colorado", TestName = "DevOps")]
        //[TestCase("https://www.indeed.com", "Selenium", "Colorado", TestName = "Selenium")]
        [TestCase("https://www.indeed.com", "Facilities", "Colorado", TestName = "Facilities")]
        public void IndeedWriteResultsTests(string url, string searchWord, string location)
        {
            driver.Navigate().GoToUrl(url);
            var listing = new IndeedHomePage()
                .GoToSearchPage()
                .GoToSearchResultsPage(searchWord, location)
                .GetListings(searchWord);
            new FileLogger($"..\\..\\reports\\{TestContext.CurrentContext.Test.Name.ToLower()}_test-report.html").Write(listing, true);
        }

        [Test]
        //[TestCase("https://www.dice.com", "DevOps", "Colorado", TestName = "DevOps")]
        //[TestCase("https://www.dice.com", "Selenium", "Colorado", TestName = "Selenium")]
        [TestCase("https://www.dice.com", "Facilities", "Colorado", TestName = "Facilities")]
        public void DiceWriteResultsTests(string url, string searchWord, string location)
        {
            driver.Navigate().GoToUrl(url);
            var listing = new DiceHomePage()
                .GoToSearchPage()
                .GoToSearchResultsPage(searchWord, location)
                .GetListings(searchWord);
            new FileLogger($"..\\..\\reports\\{TestContext.CurrentContext.Test.Name.ToLower()}_test-report.html").Write(listing, true);
        }
    }
}
