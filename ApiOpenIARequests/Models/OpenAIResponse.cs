using ApiOpenIARequests.Models.Bases;

namespace ApiOpenIARequests.Models;

public class OpenAIResponse : Jsonfyable<OpenAIMessage>
{
    public string? id { get; set; }
    public string? @object { get; set; }
    public long created { get; set; }
    public string? model { get; set; }
    public OpenAIChoice[]? choices { get; set; }
    public OpenAIError? error { get; set; }
    public OpenAIUsage? usage { get; set; }
    public string? system_fingerprint { get; set; }

    public override string? ToString()
    {
        if (error != null) return error.message;
        return this.choices?.FirstOrDefault()?.message?.content;
    }
}
