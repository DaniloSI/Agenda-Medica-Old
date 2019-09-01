import React, { useState } from 'react';

export default function pacienteConsultas(props){   
    
    const [formulario, setFormulario] = useState({
        regiao: "",
        convenio: "",
        minimo: 0,
        maximo: 0,
        especialidade: "",
    });



    function handleSubmit(e) {
        e.preventDefault();
        console.log(formulario);
    }

    return (
        <div>
            <div>
                <h2>Buscar Consultas</h2>
                <h3>Profissionais de saúde e Clínicas/Consultorios</h3>
            </div>      
            <div>
                <form onSubmit={handleSubmit}>
                    <div className="form-group">
                        <label htmlFor="regiao">Região</label>
                    </div>
                    <div className="form-group">
                        <label htmlFor="convenio">Convenio</label>
                    </div>
                    <div className="form-group">
                        <label htmlFor="minimo">Valor Minimo</label>
                        <input
                            type="text"
                            className="form-control"
                            id="minimo"
                            value={formulario.minimo}
                            onChange={e => setFormulario(
                                {
                                    ...formulario,
                                    minimo: e.target.value
                                }
                            )}
                            placeholder="100">
                        </input>
                    </div>
                    <div className="form-group">
                        <label htmlFor="maximo">Valor Máximo</label>
                        <input
                            type="text"
                            className="form-control"
                            id="maximo"
                            value={formulario.maximo}
                            onChange={e => setFormulario(
                                {
                                    ...formulario,
                                    maximo: e.target.value
                                }
                            )}
                            placeholder="200">
                        </input>
                    </div>
                    <div className="form-group">
                        <label htmlFor="especialide">Especialidade</label>
                        
                    </div><div className="form-group">
                        <label htmlFor="dia">Dia</label>
                        
                    </div>
                    <button type="submit" className="btn btn-primary">Buscar</button>
                </form>
            </div>
        </div>
    );
}