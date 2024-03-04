using ApiOpenIARequests.Extensions;
using System;

namespace ApiOpenIARequests.Repositories;

public class HttpClientRepository
{
    private readonly IHttpClientFactory _httpClientFactory;
    private HttpClient? _client;

    public HttpClientRepository(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    private void InitialVerification(string url)
    {
        if (_client is null) throw new Exception("O cliente não foi instanciado");
        if (string.IsNullOrWhiteSpace(url)) throw new Exception("O url está vazio");
    }
    
    private static async Task FinaleVerification(HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
        {
            var status = response.StatusCode;
            var defaultMessage = $"{status}, erro ({(int)status}):";
            var message = await response.Content.ReadAsStringAsync();
            if (String.IsNullOrWhiteSpace(message))
                throw new Exception($"{defaultMessage} Falha na requisição");
            throw new Exception($"{defaultMessage} {message.ToOpenAIResponse()}");
        }
    }

    public void InstanceClient() => _client = _httpClientFactory.CreateClient();
    public void InstanceClient(string name) => _client = _httpClientFactory.CreateClient(name);

    public void AddHeaders(Dictionary<string, string> headers)
    {
        foreach (var header in headers)
            _client?.DefaultRequestHeaders.Add(header.Key, header.Value);
    }

    public async Task<string> RequestPostAsync(string url, StringContent request)
    {
        this.InitialVerification(url);
        using var response = await _client!.PostAsync(url, request);        
        await FinaleVerification(response);
        return await response.Content.ReadAsStringAsync();
    }
}
