🚀 Projeto [XpTO]

📌 Descrição

Este é um projeto desenvolvido como parte de um processo seletivo, utilizando C# no backend e Angular no frontend. A aplicação consiste em uma solução que possibilita os clientes do restaurante a

tirarem pedidos de café da manhã e almoço com integração direta à cozinha.

🛠 Tecnologias Utilizadas

Backend: C# (.NET 8), Microsoft.Data.SqlClient

Frontend: Angular 17

Banco de Dados: SQL Server

IDE Backend: Visual Studio 2022

IDE Banco: Azure Data Studio

Gerenciador de Versão: Git + GitHub

📋 Requisitos

Antes de iniciar a execução do projeto, certifique-se de ter instalado:

Baixar Visual Studio 2022

Baixar .NET 8 SDK

Baixar Node.js (necessário para instalar Angular CLI)

Instalar Angular CLI via terminal:

npm install -g @angular/cli

Baixar Azure Data Studio

Baixar SQL Server Configuration Manager

Clonar o repositório:

git clone https://github.com/brunodraw123

📦 Configuração do Banco de Dados

Abrir o SQL Server Configuration Manager e iniciar a instância do SQL Server.

Abrir o Azure Data Studio e conectar-se ao SQL Server.

Executar o script script_database.sql localizado na pasta scripts/ para criar a base de dados e tabelas necessárias.

▶️ Executando a Aplicação

Backend

Abrir o Visual Studio 2022.

Abrir a solução (.sln) do projeto backend.

Restaurar pacotes NuGet (caso necessário):

dotnet restore

Executar a aplicação em modo Debug ou Release pelo Visual Studio.

Frontend

Navegar até a pasta do frontend:

cd xpto2.client

Instalar as dependências:

npm install

Iniciar a aplicação Angular:

ng serve --open

⚠️ Observações Importantes

A connection string está definida diretamente no código. Certifique-se de alterar conforme necessário para apontar para sua instância do SQL Server.

Todos os passos acima são obrigatórios para garantir a correta execução do sistema.

🤝 Contribuição

Caso encontre problemas ou tenha sugestões, sinta-se à vontade para abrir uma issue no repositório.

📧 Contato

Dúvidas? Entre em contato comigo via e-mail [brunodraw123@gmail.com] ou pelo GitHub mesmo.
