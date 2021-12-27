using NUnit.Framework;
using OpenQA.Selenium;
using SearchFlightsTest.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFlightsTest.Tests
{
    class BaseTest
    {
        protected IWebDriver Driver
        {
            get 
            { 
                return DriverInstance.GetInstance();
            }
        }

        [SetUp]
        public virtual void Setup()
        {
            DriverInstance.GetInstance();
        }

        [TearDown]
        public virtual void TearDown()
        {
            DriverInstance.CloseBrowser();
        }
    }
}
