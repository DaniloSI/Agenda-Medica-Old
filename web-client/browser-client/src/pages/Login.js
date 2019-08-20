import React, { useState } from 'react';
import { login } from '../services/auth';
import api from '../services/api';

import './Login.css';

export default function Login({ history }) {

  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');

  async function handleSubmit(e) {
    e.preventDefault();

    const response = await api.post('/User/Login',
      {
        username,
        password,
      });

    const { token } = response.data;

    if(token !== null) login(token);

    history.push('/Teste');
  }

  return (
    <div className="login-container">
      <form onSubmit={handleSubmit}>
        <strong>E-mail:</strong>
        <input
          placeholder="Ex. teste@provedor.com"
          value={username}
          onChange={e => setUsername(e.target.value)}></input>

        <strong>Senha:</strong>
        <input
          type="password"
          placeholder="Ex. 123456"
          value={password}
          onChange={e => setPassword(e.target.value)}></input>

        <div className="buttons">
          <button type="submit">Entrar</button>
          <button onClick={() => history.push('/Cadastrar')}>Cadastrar</button>
        </div>
      </form>
    </div>
  );
}