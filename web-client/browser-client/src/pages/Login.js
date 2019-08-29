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
    <div class="container h-100">
      <div class="row align-items-center h-100">
        <div class="col-6 mx-auto">
            <div class="card">
              <div class="card-body">
                <h5 class="card-title" style={{textAlign: 'center'}}>Login</h5>
                <form onSubmit={handleSubmit}>
                  <div class="form-group">
                    <label for="exampleInputEmail1">E-mail</label>
                    <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Ex.: pessoa@dominio.com" value={userName} onChange={e => setUsername(e.target.value)}></input>
                  </div>
                  <div class="form-group">
                    <label for="exampleInputPassword1">Senha</label>
                    <input type="password" class="form-control" id="exampleInputPassword1" placeholder="Senha" value={password} onChange={e => setPassword(e.target.value)}></input>
                  </div>
                  <div class="form-group form-check">
                    <input type="checkbox" class="form-check-input" id="exampleCheck1"></input>
                    <label class="form-check-label" for="exampleCheck1">Continuar conectado</label>
                  </div>
                  <button type="submit" class="btn btn-primary">Entrar</button>
                  <button type="button" onClick={() => history.push('/Cadastrar')} class="btn btn-secondary" style={{marginLeft: '10px'}}>Cadastrar</button>
                </form>
              </div>
          </div>
        </div>
      </div>
    </div>
  );
}