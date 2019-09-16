import React, { useState } from 'react';
import api from '../services/api';
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";

import * as Notifications from '../services/notifications';

export default function AgendamentoHorario({ history }) {

  const [email, setEmail] = useState('');
  const profissional = {
      Nome: 'Fulano',
      SobreNome: ' de Tal'
  };

  const especialidade = {
      Nome: 'Clínico Geral'
  };

  const [startDate, setStartDate] = useState(new Date());

  async function handleSubmit(e) {
    e.preventDefault();

    const response = await api.post('/User/Login',
      {
        email,
      });

    history.push('/Home');
  }

  return (
    <div className="container h-100">
        <div className="d-flex bd-highlight pt-5 justify-content-center">
            <h2>Agendamento de Horario</h2>
        </div>
        <div className="d-flex bd-highlight justify-content-center">
            <p><strong>Especialidade:</strong> {especialidade.Nome}</p>
        </div>
        <div className="d-flex bd-highlight justify-content-center">
            <p><strong>Especialidade:</strong> {especialidade.Nome}</p>
        </div>

        <hr />
        <form>
            <div className="form-group row">
                <div className="col-1">
                    <label htmlFor="data">Data</label>
                </div>
                <div className="col-4">
                    <DatePicker className="form-control" selected={startDate} onChange={date => setStartDate(date)} id="data" style={{width: '100%'}} />
                </div>
            </div>
            <div className="form-group row">
                <div className="col-1">
                    <label htmlFor="horario">Horário</label>
                </div>
                <div className="col-4">
                    <select className="custom-select my-1 mr-sm-2" id="horario">
                        <option defaultValue>Choose...</option>
                        <option value="1">One</option>
                        <option value="2">Two</option>
                        <option value="3">Three</option>
                    </select>
                </div>
            </div>
        </form>
    </div>
  );
}