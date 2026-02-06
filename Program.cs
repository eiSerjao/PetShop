
using PetShop.Modelos;
using PetShop.infraestrutura;

// Criar 5 Clientes
Cliente cliente1 = new Cliente("João", "Silva", "123.456.789-00", "(11) 98765-4321");
Cliente cliente2 = new Cliente("Maria", "Santos", "987.654.321-00", "(21) 91234-5678");
Cliente cliente3 = new Cliente("Carlos", "Oliveira", "456.789.123-00", "(31) 99876-5432"); 
Cliente cliente4 = new Cliente("Ana", "Costa", "789.123.456-00", "(41) 98765-4321");
Cliente cliente5 = new Cliente("Pedro", "Almeida", "321.654.987-00", "(51) 91234-5678");

//Criar 7 Pets
Pet pet1 = new Pet("Rex", 5, "Labrador", 30);
Pet pet2 = new Pet("Mia", 3, "Poodle", 10);
Pet pet3 = new Pet("Toby", 2, "Bulldog", 25);
Pet pet4 = new Pet("Luna", 4, "Shih Tzu", 8);
Pet pet5 = new Pet("Max", 1, "Beagle", 15);
Pet pet6 = new Pet("Bella", 6, "Golden Retriever", 28);
Pet pet7 = new Pet("Charlie", 3, "Boxer", 22);


// Vincular pets aos clientes
cliente1.CadastrarPetParaCliente(pet1.Nome, pet1.Idade, pet1.Raca, pet1.Peso);
cliente1.CadastrarPetParaCliente(pet2.Nome, pet2.Idade, pet2.Raca, pet2.Peso);
cliente2.CadastrarPetParaCliente(pet3.Nome, pet3.Idade, pet3.Raca, pet3.Peso);
cliente3.CadastrarPetParaCliente(pet4.Nome, pet4.Idade, pet4.Raca, pet4.Peso);
cliente4.CadastrarPetParaCliente(pet5.Nome, pet5.Idade, pet5.Raca, pet5.Peso);



SitemaDoPetShop sistema = new SitemaDoPetShop("PetCare");
sistema.ExibirMenuDeCadastro();