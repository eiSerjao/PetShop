namespace PetShop.Modelos;

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

  public void CadastrarPetParaCliente(String nome, int idade, string raca, int peso)
  {
    Pet pet = new Pet(nome, idade, raca, peso);
    pet.Dono = this;
    Pets.Add(pet);
    Console.Clear();
    Console.WriteLine($"Pet {nome} cadastrado com sucesso para o cliente {Nome} {Sobrenome}!");
  }

  public void VincularPetExistente(Pet pet)
  {
    pet.Dono = this;
    Pets.Add(pet);
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
