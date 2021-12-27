using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SearchFlightsTest.Drivers;
using SearchFlightsTest.Models;
using SearchFlightsTest.Pages;
using SearchFlightsTest.Services;

namespace SearchFlightsTest.Tests
{
    class FlightSearchTest : BaseTest
    {    
        [Test]
        public void TestFlights()
        {
            var homePage = new FligtsPage(Driver);
            homePage.OpenPage();
            homePage.SearchFlights(DataReader.TravelData);
            Thread.Sleep(7000);
            var SearchResults = homePage.SearchResults.Displayed;
            Assert.IsTrue(SearchResults);
        }
        [Test]
        public void TestAnywere()
        {
            var homePage = new FligtsPage(Driver);
            homePage.OpenPage();
            TravelData data = new TravelData()
            {
                From = DataReader.TravelData.From,
                StartDate = DataReader.TravelData.StartDate,
                EndDate = DataReader.TravelData.EndDate
            };
            
            homePage.SearchFlights(data);
            Thread.Sleep(7000);
            var SearchResults = homePage.Cities != null && homePage.Cities.Displayed;
            Assert.IsTrue(SearchResults);
        }


        [Test]
        public void TestSelectTrip()
        {
            var flightsPage = new FligtsPage(Driver);
            flightsPage.OpenPage();
            flightsPage.SearchFlights(DataReader.TravelData);
            Thread.Sleep(7000);
            flightsPage.SelectTrip();
            Thread.Sleep(2000);

            Assert.IsTrue(flightsPage.TripPopup.Displayed);
        }

        [Test]
        public void TestWrongDestination()
        {
            var flightsPage = new FligtsPage(Driver);
            flightsPage.OpenPage();
            TravelData data = new TravelData()
            {
                From = DataReader.TravelData.From,
                StartDate = DataReader.TravelData.StartDate,
                EndDate = DataReader.TravelData.EndDate,
                To = "Жодино",
            };

            flightsPage.SearchFlights(data);
            Thread.Sleep(7000);
            var SearchResults = flightsPage.EmptyTripsDiv != null && flightsPage.EmptyTripsDiv.Text.Contains("No flights found");
            Assert.IsTrue(SearchResults);
        }

    }
}
