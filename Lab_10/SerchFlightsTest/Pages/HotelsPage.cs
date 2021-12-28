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
    
    public class HotelPage : Page
    {
        public HotelPage(IWebDriver webDriver) : base(webDriver, "https://skiplagged.com/hotels") { }

        public IWebElement PlaceField => FindBy(By.Id("dst"));
        public IWebElement StartDateField => FindBy(By.ClassName("start-date"));
        public IWebElement EndDateField => FindBy(By.ClassName("end-date"));
        public IWebElement SearchBTN => FindBy(By.ClassName("blue-btn"));
        public IWebElement SearchResults => FindBy(By.ClassName("hotels-list"));

        public IWebElement HotelRoom => FindBy(By.ClassName("hotel-card"));




        public HotelPage FindHotels(TravelData td)
        {
            if (td.To != null)
                EnterPlace(td.To);
            Thread.Sleep(100);
            if (td.StartDate != null)
                EnterDate(StartDateField, td.StartDate);

            Thread.Sleep(100);
            if (td.EndDate != null)
                EnterDate(EndDateField, td.EndDate);

            return ClickBTN();
        }

        public RoomPage SelectRoom()
        {
            var refRoom = HotelRoom;
            string link = refRoom.GetAttribute("href");
            refRoom.Click();
            return new RoomPage(WebDriver, link);
        }

        public HotelPage EnterPlace(string place)
        {
            PlaceField.Clear();
            PlaceField.SendKeys(place);
            return this;
        }
       
        public HotelPage ClickBTN()
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


    }
}

