import React from 'react';
import './Cadastrar.css';

export default function Cadastrar({ history }) {

    return (
        <div className="cadastrar-container">
            <form>
                <strong>Nome</strong>
                <input
                    placeholder="Insira seu e-mail"
                    value={''}
                    onChange={''}></input>

                <strong>Email</strong>
                <input
                    placeholder="Insira seu e-mail"
                    value={''}
                    onChange={''}></input>

                <strong>Senha</strong>
                <input
                    placeholder="Insira seu e-mail"
                    value={''}
                    onChange={''}></input>

                <strong>Confirmar senha</strong>
                <input
                    placeholder="Insira seu e-mail"
                    value={''}
                    onChange={''}></input>

                <strong>Tipo de Usuário</strong>
                <input
                    placeholder="Insira seu e-mail"
                    value={''}
                    onChange={''}></input>

                <div className="isProfessional">
                    <strong>Órgão</strong>
                    <input
                    placeholder="Insira seu e-mail"
                    value={''}
                    onChange={''}></input>

                    <strong>Estado</strong>
                    <input
                    placeholder="Insira seu e-mail"
                    value={''}
                    onChange={''}></input>

                    <strong>Registro</strong>
                    <input
                    placeholder="Insira seu e-mail"
                    value={''}
                    onChange={''}></input>
                </div>
                
            </form>
        </div>
    );
}