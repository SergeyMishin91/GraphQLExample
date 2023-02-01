using graphQLSmp.Data;
using graphQLSmp.Models;

namespace graphQLSmp.GraphQL.Platforms;

public class PlatformType : ObjectType<Platform>
{
    protected override void Configure(IObjectTypeDescriptor<Platform> descriptor)
    {
        descriptor.Description("Represents any software or service that has a commandLine interface.");

        descriptor
            .Field(p => p.LicenseKey).Ignore();

        descriptor
            .Field(p => p.Commands)
            .ResolveWith<Resolvers>(p => p.GetCommands(default!, default!))
            .UseDbContext<AppDbContext>()
            .Description("List of available Platform's commands.");
    }

    private class Resolvers
    {
        public IQueryable<Command> GetCommands([Parent] Platform platform, [ScopedService] AppDbContext context)
        {
            return context.Commands
                .Where(p => p.PlatformId == platform.Id);
        }
    }
}

