namespace PetShop.Modelos;
using PetShop.Modelos;

public class Medico
{
  public string Nome { get; set; }
  public string Especialidade { get; set; }
  public string Telefone { get; set; }

  public List<Pet> PetsAtendidos { get; set; } = new();
  public List<Consulta> Consultas { get; set; } = new();

  public Medico(string nome, string especialidade, string telefone)
  {
    this.Nome = nome;
    this.Especialidade = especialidade;
    this.Telefone = telefone;
  }

  public void ExibirInformacoes()
  {
    Console.WriteLine($"Nome: {Nome}");
    Console.WriteLine($"Especialidade: {Especialidade}");
    Console.WriteLine($"Telefone: {Telefone}");
  }

  public void AgendarConsulta(Pet pet, DateTime data)
  {
    Consulta novaConsulta = new Consulta(pet, this, data);
    Consultas.Add(novaConsulta);
    PetsAtendidos.Add(pet);
    Console.WriteLine($"Consulta agendada para {pet.Nome} com o Dr. {Nome} no dia {data.ToShortDateString()}");
  }   

  
} 
