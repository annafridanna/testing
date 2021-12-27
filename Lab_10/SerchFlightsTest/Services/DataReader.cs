using SearchFlightsTest.Models;
using SearchFlightsTest.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFlightsTest.Services
{
    public class DataReader
    {
        public static TravelData TravelData
        {
            get
            {
                return new TravelData() { 
                    From = Settings.Default.From, 
                    To = Settings.Default.To, 
                    StartDate = Settings.Default.StartDate, 
                    EndDate = Settings.Default.EndDate };
            }
        }
    }
}
