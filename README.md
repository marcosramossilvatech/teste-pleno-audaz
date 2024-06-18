# Projeto: Cadastro de Tarifas de Ônibus

## Descrição
Este projeto foi desenvolvido para teste para pleno. A demanda seria cadastrar uma tarifa de ônibus relacionando as entidades "Operator" e "Fare". A entidade "Fare" representa a tarifa e a entidade "Operator" representa a operadora de benefício de vale-transporte. 

Requisitos:
- Uma "Fare" só pode ser cadastrada se a operadora não possuir nenhuma tarifa ativa (Fare.Status == 1) de mesmo valor dentro de um período de 6 meses.

## Tecnologias Utilizadas
- Linguagem de Programação: C#
- Framework: .NET Core 5.0
- IDE: Visual Studio 2022

## Estrutura do Projeto no Visual Studio
O projeto está estruturado da seguinte forma dentro do Visual Studio:

- `Controllers/`
  - `FareController.cs`: Controlador para manipulação de tarifas.

- `Models/`
  - `IModel.cs`: Interface comum para todos os modelos.
  - `Operator.cs`: Define a classe Operator.
  - `Fare.cs`: Define a classe Fare.
  
- `Services/`
  - `OperatorService.cs`: Serviço para lógica relacionada à entidade Operator.
  - `FareService.cs`: Lógica de negócios para o cadastro de tarifas.
  - `Repository.cs`: Implementação genérica de um repositório.

- `Program.cs`: Ponto de entrada da aplicação.
