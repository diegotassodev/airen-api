# AirenApi

API ASP.NET Core para gerenciamento de personagens de Airen.

## Requisitos

- .NET SDK 10.0 ou superior
- Banco de dados MySQL acessível localmente

## Configuração

1. Ajuste a string de conexão no arquivo appsettings_copy.json e tire o sufixo "_copy".
2. Garanta que o banco MySQL esteja instalado.
3. Execute as migrações:

```bash
dotnet tool install --global dotnet-ef /// FERRAMENTA
dotnet ef migrations add Airen
dotnet ef database update
```

## Compilação

```bash
dotnet restore
dotnet build
```

## Execução

```bash
dotnet run
```

A API ficará disponível em uma URL semelhante a:

- http://localhost:5027
- https://localhost:7245


## Adicionar pacotes

Para instalar todos os pacotes de dependência listados para este projeto, execute o script auxiliar:

```bash
./scripts/add-package.sh
```

Esse script adiciona automaticamente os seguintes pacotes:

- AutoMapper 12.0.1
- AutoMapper.Extensions.Microsoft.DependencyInjection 12.0.1
- Microsoft.AspNetCore.OpenApi 10.0.9
- Microsoft.EntityFrameworkCore 10.0.9
- Microsoft.EntityFrameworkCore.Proxies 10.0.9
- Microsoft.EntityFrameworkCore.SqlServer 10.0.9
- Microsoft.EntityFrameworkCore.Tools 10.0.9
- Pomelo.EntityFrameworkCore.MySql 10.0.0

## Arquitetura de pastas

```text
AirenApi/
├── Controllers/          # Endpoints da API
│   ├── PersonagemController.cs
│   └── PotentiaController.cs
├── Models/               # Entidades do domínio
│   ├── Personagem.cs
│   └── Potentia.cs
├── Data/                 # Contexto do Entity Framework e DTOs
│   ├── AirenContext.cs
│   └── DTOs/
│       ├── Personagens/
│       └── Potentias/
├── Profiles/             # Mapeamentos do AutoMapper
│   ├── PersonagemProfile.cs
│   └── PotentiaProfile.cs
├── Migrations/           # Histórico de migrações do banco
├── Properties/           # Configurações de execução
├── Program.cs            # Inicialização da aplicação
└── AirenApi.csproj       # Configuração do projeto
```
