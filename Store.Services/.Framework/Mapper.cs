using System.Collections.Generic;
using AutoMapper;

namespace Store.Services.Framework
{
    /// <summary>Base class for all object-to-object mapper classes.</summary>
    /// <seealso cref="Profile" />
    public abstract class Mapper : Profile
    {
    }

    /// <summary>Base class that handles the most common mappings from a given source to a destination.</summary>
    /// <typeparam name="TSource">The type of the source object.</typeparam>
    /// <typeparam name="TDest">The type of the destination object.</typeparam>
    /// <seealso cref="Profile" />
    public abstract class Mapper<TSource, TDest> : Mapper
    {
        protected Mapper()
        {
            CreateMap();
        }

        protected IMappingExpression<TSource, TDest> CreateMap()
        {
            return CreateMap<TSource, TDest>();
        }

        public static TDest Map(TSource source)
        {
            return AutoMapper.Mapper.Map<TDest>(source);
        }

        public static TDest Map(TSource source, TDest dest)
        {
            AutoMapper.Mapper.Map(source, dest);

            return dest;
        }

        public static List<TDest> Map(IEnumerable<TSource> source)
        {
            return AutoMapper.Mapper.Map<IEnumerable<TSource>, List<TDest>>(source);
        }
    }
}
