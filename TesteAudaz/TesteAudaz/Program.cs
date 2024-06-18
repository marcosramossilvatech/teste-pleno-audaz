using TesteAudaz.Controller;
using TesteAudaz.Models;
using TesteAudaz.Services;

var repository = new Repository();
var operatorService = new OperatorService(repository);
var fareService = new FareService(repository);

var fareController = new FareController(operatorService, fareService);

while (true)
{
    ExibirMenu();


    string escolha = Console.ReadLine();

    switch (escolha)
    {
        case "1":
            AdicionarOperadora(fareController);
            break;
        case "2":
            AdicionarTarifa(fareController);
            break;
        case "3":
            ListarOperadoras(fareController);
            break;
        case "4":
            ListarFares(fareController);
            break;
        case "5":
            Console.WriteLine("Saindo...");
            return;
        default:
            Console.WriteLine("Opção inválida! Tente novamente.");
            break;
    }

    Console.WriteLine("Pressione qualquer tecla para continuar...");
    Console.ReadKey();
}

void ExibirMenu()
{
    Console.Clear();
    Console.WriteLine("=== Menu Principal ===");
    Console.WriteLine("1. Adicionar Operadora 'Exemplos: OP01, OP02, OP03...'");
    Console.WriteLine("2. Adicionar tarifa");
    Console.WriteLine("3. Listar as Operadoras");
    Console.WriteLine("4. Listar as Tarifas");
    Console.WriteLine("5. Sair");
    Console.Write("Escolha uma opção: ");
}

void ListarFares(FareController fareController)
{
    var fares = fareController.GetFares();

    if (fares.Any())
    {
        Console.WriteLine("Fares cadastrada:");
        Console.WriteLine("Oper - Valor -   Status");
        foreach (var item in fares)
            Console.WriteLine($"{item.CodeOperador} - R$ {item.Value} - {item.Status}");
    }
    else
        Console.WriteLine("Não existe Fares cadastradas!");

}

void ListarOperadoras(FareController fareController)
{
    var operadoras = fareController.GetOperatoras();

    if (operadoras.Any())
    {
        foreach (var item in operadoras)
            Console.WriteLine(item.Code);
    }
    else
        Console.WriteLine("Não existe Operadoras cadastrada!");

}

void AdicionarOperadora(FareController fareController)
{
    var operadoras = fareController.GetOperatoras();
    var operatorEntity = new Operator { Code = $"OP0{operadoras.Count + 1}" };
    fareController.CreateOperator(operatorEntity);
    Console.WriteLine("Operadora criada com sucesso!");
}

void AdicionarTarifa(FareController fareController)
{
    var fare = new Fare();
    fare.Id = Guid.NewGuid();

    Console.WriteLine("Informe o valor da tarifa a ser cadastrada:");
    var fareValueInput = Console.ReadLine();
    fare.Value = decimal.Parse(fareValueInput.Replace('.', ','));

    Console.WriteLine("Informe o código da operadora para a tarifa:");
    Console.WriteLine("Exemplos: OP01, OP02, OP03...");
    var operatorCodeInput = Console.ReadLine();

    var sucesso = fareController.CreateFare(fare, operatorCodeInput);

    if (sucesso)
        Console.WriteLine("Tarifa cadastrada com sucesso!");
    else
        Console.WriteLine("Não é possível cadastrar a tarifa. Já existe uma tarifa ativa de mesmo valor nos últimos 6 meses.");
}