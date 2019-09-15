import React, { useState } from 'react';


export default function CadastrarHorarios() {

    const [form, setForm] = useState({
        dataHoraInicio: "14/02/2020",
        dataHoraFim: "14/02/2021",
        horarios: [],
        profissionalId: 10
    })

    function handleSubmit(e) {

    }

    return (
        <div>
            <h1>Cadastrar Jornada de Trabalho</h1>
            <form>
                <div>
                    <span>Nome: </span>
                    <span>Data de Início: </span> <span>Data de Término: </span>
                </div>

                <div>
                    <button>Adicionar</button>
                    <table className="table table-borderless">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Dia da Semana</th>
                                <th>Ciclo de Início</th>
                                <th>Ciclo de Término</th>
                                <th>Açoes</th>
                            </tr>
                        </thead>
                        <tbody>
                            {
                                form.horarios.map(
                                    horario => (
                                        <tr>
                                            <td>{horario.diaSemana}</td>
                                            <td>Segunda Feira</td>
                                            <td>13:00</td>
                                            <td>19:00</td>
                                            <td><button>Editar</button><button>Deletar</button></td>
                                        </tr>
                                    )
                                )
                            }
                        </tbody>
                    </table>
                </div>

                <button onClick={e => {

                    form.horarios.push({
                        diaSemana: 0,
                        horaInicio: "teste",
                        horaFim: "teste 2"
                    });

                    setForm(
                    {
                        ...form,
                        horarios: form.horarios
                    });
                    e.preventDefault();
                }}>Salvar</button>
                <button>Cancelar</button>
            </form>

        </div>
    );
}