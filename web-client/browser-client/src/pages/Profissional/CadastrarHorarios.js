import React, { useState, useEffect } from 'react';
import DateRangePicker from '@wojtekmaj/react-daterange-picker';
import { showSuccess, showError } from '../../services/notifications'
import Header from './Components/Header/Index';

export default function CadastrarHorarios() {

    const [form, setForm] = useState({
        dataHoraInicio: new Date(),
        dataHoraFim: new Date(),
        horarios: [],
        profissionalId: 10
    })

    useEffect(() => {
        const selector = document.querySelectorAll('tbody tr');

        for (var i = 0; i < selector.length; i++) {
            selector.deleteRow(i);
        }

    }, [form.horarios])

    function adicionarHorario(e) {

        let existErro = false;

        let horarioInicio = document.querySelector('#adicionarHorariosFields #horaInicioAtendimento').value;
        let horarioFim = document.querySelector('#adicionarHorariosFields #horaFimAtendimento').value;
        let diasMarcados = [];

        //Valida Horário
        if (horarioInicio === "") {
            showError('Horário de Início não pode ser vazio.');
            existErro = true;
        }

        if (horarioFim === "") {
            showError('Horário de Término não pode ser vazio.');
            existErro = true;
        }

        if (horarioInicio > horarioFim) {
            showError('Horário de fim deve ser maior que o inicial');
            existErro = true;
        }


        //Pega o valor dos checkboxs marcados
        document.querySelectorAll('#adicionarHorariosFields .form-check input').forEach(val => { if (val.checked === true) diasMarcados.push(val.value) });

        //Valida Checkbox
        if (diasMarcados.length === 0) {
            showError('Selecione pelo menos 1 dia da semana');
            e.preventDefault();
            return;
        }

        if (!existErro) {
            diasMarcados.forEach(n => {
                form.horarios.push({
                    diaSemana: n,
                    horaInicio: horarioInicio,
                    horaFim: horarioFim
                });
            })

            setForm(
                {
                    ...form,
                    horarios: form.horarios
                });
        }

        e.preventDefault();
    }

    function handleSubmit(e) {
        console.log(JSON.stringify(form));
        e.preventDefault();
    }

    return (
        <>
            <Header />
            <div>
                <h1>Cadastrar Jornada de Trabalho</h1>

                <form>
                    <div className="form-group">
                        <label>Nome: </label>
                        <input type="text" className="form-control"></input>

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
                            minDate={new Date()}
                        ></DateRangePicker>
                    </div>


                    <div id="adicionarHorariosFields" className="form-group border rounded-lg">
                        <h3>Adicionar novo horário</h3>

                        <label><strong>Dias da Semana:</strong></label>

                        <div className="form-check form-check-inline">
                            <input className="form-check-input position-static" type="checkbox" id="blankCheckbox0" value="0" />
                            <label className="form-check-label" htmlFor="blankCheckbox0">Domingo</label>
                        </div>

                        <div className="form-check form-check-inline">
                            <input className="form-check-input position-static" type="checkbox" id="blankCheckbox1" value="1" />
                            <label className="form-check-label" htmlFor="blankCheckbox1">Segunda-Feira</label>
                        </div>

                        <div className="form-check form-check-inline">
                            <input className="form-check-input position-static" type="checkbox" id="blankCheckbox2" value="2" />
                            <label className="form-check-label" htmlFor="blankCheckbox2">Terça-Feira</label>
                        </div>

                        <div className="form-check form-check-inline">
                            <input className="form-check-input position-static" type="checkbox" id="blankCheckbox3" value="3" />
                            <label className="form-check-label" htmlFor="blankCheckbox3">Quarta-Feira</label>
                        </div>

                        <div className="form-check form-check-inline">
                            <input className="form-check-input position-static" type="checkbox" id="blankCheckbox4" value="4" />
                            <label className="form-check-label" htmlFor="blankCheckbox4">Quinta-Feira</label>
                        </div>

                        <div className="form-check form-check-inline">
                            <input className="form-check-input position-static" type="checkbox" id="blankCheckbox5" value="5" />
                            <label className="form-check-label" htmlFor="blankCheckbox5">Sexta-Feira</label>
                        </div>

                        <div className="form-check form-check-inline">
                            <input className="form-check-input position-static" type="checkbox" id="blankCheckbox6" value="6" />
                            <label className="form-check-label" htmlFor="blankCheckbox6">Sábado</label>
                        </div>

                        <div>
                            <label>Horário de Início:</label>
                            <input type="time" id="horaInicioAtendimento" required={true}></input>
                            <label>Horário de Término:</label>
                            <input type="time" id="horaFimAtendimento" required={true}></input>
                            <button onClick={adicionarHorario}>Adicionar</button>
                        </div>
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
                                                <td>À definir</td>
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
            </div >
        </>
    );
}