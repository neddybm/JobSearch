using Golem.WebDriver;
using OpenQA.Selenium;

namespace JobSearch.PageObjects.Indeed
{
    public class IndeedAdvancedSearchPage : BasePageObject
    {
        private readonly Element _searchField = new Element(By.Id("as_and"));
        private readonly Element _typeSelect = new Element(By.Id("jt"));
        private readonly Element _fullTimeOption = new Element(By.XPath("//option[@value='fulltime']"));
        private readonly Element _locationField = new Element(By.Id("where"));
        private readonly Element _ageSelect = new Element(By.Id("fromage"));
        private readonly Element _sinceYesterdayOption = new Element(By.XPath("//option[@value='1']"));
        private readonly Element _displaySelect = new Element(By.Id("limit"));
        private readonly Element _display50Option = new Element(By.XPath("//select[@id='limit']/option[contains(.,'50')]"));
        private readonly Element _submitBtn = new Element(By.Id("fj"));
        
        public IndeedSearchResultsPage GoToSearchResultsPage(string searchWord, string location)
        {
            _searchField.SetText(searchWord);
            _displaySelect.Click();
            _display50Option.Click();
            _typeSelect.Click();
            _fullTimeOption.Click();
            _locationField.SetText(location);
            _ageSelect.Click();
            _sinceYesterdayOption.Click();
            _submitBtn.Click();
            return new IndeedSearchResultsPage();
        }
    }
}
