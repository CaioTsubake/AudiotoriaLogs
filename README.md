# AudiotoriaLogs

# Especificações
## Back-end
C# .NET 4.7.2

## Front-end
Angular, Angular Material

## Banco de Dados
SQL Server



# Instruções

## Para inserir logs dentro da base
Dentro do projeto de Backend, execute o projeto "EntradaDeLogs" como console, colocando o path para o arquivo de logs dentro do arquivo App.config,
na variavel "pathLogs". 

## Para apontar os request do Frontend para a API
O endereço usado é o de testes. Para apontar o Frontend para onde a API está hospedada, alterar a variavel 'dominio'
dentro do arquivo 'tela-logs.service'