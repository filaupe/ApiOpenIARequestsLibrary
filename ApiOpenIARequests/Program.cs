//async Task<string> Requisicao_API(string pedido_de_prova)
//{
//    await Task.Delay(3000);
//    return "prova";
//}
//var hora_inicio = DateTime.Now;
//var pedidos_de_provas = new List<string>
//{
//    "prova1",
//    "prova2",
//    "prova3",
//    "prova4",
//    "prova5",
//    "prova6",
//};
//var lista_de_resultados = new List<Task<string>>(); //Lista de requisições
//Parallel.ForEach(pedidos_de_provas, pedido =>
//{
//    var requisicao = Requisicao_API(pedido);
//    lista_de_resultados.Add(requisicao);
//});
//await Task.WhenAll(lista_de_resultados); //Aguarda todas as requisições serem terminadas

//var hora_fim = DateTime.Now.Subtract(hora_inicio).Microseconds;
//Console.WriteLine($"Requisições feitas em {hora_fim} segundos.");

using ApiOpenIARequests.Extensions;
using ApiOpenIARequests.Models;
using ApiOpenIARequests.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using System.Text.Json;

string apiKey = ApiOpenIARequests.Properties.ApiKeys.apiKey2;
string apiEndpoint = "https://api.openai.com/v1/chat/completions";

var requestBody = new OpenAICompletions("gpt-3.5-turbo");

requestBody.AddMessage(true, "Você é um gerador de provas para todos os níveis de ensino, todos os anos e todas as disciplinas, utilizando o formato json para emitir suas provas, sempre de forma minificada sem nenhuma formatação de quebra de linha seguindo a risca as regras para um arquivo no formato json.");
requestBody.AddMessage(false, ApiOpenIARequests.Properties.ApiKeys.json);

var httpContent = requestBody.ToStringContent(Encoding.UTF8, "application/json");

try
{
    #region frescuras
    var services = new ServiceCollection();
    services.AddHttpClient();
    var serviceProvider = services.BuildServiceProvider();
    var httpClientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();
    #endregion

    var clientRepository = new HttpClientRepository(httpClientFactory);

    clientRepository.InstanceClient("OpenAI-Api");
    clientRepository.AddHeaders(new Dictionary<string, string>
    {
        {"Authorization", $"Bearer {apiKey}"},
    });

    var inicial = DateTime.Now;
    var response = await clientRepository.GetContentLengthAsync(apiEndpoint, httpContent);
    string text = response.ToOpenAIResponse()?.ToString() ?? String.Empty;
    Console.WriteLine(text);
    Console.WriteLine(DateTime.Now.Subtract(inicial).Seconds);
    var prova = JsonSerializer.Deserialize<Prova>(text);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
