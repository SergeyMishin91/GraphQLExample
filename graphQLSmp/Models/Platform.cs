using System.ComponentModel.DataAnnotations;

namespace graphQLSmp.Models;

// Description moved to PlatformType.cs
//[GraphQLDescription("Represents any software or service that has a commandLine interface")]
public class Platform
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    // Description moved to PlatformType.cs
    //[GraphQLDescription("Represents a purchased license for platform")]
    public string? LicenseKey { get; set; }

    public ICollection<Command> Commands { get; set;} = new List<Command>();
}

