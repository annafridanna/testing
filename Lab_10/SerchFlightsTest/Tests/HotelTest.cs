using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using SearchFlightsTest.Pages;
using SearchFlightsTest.Services;

namespace SearchFlightsTest.Tests
{
    class HotelTest : BaseTest
    {
        protected HotelPage FindHotelsStep()
        {
            var page = new HotelPage(Driver);
            page.OpenPage();
            return page.FindHotels(DataReader.TravelData);
        }

        [Test]
        public void FindHotels()
        {
            var page = FindHotelsStep();

            Thread.Sleep(7000);
            var SearchResults = page.SearchResults.Displayed;
            Assert.IsTrue(SearchResults);

        }
        [Test]
        public void SelectRoom()
        {
            var page = FindHotelsStep();
            Thread.Sleep(7000);
            var roomPage = page.SelectRoom();
            Thread.Sleep(3000);
            Assert.IsTrue(roomPage.CurrentUrl.Equals(roomPage.EntryUrl));
        }

        [Test]
        public void BookRoom()
        {
            var page = FindHotelsStep();
            Thread.Sleep(7000);
            var roomPage = page.SelectRoom();
            Thread.Sleep(3000);
            var bookPage = roomPage.Book();
            Thread.Sleep(3000);
            Assert.IsTrue(bookPage.BookingForm.Displayed);
        }

    }
}
