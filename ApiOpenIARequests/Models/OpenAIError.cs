using ApiOpenIARequests.Models.Bases;

namespace ApiOpenIARequests.Models;

public class OpenAIError : Jsonfyable<OpenAIError>
{
    public string? message { get; set; }
    public string? type { get; set; }
    public string? param { get; set; }
    public string? code { get; set; }
}
