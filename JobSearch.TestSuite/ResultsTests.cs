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
        [TestCase("https://www.ziprecruiter.com", "IT Manager", "Colorado", TestName = "IT Manager")]
        [TestCase("https://www.ziprecruiter.com", "IS Manager", "Colorado", TestName = "IS Manager")]
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
        [TestCase("https://www.indeed.com", "IT Manager", "Colorado", TestName = "IT Manager")]
        [TestCase("https://www.indeed.com", "IS Manager", "Colorado", TestName = "IS Manager")]
        public void IndeedWriteResultsTests(string url, string searchWord, string location)
        {
            driver.Navigate().GoToUrl(url);
            var listing = new IndeedHomePage()
                .GoToSearchPage(searchWord, location)
                .GoToAdvancedSearchPage()
                .GoToSearchResultsPage(searchWord, location)
                .GetListings(searchWord);
            new FileLogger($"..\\..\\reports\\{TestContext.CurrentContext.Test.Name.ToLower()}_test-report.html").Write(listing, true);
        }

        [Test]
        //[TestCase("https://www.dice.com", "DevOps", "Colorado", TestName = "DevOps")]
        //[TestCase("https://www.dice.com", "Selenium", "Colorado", TestName = "Selenium")]
        [TestCase("https://www.dice.com", "IT Manager", "Colorado", TestName = "IT Manager")]
        [TestCase("https://www.dice.com", "IS Manager", "Colorado", TestName = "IS Manager")]
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
