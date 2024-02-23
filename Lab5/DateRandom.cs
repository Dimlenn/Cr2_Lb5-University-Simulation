using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class DateRandom
    { 
        Random random = new Random();
        private DateTime RandomDateTime(DateTime dateNow)
        {
            int yearMin = dateNow.Year - 20;
            var startDate = new DateTime(yearMin, 1, 1);
            int buffer = 2 * 265;
            var newDate = startDate.AddDays(random.Next(buffer));
            return newDate;
        }
        public DateOnly RandomDateOnly(DateTime year)
        {
            DateTime randomDateTime = RandomDateTime(year);
            return DateOnly.FromDateTime(randomDateTime);
        }
    }
}
