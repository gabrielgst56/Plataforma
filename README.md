# Plataforma


Olá, meu nome é Gabriel Augusto Silva e Silva e esse repositório contém o meu trabalho de conclusão de curso apresentado como exigência parcial para obtenção do diploma de Tecnologia em Análise e Desenvolvimento de Sistemas do Instituto Federal de Educação, Ciência e Tecnologia de São Paulo, Campus Campinas.


# Dependências técnicas

Para a instalação do projeto você necessitará das seguintes ferramentas:


- Visual Studio 2017 para a execução da API em C#, você deve executa-lá em modo debug, sem a utilização de IIS. 

- Postgres para a instalação de um banco de dados Postgres local. 

- PgAdmin ou outra ferramenta para acesso ao banco e execução de queries. Os scripts para a criação do banco estão localizados dentro da solução no Visual Studio e a connection string para acesso do banco pode ser alterada no arquivo appsettings.json.

- Postman para a realização de requisições para a criação do Chatbot na API em C#.

- NPM e alguma IDE frontend para a execução da API em node. Antes da execução as dependências no package.json devem ser instaladas.


# Depedências Discord

Para o funcionamento do Chatbot, é necessário informarmos o token do Discord ao NodeJs.

Esse token pode ser recebido seguindo o tutorial:

https://github.com/reactiflux/discord-irc/wiki/Creating-a-discord-bot-&-getting-a-token
