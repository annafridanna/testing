using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFlightsTest.Pages
{
    public class BookPage : Page
    {
        public BookPage(IWebDriver driver) : base(driver, "") { }

        
        public IWebElement BookingForm => FindBy(By.ClassName("hotel-book__guest-info"));
    }
}
