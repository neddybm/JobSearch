using Golem.WebDriver;
using OpenQA.Selenium;

namespace JobSearch.PageObjects.Indeed
{
    public class IndeedHomePage : BasePageObject
    {
        //private readonly Element _advancedSearchBtn = new Element(By.XPath("//a[contains(.,'Advanced Job Search')]"));
        private readonly Element _whatFld = new Element(By.Id("text-input-what"));
        private readonly Element _whereFld = new Element(By.Id("text-input-where"));
        private readonly Element _findJobsBtn = new Element(By.CssSelector("button"));

        public IndeedSearchResultsPage GoToSearchPage(string searchWord, string location)
        {
            _whatFld.SetText(searchWord);
            _whereFld.SetText(location);
            _findJobsBtn.Click();
            return new IndeedSearchResultsPage();
        }

        //public IndeedAdvancedSearchPage GoToSearchPage()
        //{
        //    _advancedSearchBtn.Click();
        //    return new IndeedAdvancedSearchPage();
        //}
    }
}
