using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SerchFlightsTest.Pages
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

        protected string EntryUrl { get; }

        public string CurrentUrl => WebDriver.Url;

        public virtual Page OpenPage()
        {
            WebDriver.Navigate().GoToUrl(EntryUrl);

            return this;
        }


        protected IWebElement FindBy(By key)
        {
            var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(5));
            Thread.Sleep(100);
            return wait.Until(driver => driver.FindElement(key));
        }
    }
}
