# Agenda Médica

[![Build Status](https://travis-ci.org/DaniloSI/Agenda-Medica.svg?branch=master)](https://travis-ci.org/DaniloSI/Agenda-Medica) [![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=DaniloSI_Agenda-Medica&metric=alert_status)](https://sonarcloud.io/dashboard?id=DaniloSI_Agenda-Medica) [![Coverage](https://sonarcloud.io/api/project_badges/measure?project=DaniloSI_Agenda-Medica&metric=coverage)](https://sonarcloud.io/dashboard?id=DaniloSI_Agenda-Medica)

## Sumário
- [Sobre o Projeto](https://github.com/DaniloSI/Agenda-Medica#sobre-o-projeto)
  - [Principais Features](https://github.com/DaniloSI/Agenda-Medica#principais-features)
- [Documentação do Código](https://github.com/DaniloSI/Agenda-Medica#documenta%C3%A7%C3%A3o-do-c%C3%B3digo)
  - [Download do Código Fonte](https://github.com/DaniloSI/Agenda-Medica#download-do-c%C3%B3digo-fonte)
  - [Execução da API](https://github.com/DaniloSI/Agenda-Medica#execu%C3%A7%C3%A3o-da-api)
  - [Execução do Frontend](https://github.com/DaniloSI/Agenda-Medica#execu%C3%A7%C3%A3o-do-frontend)
- [Documentação do Projeto](https://github.com/DaniloSI/Agenda-Medica/wiki)

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

### Execução 

Utilizando o Docker Compose foi possivel configurar para que tanto as API's quanto o back-end sejam executados e parados  simultaneamente com um comando na raiz:

`docker-compose up -d --build`

`docker-compose up stop`

O *docker-compose.yml*, localizado no raiz, foi configurado de modo que quando executado acionara dois arquivos *dockerfile* que  acionam o serviço de API's e o back-end.

Uma vez que os containers estão em execução, basta abrir o navegador e acessar o seguinte link para ter acesso à documentação da API: http://localhost:8000/swagger.

Após executar a aplicação de back-end, é possível acessá-la através do link: http://localhost:3000.

#### Execução singular

Para a execução de somente um serviço(API ou back-end) é necessário navegar até sua pasta e executar os seguintes comandos:

`docker build .`

``
