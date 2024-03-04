namespace ApiOpenIARequests.Models;

public class OpenAIUsage
{
    public int prompt_tokens { get; set; }
    public int completion_tokens { get; set; }
    public int total_tokens { get; set; }
}
