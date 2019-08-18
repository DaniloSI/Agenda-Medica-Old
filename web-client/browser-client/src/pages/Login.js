import React, {useState} from 'react';
import './Login.css';

import api from '../services/api';

export default function Login({history}){

  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');

  async function handleSubmit(e){
    e.preventDefault();

    const response = await api.post('/login', 
    {
        username,
        password,
    });

    const { _id } = response.data;

    history.push(`/dev/${_id}`);
  }

  return(
    <div className="login-container">        
      <form>
        <strong>E-mail:</strong>
        <input 
        placeholder="Insira seu e-mail"
        value={username}
        onChange={e => setUsername(e.target.value)}></input>
        
        <strong>Senha:</strong>
        <input 
        type="password"
        placeholder="Insira sua senha"
        value={password}
        onChange={e => setPassword(e.target.value)}></input>
        
        <div className="buttons">
          <button 
            type="submit"
            onClick={e => handleSubmit(e)}>Entrar</button>
          <button>Cadastrar</button>
        </div>
      </form>
    </div>
  );
}