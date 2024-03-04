using ApiOpenIARequests.Models.Bases;

namespace ApiOpenIARequests.Models;

public class OpenAICompletions : Jsonfyable<OpenAICompletions>
{
    public OpenAICompletions(string model = "gpt-3.5-turbo")
    {
        this.model = model;
        this.messages = new HashSet<OpenAIMessage>();
    }

    public string? model { get; set; }
    public IEnumerable<OpenAIMessage> messages { get; set; }

    public void AddMessage(bool isSystemRole, string content)
        => this.messages = this.messages.Append(new OpenAIMessage(isSystemRole, content));
}
