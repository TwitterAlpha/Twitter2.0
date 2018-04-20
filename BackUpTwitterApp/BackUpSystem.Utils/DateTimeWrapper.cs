using BackUpSystem.Utilities.Contracts;
using System;

namespace BackUpSystem.Utils
{
    public class DateTimeWrapper : IDateTimeProvider
    {
        public DateTime Now()
        {
           return DateTime.Now;
        }

        public DateTime UtcNow()
        {
            return DateTime.UtcNow;
        }
    }
}
