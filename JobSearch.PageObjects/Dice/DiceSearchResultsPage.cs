using System;
using System.Collections.Generic;
using Golem.WebDriver;
using OpenQA.Selenium;

namespace JobSearch.PageObjects.Dice
{
    public class DiceSearchResultsPage : BasePageObject
    {
        private readonly Element _jobsList = new Element(By.CssSelector(".bold-highlight"));
        
        public string GetListings(string searchWord)
        {
            var today = DateTime.Now;
            var resultList = new List<string> { "<strong style='color: blue; margin-top: 10px;'>Dice - " + searchWord + " - " + today + "</strong></br>"};
            
            _jobsList.ForEach(resultEl => {
                var result = resultEl.FindElement(By.CssSelector(".bold-highlight h3>a"));
                var title = resultEl.FindElement(By.CssSelector(".bold-highlight h3>a"));
                var desc = resultEl.FindElement(By.CssSelector(".bold-highlight>.shortdesc.col-sm-3.col-xs-8.col-md-8.col-lg-8.text-ellipsis.hidden-xs.hidden-sm>span"));
                var org = resultEl.FindElement(By.CssSelector(".bold-highlight span.compName"));
                
                resultList.Add("<strong style='margin-left: 5px'>" + org.Text + " - <a href='" + result.GetAttribute("href") + "' target='_blank'></strong>" + title.Text + "</a> - " + desc.Text + "</br>");
            });

            return string.Join("\r\n", resultList);

        }
    }
}