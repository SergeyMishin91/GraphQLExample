using graphQLSmp.Models;

namespace graphQLSmp.GraphQL;

public class Subscription
{
    [Subscribe]
    [Topic]
    public Platform OnPlatformAdded([EventMessage] Platform platform) => platform;
}

