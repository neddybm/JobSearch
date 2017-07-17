using Golem.WebDriver;
using OpenQA.Selenium;

namespace JobSearch.PageObjects.Indeed
{
    public class IndeedHomePage : BasePageObject
    {
        private readonly Element _advancedSearchBtn = new Element(By.XPath("//a[contains(.,'Advanced Job Search')]"));

        public IndeedAdvancedSearchPage GoToSearchPage()
        {
            _advancedSearchBtn.Click();
            return new IndeedAdvancedSearchPage();
        }
    }
}
