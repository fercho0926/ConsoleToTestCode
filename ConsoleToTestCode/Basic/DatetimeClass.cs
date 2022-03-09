using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToTestCode.Basic
{
    public class DatetimeClass
    {

        public void DateTimesDef() {

            DateTime somedate = new DateTime(2022, 02, 08);
            DateTime today = DateTime.Today;
            DateTime TwoDaysLater = DateTime.Today.AddDays(2);
            DayOfWeek day = DateTime.Today.DayOfWeek;
            bool daylight = DateTime.Today.IsDaylightSavingTime();


            Console.WriteLine($"Some date {somedate}, today: {today}, twhodayslater {TwoDaysLater}, day {day},  daylight {daylight}");
        }
    }
}
