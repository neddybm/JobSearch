using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using Golem.WebDriver;

namespace JobSearch.PageObjects.ZipRecruiter
{
    public class ZipSearchPage : BasePageObject
    {
        private readonly Element _modalCloseBtn = new Element(By.XPath("//button[@class='modal-close']"));
        private readonly Element _daysSelect = new Element(By.Id("select-menu-search_filters_days"));
        private readonly Element _oneDayOption = new Element(By.XPath("//button[contains(.,'1 day')]"));
        private readonly Element _jobsList = new Element(By.XPath("//div[@class='job_content']"));
        private readonly Element _loadMoreButton = new Element(By.XPath("//button[@class='load_more_jobs']"));
        private readonly Element _noResultsTxt = new Element(By.XPath("//h2[contains(.,'No jobs found.')]"));

        public string GetListings(string searchWord)
        {
            var today = DateTime.Now;
            _modalCloseBtn.Click();
            _daysSelect.Click();
            _oneDayOption.Click();
        
            if (_loadMoreButton.IsPresent(1))
            {
                _loadMoreButton.Click();
            }
            var resultList = new List<string> { "<strong style='color: blue; margin-top: 10px;'>Zip Recruiter - " + searchWord + " - " + today + "</strong></br>" };
            
            if (!_noResultsTxt.IsPresent(1))
            {
                _jobsList.ForEach((resultEl) => {
                    var result = resultEl.FindElement(By.CssSelector("a.job_link"));
                    var title = resultEl.FindElement(By.CssSelector("span.just_job_title"));
                    var org = resultEl.FindElement(By.CssSelector("p.job_org"));
                    var desc = resultEl.FindElement(By.CssSelector(".job_snippet a"));

                    resultList.Add("<strong style='margin-left: 5px'>" + org.Text + " - <a href='" + result.GetAttribute("href") + "'target='_blank'></strong>" + title.Text + "</a> - " + desc.Text + "</br>");
                });
            }
            else
            {
                resultList.Add("No Results Found" + "</br>");
            }
            return string.Join("\r\n", resultList);
        }
    }
}