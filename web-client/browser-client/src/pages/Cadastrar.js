import React, { useState, useEffect } from 'react';

export default function Cadastrar({ history }) {

    const [form, setForm] = useState({
        Nome: "",
        Sobrenome: "",
        Email: "",
        Senha: "",
        TipoUsuario: 1,
        Orgao: "",
        Estado: "",
        Registro: "",
    });

    useEffect(() => {
        var campo = document.getElementById('professionalFields');

        if (form.TipoUsuario === 1) {
            campo.hidden = true;
        }

        if (form.TipoUsuario === 2) {
            campo.hidden = false;
        }
    }, [form]);

    function handleSubmit(e) {
        e.preventDefault();
        console.log(form);
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
                                    <label for="nome">Primerio Nome</label>
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
                                    <label for="sobrenome">Sobrenome</label>
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
                                    <label for="email">E-mail</label>
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
                                    <label for="emailConfirmacao">Confirmação de E-mail</label>
                                    <input type="email" className="form-control" id="emailConfirmacao" aria-describedby="emailHelp" placeholder="Confirmação de E-mail"></input>
                                </div>
                                <div className="form-group">
                                    <label for="senha">Senha</label>
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
                                    <label for="senhaConfirmacao">Confirmação de Senha</label>
                                    <input type="password" className="form-control" id="senhaConfirmacao" placeholder="Confirmação de Senha"></input>
                                </div>
                                <div className="form-check form-check-inline">
                                    <input
                                        className="form-check-input"
                                        type="radio"
                                        name="tipoUsuarioOptions"
                                        id="tipoUsuarioPaciente"
                                        value={1}
                                        onChange={e => setForm({
                                            ...form,
                                            TipoUsuario: parseInt(e.target.value)
                                        })}
                                        checked={form.TipoUsuario === 1}></input>
                                    <label className="form-check-label" for="tipoUsuarioPaciente">Paciente</label>
                                </div>
                                <div className="form-check form-check-inline">
                                    <input
                                        className="form-check-input"
                                        type="radio"
                                        name="tipoUsuarioOptions"
                                        id="tipoUsuarioProfissional"
                                        value={2}
                                        onChange={e => setForm({
                                            ...form,
                                            TipoUsuario: parseInt(e.target.value)
                                        })}
                                        checked={form.TipoUsuario === 2}></input>
                                    <label className="form-check-label" for="tipoUsuarioProfissional">Profissional</label>
                                </div>

                                <div id="professionalFields" className="border-top border-secondary" style={{ marginTop: '20px' }}>
                                    <div className="form-group" style={{ marginTop: '20px' }}>
                                        <label for="orgao">Órgão Regulador</label>
                                        <input type="text" className="form-control" id="orgao" placeholder="Ex.: CRM"></input>
                                    </div>
                                    <div className="form-group">
                                        <label for="estado">Estado</label>
                                        <input type="text" className="form-control" id="estado" placeholder="Ex.: SP"></input>
                                    </div>
                                    <div className="form-group">
                                        <label for="registro">Registro Profissional</label>
                                        <input type="text" className="form-control" id="registro" placeholder="Ex.: 045904"></input>
                                    </div>
                                </div>
                                <button type="submit" className="btn btn-primary">Cadastrar</button>
                                <button className="btn btn-light float-right" onClick={() => history.push('/Login')} >Cancelar</button>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
}