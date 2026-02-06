using PetShop.Modelos;

namespace PetShop;

public class Consulta
{
  public Pet Pet { get; set; }
  public Medico Medico { get; set; }
  public DateTime Data { get; set; }

  public Consulta(Pet pet, Medico medico, DateTime data)
  {
    this.Pet = pet;
    this.Medico = medico;
    this.Data = data;
  }

  public void ExibirInformacoes()
  {
    Console.WriteLine($"Consulta para o pet {Pet.Nome} com o Dr. {Medico.Nome} no dia {Data.ToShortDateString()}");
  }
}