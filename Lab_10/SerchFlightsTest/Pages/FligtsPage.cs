using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using SearchFlightsTest.Models;

namespace SearchFlightsTest.Pages
{       

    public class FligtsPage : Page
    {
        public FligtsPage(IWebDriver webDriver) : base(webDriver, "https://skiplagged.com/flights/MSQ/2021-12-30") { }

        public IWebElement FromPlaceField => FindBy(By.ClassName("src-input"));
        public IWebElement ToPlaceField => FindBy(By.ClassName("dst-input"));
        public IWebElement StartDateField => FindBy(By.ClassName("start-date"));
        public IWebElement EndDateField => FindBy(By.ClassName("end-date"));
        public IWebElement SearchBTN => FindBy(By.ClassName("blue-btn"));
        public IWebElement SearchResults => FindBy(By.ClassName("trip-list"));
        public IWebElement Cities => FindBy(By.ClassName("cities"));
        public IWebElement TripDiv => FindBy(By.ClassName("trip-path"));
        public IWebElement TripPopup => FindBy(By.ClassName("trip-highlight"));
        public IWebElement EmptyTripsDiv => FindBy(By.ClassName("trip-list-empty-top"));


        public FligtsPage SearchFlights(TravelData filter)
        {
            return this
            .EnterFromPlace(filter.From)
            .EnterToPlace(filter.To)
            .EnterStartDate(filter.StartDate)
            .EnterEndDate(filter.EndDate)
            .ClickBTN();
        }

        public FligtsPage SelectTrip()
        {
            if (TripDiv != null)
                TripDiv.Click();
            return this;
        }

        public FligtsPage EnterStartDate(DateTime date)
        {
            EnterDate(StartDateField, date);
            return this;
        }

        public FligtsPage EnterEndDate(DateTime date)
        {
            EnterDate(EndDateField, date);
            return this;
        }

        public FligtsPage EnterFromPlace(string place)
        {
            FromPlaceField.Clear();
            if (place != null)
                FromPlaceField.SendKeys(place);
            return this;
        }
        public FligtsPage EnterToPlace(string place)
        {
            ToPlaceField.Clear();
            if (place != null)
                ToPlaceField.SendKeys(place);
            return this;
        }
        public FligtsPage ClickBTN()
        {
            SearchBTN.Click();
            return this;
        }

         public override Page OpenPage()
        {
            WebDriver.Navigate().GoToUrl(EntryUrl);
            return this;
        }
    }
}

