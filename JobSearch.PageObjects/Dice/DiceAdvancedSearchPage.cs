using Golem.WebDriver;
using OpenQA.Selenium;

namespace JobSearch.PageObjects.Dice
{
    public class DiceAdvancedSearchPage : BasePageObject
    {
        private readonly Element _searchField = new Element(By.Id("for_all"));
        private readonly Element _typeSelect = new Element(By.XPath("//button[contains(.,'Toggle Dropdown')]"));
        private readonly Element _fullTimeChk = new Element(By.XPath("//*[@id='jtype1']/a/input"));
        private readonly Element _locationField = new Element(By.Id("for_loc"));
        private readonly Element _submitBtn = new Element(By.Id("adv_search"));

        public DiceSearchResultsPage GoToSearchResultsPage(string searchWord, string location)
        {
            _searchField.SetText(searchWord);
            _typeSelect.Click();
            _fullTimeChk.Click();
            _locationField.SetText(location);
            driver.ExecuteJavaScript("document.evaluate(\"//div[@id=\'postedDateS\']/a[@class=\'ui-slider-handle ui-state-default ui-corner-all\']\", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue.style.cssText = \"left: 0%;\")");
            driver.ExecuteJavaScript("document.evaluate(\"//div[@id=\'limitS\']/a\", document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue.style.cssText = \"left: 100%;\")");
            _submitBtn.Click();
            return new DiceSearchResultsPage();
        }
    }
}
