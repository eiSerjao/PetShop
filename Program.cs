
using PetShop.Modelos;
using PetShop.infraestrutura;

// Criar 5 Clientes
Cliente cliente1 = new Cliente("João", "Silva", "123.456.789-00", "(11) 98765-4321");
Cliente cliente2 = new Cliente("Maria", "Santos", "987.654.321-00", "(21) 91234-5678");
Cliente cliente3 = new Cliente("Carlos", "Oliveira", "456.789.123-00", "(31) 99876-5432");
Cliente cliente4 = new Cliente("Ana", "Costa", "789.123.456-00", "(41) 98765-4321");
Cliente cliente5 = new Cliente("Pedro", "Almeida", "321.654.987-00", "(51) 91234-5678");

// Adicionar na Lista
List<Cliente> clientes = new List<Cliente> { cliente1, cliente2, cliente3, cliente4, cliente5 };

//Criar 7 Pets
Pet pet1 = new Pet("Rex", 5, "Labrador", 30);
Pet pet2 = new Pet("Mia", 3, "Poodle", 10);
Pet pet3 = new Pet("Toby", 2, "Bulldog", 25);
Pet pet4 = new Pet("Luna", 4, "Shih Tzu", 8);
Pet pet5 = new Pet("Max", 1, "Beagle", 15);
Pet pet6 = new Pet("Bella", 6, "Golden Retriever", 28);
Pet pet7 = new Pet("Charlie", 3, "Boxer", 22);

// Adicionar na Lista
List<Pet> pets = new List<Pet> { pet1, pet2, pet3, pet4, pet5, pet6, pet7 };

// Vincular pets aos clientes
cliente1.VincularPetExistente(pet1);
cliente1.VincularPetExistente(pet2);
cliente2.VincularPetExistente(pet3);
cliente3.VincularPetExistente(pet4);
cliente4.VincularPetExistente(pet5);

// Criar 3 Médicos
Medico medico1 = new Medico("Dr. Lucas", "Cardiologia Veterinária", "123.456.789-00", "(11) 98765-4321");
Medico medico2 = new Medico("Dra. Sofia", "Dermatologia Veterinária", "987.654.321-00", "(21) 91234-5678");
Medico medico3 = new Medico("Dr. Rafael", "Cirurgia Veterinária", "456.789.123-00", "(31) 99876-5432");

// Adicionar na Lista
List<Medico> medicos = new List<Medico> { medico1, medico2, medico3 };

SitemaDoPetShop sistema = new SitemaDoPetShop("PetCare");

// Adicionar dados ao sistema
sistema.Clientes.AddRange(clientes);
sistema.Pets.AddRange(pets);
sistema.Medicos.AddRange(medicos);

sistema.ExibirMenuDeCadastro();

// cliente1.ExibirPets();