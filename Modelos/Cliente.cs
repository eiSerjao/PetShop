namespace PetShop.Modelos;

using PetShop.infraestrutura;

public class Cliente
{
  public String Nome { get; set; }
  public string Sobrenome { get; set; }
  public string Cpf { get; set; }
  public string Telefone { get; set; }
  public List<Pet> Pets { get; set; } = new();

  public Cliente(string nome, string sobrenome, string cpf, string telefone)
  {
    this.Nome = nome;
    this.Sobrenome = sobrenome;
    this.Cpf = cpf;
    this.Telefone = telefone;
  }

  public void CadastrarPet(Pet pet)
  {
    Pets.Add(pet);
    Console.WriteLine($"✅ Pet '{pet.nome}' adicionado ao cliente {Nome}!");
  }

  public void ExibirPets()
  {
    if (Pets.Count == 0)
    {
      Console.WriteLine($"O cliente {Nome} não possui pets cadastrados.");
      return;
    }

    Console.WriteLine($"\n--- Pets de {Nome} ---");
    foreach (var pet in Pets)
    {
      pet.ExibirInformacoes();
      Console.WriteLine();
    }
  }
}
