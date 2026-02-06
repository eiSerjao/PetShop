namespace PetShop;

public class VerificadorNulo
{
  // método para verificar se uma string é nula ou vazia, e lançar uma exceção com uma mensagem personalizada
  public static string VerificarStringNula(string? valor, string mensagemErro)
  {
    // Se o valor for nulo ou vazio, lança uma exceção com a mensagem de erro fornecida
    if (string.IsNullOrEmpty(valor)) 
    {
      throw new ArgumentException(mensagemErro);
    }
    return valor;
  }

  public static int VerificarIntNulo(string? valor, string mensagemErro)
  {
    // Se o valor for nulo, vazio ou não puder ser convertido para inteiro, lança uma exceção com a mensagem de erro fornecida
    if (string.IsNullOrEmpty(valor) || !int.TryParse(valor, out int resultado))
    {
      throw new ArgumentException(mensagemErro);
    }
    return resultado;
  }
  
}
