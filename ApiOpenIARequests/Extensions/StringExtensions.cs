using ApiOpenIARequests.Models;
using System.Text.Json;

namespace ApiOpenIARequests.Extensions;

public static class StringExtensions
{
    public static OpenAIResponse? ToOpenAIResponse(this string responseContent) => JsonSerializer.Deserialize<OpenAIResponse>(responseContent);
}
