using System.ComponentModel.DataAnnotations;

namespace graphQLSmp.Models;

[GraphQLDescription("Represents any software or service that has a commandLine interface")]
public class Command
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string HowTo { get; set; }

    [Required]
    public string CommandLine { get; set; }

    [Required]
    public int PlatformId { get; set; }

    public Platform Platform { get; set; }
}

