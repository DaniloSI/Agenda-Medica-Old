import React, { useState } from 'react';
import DateRangePicker from '@wojtekmaj/react-daterange-picker';
import { showError } from '../../services/notifications'
import Header from './Components/Header/Index';
import HorarioSemana from './Components/HorarioSemana'

export const FormContext = React.createContext();

export default function CadastrarHorarios() {

    const [form, setForm] = useState({
        dataHoraInicio: new Date(),
        dataHoraFim: new Date(),
        horarios: [],
        profissionalId: 10
    })

    function adicionarHorario(e) {

        let existErro = false;

        let horarioInicio = document.querySelector('#cadastrarHorario #horaInicio').value;
        let horarioFim = document.querySelector('#cadastrarHorario #horaFim').value;

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

        //Pega o valor do select
        var selectedOption = document.querySelector('#cadastrarHorario #selectDiaSemana').value;

        // Verifica conflito de horário
        form.horarios
            .filter(horario => horario.diaSemana === selectedOption)
            .forEach(n => {
                if(horarioInicio > n.horaInicio && horarioInicio < n.horaFim)
                {
                    showError('Resolva o conflito de horário antes de adicionar um novo');
                    existErro = true;
                }
            })

        if (!existErro) {
            let novo_horario = {
                diaSemana: parseInt(selectedOption),
                horaInicio: horarioInicio,
                horaFim: horarioFim
            }

            form.horarios.push(novo_horario);

            setForm(
                {
                    ...form,
                    horarios: form.horarios
                }
            )            
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

                    <h2>Adicionar novos horários:</h2>

                    <div id="cadastrarHorario">
                        <select id="selectDiaSemana">
                            <option value={1}>Segunda-Feira</option>
                            <option value={2}>Terça-Feira</option>
                            <option value={3}>Quarta-Feira</option>
                            <option value={4}>Quinta-Feira</option>
                            <option value={5}>Sexta-Feira</option>
                            <option value={6}>Sábado</option>
                            <option value={0}>Domingo</option>
                        </select>

                        <label>Horário de Início:</label>
                        <input type="time" id="horaInicio" required={true}></input>
                        <label>Horário de Término:</label>
                        <input type="time" id="horaFim" required={true}></input>

                        <button onClick={
                            adicionarHorario
                        }>Adicionar</button>
                    </div>

                    <FormContext.Provider value={[form.horarios, setForm]}>

                        <div id="horariosTable">
                            <HorarioSemana tableId="table1" id={1} nome="Segunda-Feira" />

                            <HorarioSemana tableId="table2" id={2} nome="Terça-Feira" />

                            <HorarioSemana tableId="table3" id={3} nome="Quarta-Feira" />

                            <HorarioSemana tableId="table4" id={4} nome="Quinta-Feira" />

                            <HorarioSemana tableId="table5" id={5} nome="Sexta-Feira" />

                            <HorarioSemana tableId="table6" id={6} nome="Sábado" />

                            <HorarioSemana tableId="table0" id={0} nome="Domingo" />
                        </div>

                    </FormContext.Provider>

                    <button onClick={handleSubmit}>Salvar</button>
                    <button>Cancelar</button>
                </form>
            </div >
        </>
    );
}