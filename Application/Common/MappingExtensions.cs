using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
namespace Application.Common.Mappings
{
    [ExcludeFromCodeCoverage]
    public static class MappingExtensions
    {
        public static Task<List<TDestination>> ProjectToListAsync<TDestination>(this IQueryable queryable, IConfigurationProvider configuration) where TDestination : class
        {
            return queryable.ProjectTo<TDestination>(configuration).AsNoTracking().ToListAsync();
        }
    }
}