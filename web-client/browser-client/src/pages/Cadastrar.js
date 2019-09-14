import React, { useState, useEffect } from 'react';

import api from '../services/api';
import * as Notifications from '../services/notifications';


export default function Cadastrar({ history }) {

    const [form, setForm] = useState({
        Nome: "",
        Sobrenome: "",
        cpf: "",
        Email: "",
        Senha: "",
        TipoUsuario: 0,
        cnpj: "",
        Orgao: "",
        Estado: "",
        Registro: "",
    });

    useEffect(() => {
        var camposProfissional = document.getElementById('professionalFields');
        var campoPaciente = document.getElementById('patientFields');

        if (form.TipoUsuario === 0) {
            camposProfissional.hidden = true;
            campoPaciente.hidden = false;
        }

        if (form.TipoUsuario === 1) {
            camposProfissional.hidden = false;
            campoPaciente.hidden = true;
        }
    }, [form]);

    async function handleSubmit(e) {
        e.preventDefault();

        if (form.TipoUsuario === 0) {
            handleResponse(
                await api.post('/User/CadastroPaciente',
                {
                    Nome: form.Nome,
                    SobreNome: form.Sobrenome,
                    DataNascimento: form.DataNascimento,
                    Email: form.Email,
                    Password: form.Senha,
                    Cpf: form.cpf,
                    PhoneNumber: "55704468412301"
                })
            );
        }

        function handleResponse(response) {
            if (response.data.sucesso) {
                history.push({
                    pathname: '/Login',
                    state: {
                        cadastroSucesso: true
                    }
                });
            } else {
                response.data.errors.forEach(error => {
                    Notifications.showError(error.description);
                });
            }
        }
    }

    return (
        <div className="container h-100">
            <div className="row align-items-center h-100">
                <div className="col-6 mx-auto">
                    <div className="card">
                        <div className="card-body">
                            <h5 className="card-title" style={{ textAlign: 'center' }}>Cadastro de Usuário</h5>
                            <form onSubmit={handleSubmit}>
                                <div className="form-group">
                                    <label htmlFor="nome">Primerio Nome</label>
                                    <input
                                        type="text"
                                        className="form-control"
                                        id="nome"
                                        value={form.Nome}
                                        onChange={e => setForm(
                                            {
                                                ...form,
                                                Nome: e.target.value
                                            }
                                        )}
                                        placeholder="Primeiro Nome"></input>
                                </div>
                                <div className="form-group">
                                    <label htmlFor="sobrenome">Sobrenome</label>
                                    <input
                                        type="text"
                                        className="form-control"
                                        id="sobrenome"
                                        value={form.Sobrenome}
                                        onChange={e => setForm(
                                            {
                                                ...form,
                                                Sobrenome: e.target.value
                                            }
                                        )}
                                        placeholder="Sobrenome"></input>
                                </div>
                                <div className="form-group">
                                    <label htmlFor="email">E-mail</label>
                                    <input
                                        type="email"
                                        className="form-control"
                                        id="email"
                                        aria-describedby="emailHelp"
                                        value={form.Email}
                                        onChange={e => setForm(
                                            {
                                                ...form,
                                                Email: e.target.value
                                            }
                                        )}
                                        placeholder="Ex.: pessoa@dominio.com"></input>
                                </div>
                                <div className="form-group">
                                    <label htmlFor="emailConfirmacao">Confirmação de E-mail</label>
                                    <input type="email" className="form-control" id="emailConfirmacao" aria-describedby="emailHelp" placeholder="Confirmação de E-mail"></input>
                                </div>
                                <div className="form-group">
                                    <label htmlFor="senha">Senha</label>
                                    <input
                                        type="password"
                                        className="form-control"
                                        id="senha"
                                        value={form.Senha}
                                        onChange={e => setForm({
                                            ...form,
                                            Senha: e.target.value
                                        })}
                                        placeholder="Senha"></input>
                                </div>
                                <div className="form-group">
                                    <label htmlFor="senhaConfirmacao">Confirmação de Senha</label>
                                    <input type="password" className="form-control" id="senhaConfirmacao" placeholder="Confirmação de Senha"></input>
                                </div>
                                <div className="row">
                                    <div className="pl-3 form-check form-check-inline">
                                        <input
                                            className="form-check-input"
                                            type="radio"
                                            name="tipoUsuarioOptions"
                                            id="tipoUsuarioPaciente"
                                            value={0}
                                            onChange={e => setForm({
                                                ...form,
                                                TipoUsuario: parseInt(e.target.value)
                                            })}
                                            checked={form.TipoUsuario === 0}></input>
                                        <label className="form-check-label" htmlFor="tipoUsuarioPaciente">Paciente</label>
                                    </div>
                                    <div className="col-1-2 form-check form-check-inline">
                                        <input
                                            className="form-check-input"
                                            type="radio"
                                            name="tipoUsuarioOptions"
                                            id="tipoUsuarioProfissional"
                                            value={1}
                                            onChange={e => setForm({
                                                ...form,
                                                TipoUsuario: parseInt(e.target.value)
                                            })}
                                            checked={form.TipoUsuario === 1}></input>
                                        <label className="form-check-label" htmlFor="tipoUsuarioProfissional">Profissional</label>
                                    </div>
                                </div>
                                <div id="professionalFields" className="border-top border-secondary" style={{ marginTop: '20px' }}>
                                    <div className="form-group mt-3">
                                        <label htmlFor="cnpj">CNPJ</label>
                                        <input
                                            type="text"
                                            className="form-control"
                                            id="cnpj"
                                            value={form.cnpj}
                                            onChange={e => setForm(
                                                {
                                                    ...form,
                                                    cnpj: e.target.value
                                                }
                                            )}
                                            placeholder="CNPJ"></input>
                                    </div>
                                    <div className="form-group">
                                        <label htmlFor="orgao">Órgão Regulador</label>
                                        <input
                                            type="text"
                                            className="form-control"
                                            id="orgao"
                                            value={form.Orgao}
                                            onChange={e => setForm(
                                                {
                                                    ...form,
                                                    Orgao: e.target.value
                                                }
                                            )}
                                            placeholder="Órgão"></input>
                                    </div>
                                    <div className="form-group">
                                        <label htmlFor="estado">Estado</label>
                                        <input
                                            type="text"
                                            className="form-control"
                                            id="estado"
                                            value={form.Estado}
                                            onChange={e => setForm(
                                                {
                                                    ...form,
                                                    Estado: e.target.value
                                                }
                                            )}
                                            placeholder="Estado"></input>
                                    </div>
                                    <div className="form-group">
                                        <label htmlFor="registro">Registro Profissional</label>
                                        <input
                                            type="text"
                                            className="form-control"
                                            id="registro"
                                            value={form.Registro}
                                            onChange={e => setForm(
                                                {
                                                    ...form,
                                                    Registro: e.target.value
                                                }
                                            )}
                                            placeholder="Registro"></input>
                                    </div>
                                </div>
                                <div id="patientFields" className="border-top border-secondary" style={{marginTop: '20px'}}>
                                    <div className="form-group mt-3">
                                        <label htmlFor="cpf">CPF</label>
                                        <input
                                            type="text"
                                            className="form-control"
                                            id="cpf"
                                            value={form.cpf}
                                            onChange={e => setForm(
                                                {
                                                    ...form,
                                                    cpf: e.target.value
                                                }
                                            )}
                                            placeholder="CPF"></input>
                                    </div>
                                </div>
                                <div className="mt-3">
                                    <button type="submit" className="btn btn-primary">Cadastrar</button>
                                    <button className="btn btn-light float-right" onClick={() => history.push('/Login')} >Cancelar</button>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}