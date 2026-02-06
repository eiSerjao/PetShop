namespace PetShop.infraestrutura;

using PetShop.Modelos;

public class SitemaDoPetShop
{
  public String NomeDoPetShop { get; set; }
  public List<Cliente> Clientes { get; set; } = new();
  public List<Pet> Pets { get; set; } = new();


  public List<Medico> Medicos { get; set; } = new();

  public List<Consulta> Consultas { get; set; } = new();


  public SitemaDoPetShop(string nomeDoPetShop)
  {
    this.NomeDoPetShop = nomeDoPetShop;
  }

  public void ExibirMenuDeCadastro()
  {
    Console.Clear();
    Console.WriteLine("----- Bem-vindo ao " + NomeDoPetShop + " -----");
    Console.WriteLine("1. Cadastrar Consultar");
    Console.WriteLine("2. Cadastrar Cliente");
    Console.WriteLine("3. Cadastrar Pet");
    Console.WriteLine("4. Cadastrar Médico");
    Console.WriteLine("5. Exibir Médicos");
    Console.WriteLine("6. Exibir Clientes");
    Console.WriteLine("7. Exibir Pets");
    Console.WriteLine("8. Sair");
    Console.Write("Escolha uma opção: ");

    string? opcao = Console.ReadLine();
    switch (opcao)
    {
      case "1":
        CadastrarConsulta();
        break;
      case "2":
        CadastrarCliente();
        break;
      case "3":
        CadastrarPet();
        break;
      case "4":
        CadastrarMedico();
        break;
      case "5":
        ExibirMedicos();
        break;
      case "6":
        ExibirClientes();
        break;
      case "7":
        ExibirPets();
        break;
      case "8":
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
        ExibirClientes();
        string? cpfDono = ValidadorEntrada.ObterString("Digite o CPF do dono: ");

        // Procurar cliente pela CPF
        Cliente? donoPet = Clientes.FirstOrDefault(c => c.Cpf == cpfDono);

        if (donoPet != null)
        {
          novoPet.Dono = donoPet;
          donoPet.CadastrarPetParaCliente(nome, idade, raca, peso);
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
    ExibirMenuDeCadastro();
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

    Console.Clear();
    Console.WriteLine("Deseja cadastrar um pet para este cliente? (s/n): ");
    string? resposta = Console.ReadLine();

    if (resposta?.ToLower() == "s")
    {
      Console.Clear();
      Console.WriteLine("Vamos cadastrar um pet para o cliente " + nome + " " + sobrenome);

      string petNome = ValidadorEntrada.ObterString("Digite o nome do pet: ");
      int petIdade = ValidadorEntrada.ObterInteiro("Digite a idade do pet: ");
      string petRaca = ValidadorEntrada.ObterString("Digite a raça do pet: ");
      int petPeso = ValidadorEntrada.ObterInteiro("Digite o peso do pet (kg): ");
      novoCliente.CadastrarPetParaCliente(petNome, petIdade, petRaca, petPeso);
      AdicionarPet(novoCliente.Pets.Last());
      Console.WriteLine("Pet cadastrado com sucesso para o cliente!");
      Thread.Sleep(2000);
    }
    ExibirMenuDeCadastro(); // Volta para o menu principal
  }

  private void CadastrarMedico()
  {
    Console.WriteLine("----- Cadastrar Médico -----");
    string nome = ValidadorEntrada.ObterString("Digite o nome do médico: ");
    string especialidade = ValidadorEntrada.ObterString("Digite a especialidade do médico: ");
    string cpf = ValidadorEntrada.ObterString("Digite o CPF do médico: ");
    string telefone = ValidadorEntrada.ObterString("Digite o telefone do médico: ");

    Medico novoMedico = new Medico(nome, especialidade, cpf, telefone);
    Medicos.Add(novoMedico);
    Console.WriteLine("Médico cadastrado com sucesso!");
    Thread.Sleep(2000);
    ExibirMenuDeCadastro();
  }
  private void CadastrarConsulta()
  {
    Console.Clear();
    Console.WriteLine("----- Cadastrar Consulta -----");

    // Passo 1: Verificar se há pets e médicos cadastrados
    string? petNome = ValidadorEntrada.ObterString("Digite o nome do pet para a consulta: ");
    // Procurar o pet pelo nome (considerando que os nomes dos pets são únicos)
    Pet? pet = Pets.FirstOrDefault(p => p.Nome.Equals(petNome, StringComparison.OrdinalIgnoreCase));

    if (pet == null)
    {
      Console.WriteLine("❌ Pet não encontrado! Certifique-se de que o pet está cadastrado.");
      Thread.Sleep(2000);
      ExibirMenuDeCadastro();
      return;
    }

    // Passo 2: Verificar se há médicos cadastrados
    string? medicoNome = ValidadorEntrada.ObterString("Digite o nome do médico para a consulta: ");
    // Procurar o médico pelo nome (considerando que os nomes dos médicos são únicos)
    Medico? medico = Medicos.FirstOrDefault(m => m.Nome.Equals(medicoNome, StringComparison.OrdinalIgnoreCase));

    if (medico == null)
    {
      Console.WriteLine("❌ Médico não encontrado! Certifique-se de que o médico está cadastrado.");
      Thread.Sleep(2000);
      ExibirMenuDeCadastro();
      return;
    }

    // Passo 3: Obter a data da consulta
    DateTime dataConsulta = ValidadorEntrada.ObterData("Digite a data da consulta (dd/MM/yyyy): ");
    Consulta novaConsulta = new Consulta(pet, medico, dataConsulta);
    Consultas.Add(novaConsulta);
    Console.WriteLine("Consulta cadastrada com sucesso!");
    Thread.Sleep(2000);
    ExibirMenuDeCadastro();

  }

  // Método auxiliar para exibir clientes na hora de vincular um pet a um dono
  private void ExibirClientes()
  {
    Console.Clear();
    Console.WriteLine("\n--- Clientes Cadastrados ---");
    foreach (var cliente in Clientes)
    {
      Console.WriteLine($"Nome: {cliente.Nome} {cliente.Sobrenome} | CPF: {cliente.Cpf}");
    }
    Console.WriteLine("-----------------------------\n");

    Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
    Console.ReadLine();
    ExibirMenuDeCadastro();
  }

  // Método auxiliar para exibir pets cadastrados
  private void ExibirPets()
  {
    Console.Clear();
    Console.WriteLine("\n--- Pets Cadastrados ---");
    foreach (var pet in Pets)
    {
      pet.ExibirInformacoes();
      Console.WriteLine();
    }
    Console.WriteLine("-------------------------\n");

    Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
    Console.ReadLine();
    ExibirMenuDeCadastro();

  }

  private void ExibirMedicos()
  {
    Console.Clear();
    Console.WriteLine("\n--- Médicos Cadastrados ---");
    foreach (var medico in Medicos)
    {
      medico.ExibirInformacoes();
      Console.WriteLine();
    }
    Console.WriteLine("---------------------------\n");
    Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
    Console.ReadLine();
    ExibirMenuDeCadastro();
  }

  public void AdicionarPet(Pet pet)
  {
    Pets.Add(pet);
  }


}
