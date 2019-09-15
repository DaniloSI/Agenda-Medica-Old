import React, { useState } from 'react';
import DateRangePicker from '@wojtekmaj/react-daterange-picker';

export default function CadastrarHorarios() {

    const [form, setForm] = useState({
        dataHoraInicio: new Date(),
        dataHoraFim: new Date(),
        horarios: [],
        profissionalId: 10
    })

    function adicionarHorario(e) {
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
    }

    function handleSubmit(e) {
        console.log(form);
        e.preventDefault();
    }

    return (
        <div>
            <h1>Cadastrar Jornada de Trabalho</h1>

            <form>
                <div>
                    <label>Nome: </label>
                    <input type="text"></input>
                    <br />

                    <label>Período de Vigência: </label>
                    <DateRangePicker onChange={data =>
                        setForm(
                            {
                                ...form,
                                dataHoraInicio: data != null ? data[0] : new Date(),
                                dataHoraFim: data != null ? data[1] : new Date()
                            }
                        )
                    }
                        value={[form.dataHoraInicio, form.dataHoraFim]}
                    ></DateRangePicker>
                </div>


                <div id="adicionarHorariosFields" className="border rounded-lg">
                    <h3>Adicionar novo horário</h3>
                    <button onClick={adicionarHorario}>Adicionar</button>
                </div>


                <div>
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
                                            <td>{horario.horaInicio}</td>
                                            <td>{horario.horaFim}</td>
                                            <td><button>Editar</button><button>Deletar</button></td>
                                        </tr>
                                    )
                                )
                            }
                        </tbody>
                    </table>
                </div>

                <button onClick={handleSubmit}>Salvar</button>
                <button>Cancelar</button>
            </form>
        </div>
    );
}