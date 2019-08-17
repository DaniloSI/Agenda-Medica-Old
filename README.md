# Agenda Médica

O projeto contido nesse repositório é referente a um aplicativo de Agenda Médica. Com tal aplicativo, os donos de clínicas médicas e profissionais da saúde são capazes de criar uma conta e disponibilizar agendas de horários para atendimento aos seus pacientes.

Por outro lado, os clientes são capazes de encontrar perfis de clínicas médicas e profissionais da saúde, bem como as agendas de horários disponíveis. Além disso, também são capazes de realizar (através do aplicativo) agendamento de horários a qualquer hora ou momento do dia.

**Principais Features:**
- Cadastrar horários de atendimento para consultas, sessões de terapia e outros.
- Busca refinada por consultórios, profissionais da saúde, clínicas e outros.
- Agendar Horários.
- Efetuar pagamento de consulta, sessão de terapia e outros pelo aplicativo, de forma antecipada e durante o agendamento.

# Para Desenvolvedores

## Download do Código Fonte

Para baixar o código fonte do projeto, basta baixar através do link de Download desse repositório ou digitar o seguinte comando no Terminal ou Prompt de Comando:

`git clone https://github.com/DaniloSI/Agenda-Medica.git`

## Execução da API

Para executar a API é necessário possuir o **Docker** instalado e o recurso **Docker Compose** habilitado. Uma vez que os requisitos estão atendidos, basta acessar a pasta AgendaMedica, que contém o arquivo *docker-compose.yml* e executar o seguinte comando:

`docker-compose up -d`

Uma vez que os containers estão em execução, basta abrir o navegador e acessar o seguinte link para ter acesso à documentação da API: http://localhost:8000/swagger.
