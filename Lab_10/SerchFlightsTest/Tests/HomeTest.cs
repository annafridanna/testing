using NUnit.Framework;
using SearchFlightsTest.Models;
using SearchFlightsTest.Pages;
using SearchFlightsTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SearchFlightsTest.Tests
{
    class HomeTest : BaseTest
    {
        [Test]
        public void TestSearch()
        {
            var homePage = new HomePage(Driver);
            homePage.OpenPage();
            var searchPage = homePage.SearchFlights(DataReader.TravelData);
            Thread.Sleep(7000);
            var SearchResults = searchPage.SearchResults.Displayed;
            Assert.IsTrue(SearchResults);
        }
    }
}
