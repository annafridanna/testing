using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SearchFlightsTest.Pages
{
    public class Page
    {
        public Page(IWebDriver webDriver, string entryUrl)
        {
            WebDriver = webDriver;
            EntryUrl = entryUrl;
            PageFactory.InitElements(webDriver, this);
        }

        protected IWebDriver WebDriver { get; }

        public string EntryUrl { get; }

        public string CurrentUrl => WebDriver.Url;

        public virtual Page OpenPage()
        {
            WebDriver.Navigate().GoToUrl(EntryUrl);

            return this;
        }

        protected IWebElement FindBy(By key)
        {
            var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(7));
            Thread.Sleep(100);
            return wait.Until(driver => driver.FindElement(key));
        }

        protected DateTime GetDatePikerMonth()
        {
            var monthTxt = FindBy(By.ClassName("ui-datepicker-month")).Text;
            var yearTxt = FindBy(By.ClassName("ui-datepicker-year")).Text;

            string dateStr = yearTxt + " " + monthTxt + " 01";

            return DateTime.ParseExact(dateStr, "yyyy MMMM dd", null);
        }

        protected void EnterDate(IWebElement dateElement, DateTime date)
        {
            if (date == null || dateElement == null)
                return;

            if (!dateElement.Displayed)
                return;

            dateElement.Click();
            Thread.Sleep(300);
            var dpDate = GetDatePikerMonth();
            while (dpDate.Year < date.Year || dpDate.Month < date.Month)
            {
                var nextBtn = FindBy(By.ClassName("ui-datepicker-next"));
                nextBtn.Click();
                dpDate = GetDatePikerMonth();
            }
            //find correct date
            var dateRef = FindBy(By.LinkText(date.Day.ToString()));
            dateRef.Click();
        }
    }
}
