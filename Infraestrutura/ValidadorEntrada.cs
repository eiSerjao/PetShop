namespace PetShop.infraestrutura;

public static class ValidadorEntrada
{
  /// <summary>
  /// Obtém uma string validada do usuário (não nula ou vazia)
  /// </summary>
  public static string ObterString(string mensagem)
  {
    string? entrada;

    do
    {
      Console.Write(mensagem);
      entrada = Console.ReadLine();

      if (string.IsNullOrWhiteSpace(entrada))
      {
        Console.WriteLine("❌ Erro: Campo não pode estar vazio!");
      }
    } while (string.IsNullOrWhiteSpace(entrada));

    return entrada;
  }

  /// <summary>
  /// Obtém um número inteiro validado do usuário
  /// </summary>
  public static int ObterInteiro(string mensagem)
  {
    int valor;

    while (true)
    {
      Console.Write(mensagem);
      string? entrada = Console.ReadLine();

      if (int.TryParse(entrada, out valor))
      {
        return valor;
      }

      Console.WriteLine("❌ Erro: Digite um número válido!");
    }
  }

  public static DateTime ObterData(string mensagem)
  {
    DateTime data;

    while (true)
    {
      Console.Write(mensagem);
      string? entrada = Console.ReadLine();

      if (DateTime.TryParse(entrada, out data))
      {
        return data;
      }

      Console.WriteLine("❌ Erro: Digite uma data válida (ex: 01/01/2024)!");
    }
  }

  /// <summary>
  /// Obtém um decimal validado do usuário
  /// </summary>
  public static decimal ObterDecimal(string mensagem)
  {
    decimal valor;

    while (true)
    {
      Console.Write(mensagem);
      string? entrada = Console.ReadLine();

      if (decimal.TryParse(entrada, out valor))
      {
        return valor;
      }

      Console.WriteLine("❌ Erro: Digite um valor numérico válido!");
    }
  }

  /// <summary>
  /// Valida se uma string não é nula ou vazia
  /// </summary>
  public static bool ValidarString(string? valor)
  {
    return !string.IsNullOrWhiteSpace(valor);
  }

  /// <summary>
  /// Valida se um número está dentro de um intervalo
  /// </summary>
  public static bool ValidarIntervalo(int valor, int minimo, int maximo)
  {
    return valor >= minimo && valor <= maximo;
  }
}
