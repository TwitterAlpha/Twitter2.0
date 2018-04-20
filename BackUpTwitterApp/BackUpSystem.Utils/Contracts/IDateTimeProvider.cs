using System;

namespace BackUpSystem.Utilities.Contracts
{
    public interface IDateTimeProvider
    {
        DateTime Now();

        DateTime UtcNow();
    }
}
