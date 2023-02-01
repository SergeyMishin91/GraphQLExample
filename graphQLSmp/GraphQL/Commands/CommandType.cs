using graphQLSmp.Data;
using graphQLSmp.Models;

namespace graphQLSmp.GraphQL.Commands;

public class CommandType : ObjectType<Command>
{
    protected override void Configure(IObjectTypeDescriptor<Command> descriptor)
    {
        descriptor.Description("Represents any executable command.");

        descriptor
            .Field(c => c.Platform)
            .ResolveWith<Resolvers>(c => c.GetPlatform(default!, default!))
            .UseDbContext<AppDbContext>()
            .Description("Platform to which command belongs.");
    }

    private class Resolvers
    {
        public Platform GetPlatform([Parent] Command command, [ScopedService] AppDbContext context)
        {
            var platform = context.Platforms.FirstOrDefault(p => p.Id == command.PlatformId);

            if (platform == null)
            {
                return new Platform();
            }

            return platform;
        }
    }
}

