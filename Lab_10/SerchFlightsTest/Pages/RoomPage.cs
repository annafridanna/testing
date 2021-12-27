using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFlightsTest.Pages
{
    public class RoomPage : Page
    {
        public RoomPage(IWebDriver webDriver, string entryUrl) : base(webDriver, entryUrl) { }

        public IWebElement BookBTN => FindBy(By.ClassName("blue-btn"));

        public BookPage Book()
        {
            BookBTN.Click();
            return new BookPage(WebDriver);
        }
    }
}
