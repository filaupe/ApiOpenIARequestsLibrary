using ApiOpenIARequests.Models.Bases;
using ApiOpenIARequests.Models.Enums;

namespace ApiOpenIARequests.Models;

public class OpenAIMessage : Jsonfyable<OpenAIMessage>
{
    public OpenAIMessage() { }

    public OpenAIMessage(bool isSystemRole, string content)
    {
        this.role = isSystemRole ? nameof(EOpenAIRoles.system) : nameof(EOpenAIRoles.user);
        this.content = content;
    }

    public string? role { get; set; }
    public string? content { get; set; }
}
