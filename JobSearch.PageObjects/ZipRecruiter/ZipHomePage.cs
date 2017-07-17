using OpenQA.Selenium;
using Golem.WebDriver;

namespace JobSearch.PageObjects.ZipRecruiter
{
    public class ZipHomePage : BasePageObject
    {
        private readonly Element _searchField = new Element(By.Id("search1"));
        private readonly Element _locationField = new Element(By.Id("location1"));
        private readonly Element _submitBtn = new Element(By.XPath("//button[@class='t_job_search_form_submit']"));

        public ZipSearchPage GoToSearchPage(string searchWord, string location)
        {
            _searchField.SetText(searchWord);
            _locationField.SetText(location);
            _submitBtn.Click();
            return new ZipSearchPage();
        }
    }
}
