import React, { forwardRef }  from 'react'
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

const tableIcons = {
    FirstPage: forwardRef((props, ref) => <FirstPage {...props} ref={ref} />),
    LastPage: forwardRef((props, ref) => <LastPage {...props} ref={ref} />),
    NextPage: forwardRef((props, ref) => <ChevronRight {...props} ref={ref} />),
    PreviousPage: forwardRef((props, ref) => <ChevronLeft {...props} ref={ref} />),
    SortArrow: forwardRef((props, ref) => <ArrowUpward {...props} ref={ref} />),
    Cancel: forwardRef((props, ref) => <Cancel {...props} ref={ref} />)
};

export default function Agenda() {
    const [state, setState] = React.useState({
        columns: [
            {
                title: 'Especialidade',
                field: 'especialidadeNome'
            },
            {
                title: 'Profissional',
                field: 'profissionalNome'
            },
            {
                title: 'Endereço',
                field: 'endereco'
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
        ]
      });
    return (
        <Container maxWidth="lg">
            <MaterialTable
                title="Agenda"
                columns={state.columns}
                data={() => new Promise((resolve, reject) => {
                    api.get('/Agenda/AgendaPaciente')
                        .then(response => {
                            resolve({
                                data: response.data
                            });
                        });
                })}
                icons={tableIcons}
                options={
                    {
                        paging: false,
                        search: false,
                        actionsColumnIndex: -1
                    }
                }
                actions={[
                    {
                      icon: 'Cancel',
                      tooltip: 'cancelar'
                    }
                  ]}
                components={{
                    Action: props => 
                        <ConfirmCancel
                        title="Deseja cancelar a consulta?"
                        text="Ao clicar em SIM, a consulta será cancelada."
                        labelCancel="Não"
                        labelAccept="Sim"
                        callBack={(setOpen)=> {
                            console.log(props);
                            api.get('/Consulta/CancelarConsulta', {
                                params: {
                                    consultaId: props.data.consultaId
                                }
                            })
                                .then(response => {
                                    if (response.status == 200){
                                        if (response.data.validationResult.isValid) {
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
        </Container>
    )
}
