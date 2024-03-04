using ApiOpenIARequests.Models.Bases;

namespace ApiOpenIARequests.Models;

public class OpenAIChoice : Jsonfyable<OpenAIChoice>
{
    public int index { get; set; }
    public OpenAIMessage? message { get; set; }
    //public double? logprobs { get; set; }
    public string? finish_reason { get; set; }
}
