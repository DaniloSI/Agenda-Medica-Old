import React, { useState } from 'react';
import { login } from '../services/auth';
import api from '../services/api';

export default function Login({ history }) {

  const [userName, setUsername] = useState('');
  const [password, setPassword] = useState('');

  async function handleSubmit(e) {
    e.preventDefault();

    const response = await api.post('/User/Login',
      {
        userName,
        password,
      });

    const { token } = response.data;

    if(token !== null) login(token);

    history.push('/Home');
  }

  return (
    <div className="container h-100">
      <div className="row align-items-center h-100">
        <div className="col-6 mx-auto">
            <div className="card">
              <div className="card-body">
                <h5 className="card-title" style={{textAlign: 'center'}}>Login</h5>
                <form onSubmit={handleSubmit}>
                  <div className="form-group">
                    <label htmlFor="exampleInputEmail1">E-mail</label>
                    <input type="email" className="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Ex.: pessoa@dominio.com" value={userName} onChange={e => setUsername(e.target.value)}></input>
                  </div>
                  <div className="form-group">
                    <label htmlFor="exampleInputPassword1">Senha</label>
                    <input type="password" className="form-control" id="exampleInputPassword1" placeholder="Senha" value={password} onChange={e => setPassword(e.target.value)}></input>
                  </div>
                  <div className="form-group form-check">
                    <input type="checkbox" className="form-check-input" id="exampleCheck1"></input>
                    <label className="form-check-label" htmlFor="exampleCheck1">Continuar conectado</label>
                  </div>
                  <button type="submit" className="btn btn-primary">Entrar</button>
                  <button type="button" onClick={() => history.push('/Cadastrar')} className="btn btn-secondary" style={{marginLeft: '10px'}}>Cadastrar</button>
                </form>
              </div>
          </div>
        </div>
      </div>
    </div>
  );
}