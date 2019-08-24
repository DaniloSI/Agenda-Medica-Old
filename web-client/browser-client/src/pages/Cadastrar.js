import React from 'react';
// import './Cadastrar.css';

export default function Cadastrar({ history }) {

    return (
        <div class="container h-100">
            <div class="row align-items-center h-100">
                <div class="col-6 mx-auto">
                    <div class="card">
                    <div class="card-body">
                        <h5 class="card-title" style={{textAlign: 'center'}}>Cadastro</h5>
                        <form>
                            <div class="form-group">
                                <label for="nome">Primerio Nome</label>
                                <input type="text" class="form-control" id="nome" placeholder="Primeiro Nome"></input>
                            </div>
                            <div class="form-group">
                                <label for="sobreNome">Sobrenome</label>
                                <input type="text" class="form-control" id="sobreNome" placeholder="Sobrenome"></input>
                            </div>
                            <div class="form-group">
                                <label for="email">E-mail</label>
                                <input type="email" class="form-control" id="email" aria-describedby="emailHelp" placeholder="Ex.: pessoa@dominio.com"></input>
                            </div>
                            <div class="form-group">
                                <label for="emailConfirmacao">Confirmação de E-mail</label>
                                <input type="email" class="form-control" id="emailConfirmacao" aria-describedby="emailHelp" placeholder="Confirmação de E-mail"></input>
                            </div>
                            <div class="form-group">
                                <label for="senha">Senha</label>
                                <input type="password" class="form-control" id="senha" placeholder="Senha"></input>
                            </div>
                            <div class="form-group">
                                <label for="senhaConfirmacao">Confirmação de Senha</label>
                                <input type="password" class="form-control" id="senhaConfirmacao" placeholder="Confirmação de Senha"></input>
                            </div>
                            <div class="form-check form-check-inline">
                                <input class="form-check-input" type="radio" name="tipoUsuarioOptions" id="tipoUsuarioPaciente" value="1"></input>
                                <label class="form-check-label" for="tipoUsuarioPaciente">Paciente</label>
                            </div>
                            <div class="form-check form-check-inline">
                                <input class="form-check-input" type="radio" name="tipoUsuarioOptions" id="tipoUsuarioProfissional" value="2" checked></input>
                                <label class="form-check-label" for="tipoUsuarioProfissional">Profissional</label>
                            </div>
                            <div class="form-group" style={{marginTop: '20px'}}>
                                <label for="orgao">Órgão</label>
                                <input type="text" class="form-control" id="orgao" placeholder="Órgão"></input>
                            </div>
                            <div class="form-group">
                                <label for="estado">Estado</label>
                                <input type="text" class="form-control" id="estado" placeholder="Estado"></input>
                            </div>
                            <div class="form-group">
                                <label for="registro">Registro</label>
                                <input type="text" class="form-control" id="registro" placeholder="Registro"></input>
                            </div>
                            <button type="submit" class="btn btn-primary">Cadastrar</button>
                            <button type="submit" class="btn btn-light float-right" onClick={() => history.push('/Login')} >Voltar</button>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}