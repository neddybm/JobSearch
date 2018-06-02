using System;
using System.Collections.Generic;
using Castle.Core.Internal;
using Golem.WebDriver;
using OpenQA.Selenium;

namespace JobSearch.PageObjects.Indeed
{
    public class IndeedSearchResultsPage : BasePageObject
    {
        private readonly Element _advancedSearchBtn = new Element(By.XPath("//a[contains(.,'Advanced Job Search')]"));
        private readonly Element _jobsList = new Element(By.XPath("//div[@data-tn-component='organicJob']"));
        
        public IndeedAdvancedSearchPage GoToAdvancedSearchPage()
        {
            _advancedSearchBtn.Click();
            return new IndeedAdvancedSearchPage();
        }

        public string GetListings(string searchWord)
        {
            var today = DateTime.Now;
            
            var resultList = new List<string> { "<strong style='color: blue; margin-top: 10px;'>Indeed - " + searchWord + " - " + today + "</strong></br>" };

            _jobsList.ForEach(resultEl => {
                var result = resultEl.FindElement(By.CssSelector("h2>a.turnstileLink"));
                var title = resultEl.FindElement(By.CssSelector("h2>a.turnstileLink"));
                var desc = resultEl.FindElement(By.CssSelector(".summary"));
                var orgcheck1 = resultEl.FindElements(By.CssSelector(".company>span>a"));
                var orgcheck2 = resultEl.FindElements(By.CssSelector(".company>span"));

                if (!orgcheck1.IsNullOrEmpty())
                {
                    _jobsList.IsPresent(1);
                    var org = resultEl.FindElement(By.CssSelector(".company>span>a"));
                    resultList.Add("<strong style='margin-left: 5px'>" + org.Text + " - <a href='" + result.GetAttribute("href") + "'target='_blank'></strong>" + title.Text + "</a> - " + desc.Text + "</br>");
                }
                else
                {
                    
                    if (!orgcheck2.IsNullOrEmpty())
                    {
                        var org = resultEl.FindElement(By.CssSelector(".company>span")).Text;
                        resultList.Add("<strong style='margin-left: 5px'>" + org + " - <a href='" + result.GetAttribute("href") + "'target='_blank'></strong>" + title.Text + "</a> - " + desc.Text + "</br>");
                    }
                    else
                    {
                        resultList.Add("<strong style='margin-left: 5px'>Company not found</strong> - <a href='" + result.GetAttribute("href") + "'target='_blank'></strong>" + title.Text + "</a> - " + desc.Text + "</br>");
                    }
                    
                }
            });

            return string.Join("\r\n", resultList);

        }
    }
}