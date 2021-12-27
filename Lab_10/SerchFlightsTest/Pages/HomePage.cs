using OpenQA.Selenium;
using SearchFlightsTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SearchFlightsTest.Pages
{
    public class HomePage: Page
    {
        public HomePage(IWebDriver webDriver) : base(webDriver, "https://skiplagged.com") { }
        public IWebElement FromPlaceField => FindBy(By.ClassName("src-input"));
        public IWebElement ToPlaceField => FindBy(By.ClassName("dst-input"));
        public IWebElement StartDateField => FindBy(By.ClassName("start-date"));
        public IWebElement EndDateField => FindBy(By.ClassName("end-date"));
        public IWebElement SearchBTN => FindBy(By.ClassName("blue-btn"));
  

        public FligtsPage SearchFlights(TravelData filter)
        {
            return this               
            .EnterFromPlace(filter.From)
            .EnterToPlace(filter.To)
            .EnterStartDate(filter.StartDate)
            .EnterEndDate(filter.EndDate)
            .ClickBTN();
        }

        public HomePage EnterFromPlace(string place)
        {
            FromPlaceField.Clear();
            if (place != null)
                FromPlaceField.SendKeys(place);
            return this;
        }
        public HomePage EnterToPlace(string place)
        {
            ToPlaceField.Clear();
            if (place != null)
                ToPlaceField.SendKeys(place);
            return this;
        }

        public HomePage EnterStartDate(DateTime date)
        {            
            EnterDate(StartDateField, date);
            return this;
        }

        public HomePage EnterEndDate(DateTime date)
        {
            EnterDate(EndDateField, date);
            return this;
        }


        public FligtsPage ClickBTN()
        {
            SearchBTN.Click();            
            return new FligtsPage(WebDriver);
        }

        public override Page OpenPage()
        {
            WebDriver.Navigate().GoToUrl(EntryUrl);
            return this;
        }

    }
}
