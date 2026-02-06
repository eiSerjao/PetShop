using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using PetShop.infraestrutura;

namespace PetShop.Modelos;

public class Pet
{
  public String Nome { get; set; }
  public int Idade { get; set; }
  public string Raca { get; set; }
  public int Peso { get; set; }
  public Cliente? Dono { get; set; }
  

  public Pet(string nome, int idade, string raca, int peso)
  {
    this.Nome = nome;
    this.Idade = idade;
    this.Raca = raca;
    this.Peso = peso;
    this.Dono = null;
  }

  public Pet(string nome, int idade, string raca, int peso, Cliente dono)
  {
    this.Nome = nome;
    this.Idade = idade;
    this.Raca = raca;
    this.Peso = peso;
    this.Dono = dono;
  }

  public void ExibirInformacoes()
  {
    Console.WriteLine($"Nome: {Nome}");
    Console.WriteLine($"Idade: {Idade} anos");
    Console.WriteLine($"Raça: {Raca}");
    Console.WriteLine($"Peso: {Peso} kg");
    
    if (Dono != null)
    {
      Console.WriteLine($"Dono: {Dono.Nome} {Dono.Sobrenome}");
    }
    else
    {
      Console.WriteLine("Dono: Sem dono cadastrado");
    }
  }
}

