using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SerchFlightsTest.Pages;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace SerchFlightsTest 
{       

    public class HomeFligtsPage : Page
    {
        public HomeFligtsPage(IWebDriver webDriver) : base(webDriver, "https://skiplagged.com/flights/MSQ/2021-12-30") { }

        public IWebElement FromPlaceField => FindBy(By.ClassName("src-input"));
        public IWebElement ToPlaceField => FindBy(By.ClassName("dst-input"));
        public IWebElement SearchBTN => FindBy(By.ClassName("blue-btn"));
        public IWebElement SearchResults => FindBy(By.ClassName("trip-list"));

        public IWebElement HotelsRef => FindBy(By.LinkText("Hotels"));

        public HomeFligtsPage EnterFromPlace(string place)
        {
            FromPlaceField.Clear();
            FromPlaceField.SendKeys(place);
            return this;
        }
        public HomeFligtsPage EnterToPlace(string place)
        {
            ToPlaceField.Clear();
            ToPlaceField.SendKeys(place);
            return this;
        }
        public HomeFligtsPage ClickBTN()
        {
            SearchBTN.Click();
            return this;
        }

       public IWebElement FindElement()
       {
            var we = SearchResults;
            return we;
       }

        public override Page OpenPage()
        {
            WebDriver.Navigate().GoToUrl(EntryUrl);
            return this;
        }
      private IWebElement FindBy(By key)
        {
           return new WebDriverWait(WebDriver, TimeSpan.FromSeconds(5)).Until(driver => driver.FindElement(key));
        }
    }

    /*public static ChromeDriver driver;
    public void InitBrowser()
    {
        driver = new ChromeDriver();
    }
    public void CloseBrowser()
    {
        driver.Quit();
    }
    public void OpenURL(string URL)
    {
        driver.Navigate().GoToUrl(URL);
    }*/
}

