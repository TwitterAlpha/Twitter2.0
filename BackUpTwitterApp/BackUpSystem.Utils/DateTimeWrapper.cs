using BackUpSystem.Utilities.Contracts;
using System;

namespace BackUpSystem.Utils
{
    /// <summary>
    /// Abstracts DateTime in order to be testable
    /// </summary>
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
