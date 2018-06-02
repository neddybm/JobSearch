using Golem.WebDriver;
using JobSearch.PageObjects.Indeed;
using OpenQA.Selenium;

namespace JobSearch.PageObjects.Dice
{
    public class DiceHomePage : BasePageObject
    {
        private readonly Element _advancedSearchBtn = new Element(By.CssSelector("#search-form a"));

        public DiceAdvancedSearchPage GoToSearchPage()
        {
            _advancedSearchBtn.Click();
            return new DiceAdvancedSearchPage();
        }
    }
}
