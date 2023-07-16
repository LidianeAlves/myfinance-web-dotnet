# lollerrmnsmyfinance-web-dotnet


# myfinance-web-dotnet
Descrição do Projeto

O projeto chama-se My Finance e foi criado para fazer a gestão financeira dos gastos, com entradas e saídas.
Nele é possível adicionar, editar ou excluir contas e fazer a gestão pelas transações e categorias das contas.

Arquitetura utilizada
MVC - Model View Controller com camadas Application, Services 

Tecnologias
ASP.NET MVC (.NET 7) utilizando o VSCode
Banco de dados MySQL Server	
## Autores

- [@Elias Melo Neves Silva](https://www.github.com/lollerrmns)

- [@Flaísa Carolina de Souza Barbosa](https://www.github.com/Flaisa)

- [@Lidiane Alves Pereira](https://www.github.com/LidianeAlves)


## Deploy

Para fazer o deploy desse projeto siga o passo-a-passo abaixo:


1 Clonar o repositório 

2 Instalar os programas: 
- [MySQL Server](https://www.mysql.com/downloads/)
- [Vs code](https://code.visualstudio.com/download)
- [.Net 7](https://dotnet.microsoft.com/pt-br/download)

3 Executar o script de criação do banco de dados (SQL creation file);

4 Inclusão da biblioteca do mySQL no .Net 
    ```dotnet add package Pomelo.EntityFrameworkCore.MySql```

5 Inclusão da biblioteca do Entity no .Net
     ```dotnet add package microsoft.entityframeworkcore.mysql```

6 Acessar a pasta do projeto 
    ```cd myfinance-web-dotnet```
    
7 Executar os comandos 

```dotnet build```

```donet run```



