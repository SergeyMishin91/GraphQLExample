using graphQLSmp.Data;
using graphQLSmp.Models;

namespace graphQLSmp.GraphQL;

public class Query
{
    [UseDbContext(typeof(AppDbContext))] // for getting multiple data in one request, works with AddPooledDbContextFactory in DI (DbContext)
    [UseProjection] // for graph child objects
    [UseFiltering]
    [UseSorting]
    public IQueryable<Platform> GetPlatform([ScopedService] AppDbContext context)
    {
        return context.Platforms;
    }

    [UseDbContext(typeof(AppDbContext))]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Command> GetCommand([ScopedService] AppDbContext context)
    {
        return context.Commands;
    }
}

