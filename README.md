# Agenda Médica

[![Build Status](https://travis-ci.org/DaniloSI/Agenda-Medica.svg?branch=master)](https://travis-ci.org/DaniloSI/Agenda-Medica) [![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=DaniloSI_Agenda-Medica&metric=alert_status)](https://sonarcloud.io/dashboard?id=DaniloSI_Agenda-Medica) [![Coverage](https://sonarcloud.io/api/project_badges/measure?project=DaniloSI_Agenda-Medica&metric=coverage)](https://sonarcloud.io/dashboard?id=DaniloSI_Agenda-Medica)

## Sumário
- [Sobre o Projeto](https://github.com/DaniloSI/Agenda-Medica#sobre-o-projeto)
- [Documentação do Projeto](https://github.com/DaniloSI/Agenda-Medica/wiki)
- [Documentação do Código](https://github.com/DaniloSI/Agenda-Medica/blob/master/README.md#documenta%C3%A7%C3%A3o)

## Sobre o Projeto

O projeto contido nesse repositório é referente a um aplicativo de Agenda Médica. Ao final do desenvolvimento do projeto e com a implantação do mesmo em produção, os donos de clínicas médicas e profissionais da saúde serão capazes de criar uma conta e disponibilizar agendas de horários para atendimento aos seus pacientes.

Por outro lado, os clientes serão capazes de encontrar perfis de clínicas médicas e profissionais da saúde, bem como as agendas de horários disponíveis. Além disso, também serão capazes de realizar (através do aplicativo) agendamento de horários a qualquer hora ou momento do dia.

### Principais Features:
  - Cadastrar horários de atendimento para consultas, sessões de terapia e outros.
  - Busca refinada por consultórios, profissionais da saúde, clínicas e outros.
  - Agendar Horários.
  - Efetuar pagamento de consulta, sessão de terapia e outros pelo aplicativo, de forma antecipada e durante o agendamento.

## Documentação do Código

Pré requisitos para executar a aplicação:

  - Docker.
  - Node JS.

### Download do Código Fonte

Para baixar o código fonte do projeto, basta baixar através do link de Download desse repositório ou digitar o seguinte comando no Terminal ou Prompt de Comando:

`git clone https://github.com/DaniloSI/Agenda-Medica.git`

### Execução da API

Para executar a API é necessário possuir o **Docker** instalado e o recurso **Docker Compose** habilitado. Uma vez que os requisitos estão atendidos, basta acessar a pasta AgendaMedica, que contém o arquivo *docker-compose.yml* e executar os seguintes comandos:

`docker-compose build`

`docker-compose up -d`

Uma vez que os containers estão em execução, basta abrir o navegador e acessar o seguinte link para ter acesso à documentação da API: http://localhost:8000/swagger.

Para parar a execução, basta acessar a mesma pasta supracitada e executar o seguinte comando:

`docker-compose down`

### Execução do Frontend

Para executar a aplicação de Frontend, basta acessar a pasta **browser-client** dentro da pasta **web-client** e executar o seguinte comando, para baixar e instalar as dependências:

`npm install`

Em seguida, para executar a aplicação, basta digitar o seguinte comando:

`npm start`

Após executar a aplicação de Frontend, é possível acessá-la através do link: http://localhost:3000.
