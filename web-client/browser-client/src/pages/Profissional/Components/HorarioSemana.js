import React, { useContext } from 'react';
import { FormContext } from '../CadastrarHorarios';

export default function HorarioSemana(props) {

    const [horarios, setForm] = useContext(FormContext);
    
    var x = 0;

    function deletarItem(tableId, elemId) {
        let data = document.querySelector(`#${tableId} #${elemId}`);

        
        
        // horarios.array.forEach(element => {
        //     //eslint-disable-next-line
        //     if(element.diaSemana == 1) return 1;
        // });



        console.log(data);
    }

    return (
        <>
            <h4>{props.nome}</h4>
            <div>
                <table className="table table-borderless">
                    <thead>
                        <tr>
                            <th>#</th>
                            <th>Início</th>
                            <th>Término</th>
                            <th>Ação</th>
                        </tr>
                    </thead>
                    <tbody id={props.tableId}>
                        {
                            horarios.map(h => {                                
                                if (h.diaSemana === props.id) {
                                    let idItem = `item${x++}`;

                                    return (
                                        //eslint-disable-next-line
                                        <tr id={idItem}>
                                            <td>{x}</td>
                                            <td>{h.horaInicio}</td>
                                            <td>{h.horaFim}</td>
                                            <td><button onClick={
                                                e => {
                                                    deletarItem(props.tableId, idItem)
                                                    e.preventDefault();
                                                }
                                            }>Deletar</button></td>
                                        </tr>
                                    )
                                } else {
                                    return (<tr></tr>)
                                }
                            })
                        }
                    </tbody>
                </table>
            </div>
        </>
    )
}