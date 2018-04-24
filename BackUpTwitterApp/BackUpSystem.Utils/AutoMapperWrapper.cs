using AutoMapper;
using AutoMapper.QueryableExtensions;
using BackUpSystem.Data.Models;
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

        public IQueryable<TDestination> ProjectTo<TDestination>(IQueryable<object> source)
        {
            return source.ProjectTo<TDestination>();
        }

        public IEnumerable<TDestination> ProjectTo<TDestination>(IEnumerable<TwitterAccount> source)
        {
            return source.AsQueryable().ProjectTo<TDestination>();
        }


        public IEnumerable<TDestination> ProjectTo<TDestination>(IEnumerable<Tweet> source)
        {
            return source.AsQueryable().ProjectTo<TDestination>();
        }
    }
}
