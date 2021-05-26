<div align="center">
  <h1>Agenda Médica</h1>
</div>

<div align="center">
  <!-- Build Status -->
  <a href="https://travis-ci.org/DaniloSI/Agenda-Medica">
    <img src="https://travis-ci.org/DaniloSI/Agenda-Medica.svg?branch=master" alt="Build Status" />
  </a>
  <!-- Quality Gate Status -->
  <a href="https://sonarcloud.io/dashboard?id=DaniloSI_Agenda-Medica">
    <img src="https://sonarcloud.io/api/project_badges/measure?project=DaniloSI_Agenda-Medica&metric=alert_status" alt="Quality Gate Status" />
  </a>
  <!-- Coverage -->
  <a href="https://sonarcloud.io/dashboard?id=DaniloSI_Agenda-Medica">
    <img src="https://sonarcloud.io/api/project_badges/measure?project=DaniloSI_Agenda-Medica&metric=coverage" alt="Build Status" />
  </a>
  <br />
  <br />
</div>

> :warning: O presente projeto foi desenvolvido para fins didáticos e não está pronto para utilização em produção! O backend está hospedado no Heroku e utiliza o SQLite. Isso significa que, após 30 minutos parado, o backend entra no modo Sleeping e o banco de dados é zerado.
> 
> Link do Frotend: https://danilosi.github.io/Agenda-Medica
> 
> Link do Backend: https://agenda-medica-api.herokuapp.com/swagger
>
> Alguns usuários para testar o sistema:
>   - Paciente:
>     - Login: vanessa@teste.com
>     - Senha: Pass123
>   - Médico:
>     - Login: rodrigo@teste.com
>     - Senha: Pass123

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

Constrói e executa um projeto.

`docker-compose up`

Desativa os containers.

`docker-compose stop`

O *docker-compose.yml*, localizado no raiz, foi configurado de modo que quando executado acionara dois arquivos *dockerfile* que  acionam o serviço de API's e o back-end.

Uma vez que os containers estão em execução, basta abrir o navegador e acessar o seguinte link para ter acesso à documentação da API: http://localhost:8000/swagger.

Após executar a aplicação de back-end, é possível acessá-la através do link: http://localhost:3001.

#### Execução singular

Para a execução de somente um dos serviços, API ou back-end, é necessário navegar até sua pasta do seu arquivo .dockerfile e executar os seguintes comandos:

Para a construção da imagem.

`docker build .`

Para a execução da imagem contruida.

`docker run "imagem"`

Para desativar o container.

`docker stop "container"`
