namespace ApiOpenIARequests.Models;

public class Opcao
{
    public string? letra { get; set; }
    public string? enunciado { get; set; }
}

public class Questao
{
    public int numero { get; set; }
    public string? info { get; set; }
    public string? contexto { get; set; }
    public string? pergunta { get; set; }
    public List<Opcao>? opcoes { get; set; }
}

public class Resposta
{
    public int numero { get; set; }
    public string? resposta { get; set; }
    public string? explicacao { get; set; }
}

public class Prova
{
    public List<Questao>? questoes { get; set; }
    public List<Resposta>? respostas { get; set; }
}