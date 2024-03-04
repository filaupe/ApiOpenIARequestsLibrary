using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace ApiOpenIARequests.Models.Bases;

public class Jsonfyable<TModel> where TModel : class
{
    private TModel Model => (TModel)this.MemberwiseClone();

    public string ToJson(JsonSerializerOptions? options = null) => JsonSerializer.Serialize(Model, options);
    public void ToJson(JsonTypeInfo<TModel> jsonTypeInfo) => JsonSerializer.Serialize(Model, jsonTypeInfo);
    public void ToJson(Stream utf8Json, JsonSerializerOptions? options = null) => JsonSerializer.Serialize(utf8Json, Model, options);
    public void ToJson(Stream utf8Json, JsonTypeInfo<TModel> jsonTypeInfo) => JsonSerializer.Serialize(utf8Json, Model, jsonTypeInfo);
    public void ToJson(Utf8JsonWriter writer, JsonTypeInfo<TModel> jsonTypeInfo) => JsonSerializer.Serialize(writer, Model, jsonTypeInfo);
    public void ToJson(Utf8JsonWriter writer, JsonSerializerOptions? options = null) => JsonSerializer.Serialize(writer, Model, options);

    public StringContent ToStringContent() => new (this.ToJson());
    public StringContent ToStringContent(Encoding? encoding) => new (this.ToJson(), encoding);
    public StringContent ToStringContent(MediaTypeHeaderValue mediaType) => new (this.ToJson(), mediaType);
    public StringContent ToStringContent(Encoding? encoding, string mediaType = "application/json") => new (this.ToJson(), encoding, mediaType);
    public StringContent ToStringContent(Encoding? encoding, MediaTypeHeaderValue mediaType) => new (this.ToJson(), encoding, mediaType);
}
