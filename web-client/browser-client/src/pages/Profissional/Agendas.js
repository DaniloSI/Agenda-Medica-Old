import React, { forwardRef } from 'react';
import Container from '@material-ui/core/Container';
import MaterialTable from 'material-table';
import {
    ArrowUpward,
    Delete,
    Edit
} from '@material-ui/icons';
import NavBarProfissional from './NavBarProfissional.js';

const tableIcons = {
    SortArrow: forwardRef((props, ref) => <ArrowUpward {...props} ref={ref} />)
};

export default function Agendas(props) {
    return (
        <NavBarProfissional
            history={props.history}
            content={
                <Container fixed>
                    <div id="table-consultas">
                        <MaterialTable
                            title="Agendas"
                            icons={tableIcons}
                            options={
                                {
                                    paging: false,
                                    search: false,
                                    actionsColumnIndex: -1
                                }
                            }
                            columns={[
                                { title: 'Título', field: 'titulo' },
                                { title: 'Início', field: 'inicio' },
                                { title: 'Fim', field: 'fim' }
                            ]}
                            data={[
                                { titulo: 'Primeiro Semestre', inicio: '01/01/2019', fim: '30/06/2019' },
                                { titulo: 'Segundo Semestre', inicio: '01/07/2019', fim: '31/12/2019' },
                            ]}
                            actions={[
                                {
                                    icon: () => <Edit />,
                                    tooltip: 'Editar',
                                    onClick: (event, rowData) => props.history.push('/GerenciamentoAgenda')
                                },
                                {
                                    icon: () => <Delete />,
                                    tooltip: 'Deletar',
                                    onClick: (event, rowData) => alert("Deseja mesmo deletar a agenda '" + rowData.titulo + "'?")
                                }
                            ]}
                        />
                    </div>
                </Container>
            }
        />
    )
}
