using AutoMapper;
using AutoMapper.QueryableExtensions;
using BackUpSystem.Utilities.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace BackUpSystem.Utils
{
    /// <summary>
    /// Abstracts Automapper in order to be testable
    /// </summary>
    public class AutoMapperWrapper : IMappingProvider
    {
        private readonly IMapper mapper;

        public AutoMapperWrapper(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public TDestination MapTo<TDestination>(object source)
        {
            return this.mapper.Map<TDestination>(source);
        }

        public IQueryable<TDestination> ProjectTo<TSource, TDestination>(IQueryable<TSource> source)
        {
            return source.ProjectTo<TDestination>();
        }

        public IEnumerable<TDestination> ProjectTo<TSource, TDestination>(IEnumerable<TSource> source)
        {
            return source.AsQueryable().ProjectTo<TDestination>();
        }
    }
}
