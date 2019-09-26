import React, { forwardRef }  from 'react'
import ReactDOM from 'react-dom';
import Container from '@material-ui/core/Container';
import MaterialTable from 'material-table';
import api from '../../services/api';
import ConfirmCancel from '../../services/ConfirmCancel';
import * as Notifications from '../../services/notifications';
import {
    FirstPage,
    LastPage,
    ChevronLeft,
    ChevronRight,
    ArrowUpward,
    Cancel
} from '@material-ui/icons';
import NavBarProfissional from './NavBarProfissional.js';

const tableIcons = {
    FirstPage: forwardRef((props, ref) => <FirstPage {...props} ref={ref} />),
    LastPage: forwardRef((props, ref) => <LastPage {...props} ref={ref} />),
    NextPage: forwardRef((props, ref) => <ChevronRight {...props} ref={ref} />),
    PreviousPage: forwardRef((props, ref) => <ChevronLeft {...props} ref={ref} />),
    SortArrow: forwardRef((props, ref) => <ArrowUpward {...props} ref={ref} />),
    Cancel: forwardRef((props, ref) => <Cancel {...props} ref={ref} />)
};


function TableConsultas({ consultas }) {
    const [state, setState] = React.useState({
        columns: [
            {
                title: 'Especialidade',
                field: 'especialidadeNome'
            },
            {
                title: 'Paciente',
                field: 'pacienteNome'
            },
            {
                title: 'CPF',
                field: 'cpf'
            },
            {
                title: 'E-Mail',
                field: 'email'
            },
            {
                title: 'Telefone',
                field: 'phoneNumber'
            },
            {
                title: 'Data',
                field: 'data',
                type: 'date'
            },
            {
                title: 'Horário de Início',
                field: 'horaInicio'
            },
            {
                title: 'Horário de Fim',
                field: 'horaFim',
                type: 'time'
            }
        ],
        data: consultas
    });

    return (
        <MaterialTable
            title="Consultas Agendadas"
            columns={state.columns}
            data={state.data}
            icons={tableIcons}
            options={
                {
                    paging: false,
                    search: false,
                    actionsColumnIndex: -1
                }
            }
            actions={[
                rowData => ({
                icon: 'Cancel',
                tooltip: 'cancelar'
                })
            ]}
            components={{
                Action: rowData => 
                    <ConfirmCancel
                    title="Deseja cancelar a consulta?"
                    text="Ao clicar em SIM, a consulta será cancelada."
                    labelCancel="Não"
                    labelAccept="Sim"
                    callBack={(setOpen)=> {
                        api.get('/Consulta/CancelarConsulta', {
                            params: {
                                consultaId: rowData.data.consultaId
                            }
                        })
                            .then(response => {
                                if (response.status == 200){
                                    if (response.data.validationResult.isValid) {
                                        const data = [...state.data];
                                        data.splice(data.indexOf(rowData.data), 1);
                                        setState({ ...state, data });

                                        Notifications.showSuccess("Consulta cancelada com sucesso!");
                                    } else {
                                        response.data.validationResult.errors.forEach(function (e) {
                                            Notifications.showError(e.errorMessage);
                                        })
                                    }
                                }
                                setOpen(false);
                            });
                    }}
                    />
            }}
        />
    );
}

export default function ConsultasProfissional(props) {
    api.get('/Consulta/ConsultasProfissional')
        .then(response => {
            ReactDOM.render(
                <TableConsultas consultas={response.data} />,
                document.getElementById('table-consultas')
            );
    });

    return (
        <NavBarProfissional
            history={props.history}
            content={
                <Container maxWidth="lg">
                    <div id="table-consultas">
                    </div>
                </Container>
            }
        />
    )
}
