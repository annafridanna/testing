using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SerchFlightsTest.Pages
{
    class FrightsSearchResultPage : Page
    {
        //public IWebElement SearchResults => FindBy(By.ClassName("trip-list"));
        public FrightsSearchResultPage(IWebDriver webDriver) : base(webDriver, "https://skiplagged.com/flights/NYC/WAW/2021-12-30") { }

        //public IWebElement FindElement()
        //{
         //   Thread.Sleep(5000);
         //   var we = SearchResults;
          //  return we;
       // }

        public override Page OpenPage()
        {
            WebDriver.Navigate().GoToUrl(EntryUrl);
            return this;
        }
        

        /*public void InputText(string className, string text)
        {
            WaitElement(className);
            driver.FindElement(By.ClassName(className)).Clear();
            driver.FindElement(By.ClassName(className)).SendKeys(text);
        }
        public void Click(string className)
        {
            WaitElement(className);
            driver.FindElement(By.ClassName(className)).Click();
        }

        public IWebElement FindElement(string className)
        {
            WaitElement(className);
            var we = driver.FindElement(By.ClassName(className));
            return we;
        }

        public void WaitElement(string className)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            wait.Until(driver => driver.FindElement(By.ClassName(className)).Displayed);
        }

        /*public void WaitElement(string className)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            //IWebElement we = null;
            var waiter = new WebDriverWait(driver, TimeSpan.FromSeconds(40));

            waiter.Until(d =>
            {
                return driver.FindElement(By.ClassName(className));
            });
        }*/

    }
}
