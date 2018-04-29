using BackUpSystem.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace BackUpSystem.Utilities.Contracts
{
    public interface IMappingProvider
    {
        TDestination MapTo<TDestination>(object source);

        IEnumerable<TDestination> ProjectTo<TDestination>(IEnumerable<object> source);

        IQueryable<TDestination> ProjectTo<TSource, TDestination>(IQueryable<TSource> source);

        IEnumerable<TDestination> ProjectTo<TSource, TDestination>(IEnumerable<TSource> source);
    }
}
