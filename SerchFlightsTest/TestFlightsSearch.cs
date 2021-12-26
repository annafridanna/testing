using DocumentFormat.OpenXml.Office2010.CustomUI;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using SerchFlightsTest.Pages;
using SerchFlightsTest;
using System;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace SerchFlightsTest
{
    public class Test
    {
        public static ChromeDriver _driver;
        [SetUp]
        public void Setup()
        {
            var option = new ChromeOptions();
            option.AddArguments("--window-size=1920,1920");
            _driver = new ChromeDriver(option);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Close();
        }


        [Test]
        public void Test1()
        {
            var homePage = new HomeFligtsPage(_driver);
            homePage.OpenPage();
            homePage
                .EnterFromPlace("NYC")
                .EnterToPlace("WAW")
                .ClickBTN();
            Thread.Sleep(7000);
            var SearchResults = homePage.SearchResults.Displayed;
            Assert.IsTrue(SearchResults);

        }
    }
}
