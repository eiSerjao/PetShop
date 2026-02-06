namespace PetShop.infraestrutura;

using PetShop.Modelos;

public class SitemaDoPetShop
{
  public String NomeDoPetShop { get; set; }
  public List<Cliente> Clientes { get; set; } = new();
  public List<Pet> Pets { get; set; } = new();



  public SitemaDoPetShop(string nomeDoPetShop)
  {
    this.NomeDoPetShop = nomeDoPetShop;
  }

  public void ExibirMenu()
  {
    Console.Clear();
    Console.WriteLine("----- Bem-vindo ao " + NomeDoPetShop + " -----");
    Console.WriteLine("1. Cadastrar Cliente");
    Console.WriteLine("2. Cadastrar Pet");
    Console.WriteLine("3. Exibir Clientes");
    Console.WriteLine("4. Exibir Pets");
    Console.WriteLine("5. Sair");
    Console.Write("Escolha uma opção: ");

    string? opcao = Console.ReadLine();
    switch (opcao)
    {
      case "1":
        //CadastrarCliente();
        break;
      case "2":
        CadastrarPet();
        break;
      case "3":
        //ExibirClientes();
        break;
      case "4":
        //ExibirPets();
        break;
      case "5":
        Console.WriteLine("Obrigado por usar o sistema do PetShop!");
        return;
      default:
        Console.WriteLine("Opção inválida. Tente novamente.");
        break;
    }
  }
// Metodos para cadastrar cliente, cadastrar pet, exibir clientes e exibir pets
  private void CadastrarPet()
  {
    Console.WriteLine("----- Cadastrar Pet -----");
    string nome = ValidadorEntrada.ObterString("Digite o nome do pet: ");
    int idade = ValidadorEntrada.ObterInteiro("Digite a idade do pet: ");
    string raca = ValidadorEntrada.ObterString("Digite a raça do pet: ");
    int peso = ValidadorEntrada.ObterInteiro("Digite o peso do pet (kg): ");

    // Perguntar se tem dono
    Console.Write("O pet tem dono cadastrado? (s/n): ");
    string? temDono = Console.ReadLine();

    Pet novoPet = new Pet(nome, idade, raca, peso);

    if (temDono?.ToLower() == "s")
    {
      // Exibir clientes disponíveis
      if (Clientes.Count == 0)
      {
        Console.WriteLine("❌ Nenhum cliente cadastrado no sistema!");
      }
      else
      {
        ExibirClientesParaSelecao();
        string? cpfDono = ValidadorEntrada.ObterString("Digite o CPF do dono: ");

        // Procurar cliente pela CPF
        Cliente? donoPet = Clientes.FirstOrDefault(c => c.Cpf == cpfDono);

        if (donoPet != null)
        {
          novoPet.Dono = donoPet;
          donoPet.CadastrarPet(novoPet);
          Console.WriteLine($"✅ Pet vinculado ao cliente {donoPet.Nome}!");
        }
        else
        {
          Console.WriteLine("❌ Cliente não encontrado! Pet cadastrado sem dono.");
        }
      }
    }

    Pets.Add(novoPet);
    Console.WriteLine("✅ Pet cadastrado com sucesso!");
    Thread.Sleep(2000);
    ExibirMenu();
  }

// Método auxiliar para exibir clientes na hora de vincular um pet a um dono
  private void ExibirClientesParaSelecao()
  {
    Console.WriteLine("\n--- Clientes Cadastrados ---");
    foreach (var cliente in Clientes)
    {
      Console.WriteLine($"Nome: {cliente.Nome} {cliente.Sobrenome} | CPF: {cliente.Cpf}");
    }
    Console.WriteLine();
  }
// Método para cadastrar cliente
  private void CadastrarCliente()
  {
    Console.WriteLine("----- Cadastrar Cliente -----");
    string nome = ValidadorEntrada.ObterString("Digite o nome do cliente: ");
    string sobrenome = ValidadorEntrada.ObterString("Digite o sobrenome do cliente: ");
    string cpf = ValidadorEntrada.ObterString("Digite o CPF do cliente: ");
    string telefone = ValidadorEntrada.ObterString("Digite o telefone do cliente: ");

    Cliente novoCliente = new Cliente(nome, sobrenome, cpf, telefone);
    Clientes.Add(novoCliente);
    Console.WriteLine("Cliente cadastrado com sucesso!");
    Thread.Sleep(2000); // Pausa para o usuário ler a mensagem
    ExibirMenu(); // Volta para o menu principal
  }

}
