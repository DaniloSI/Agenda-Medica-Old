import React, { forwardRef }  from 'react'
import Container from '@material-ui/core/Container';
import MaterialTable from 'material-table';
import api from '../../services/api';
import {
    FirstPage,
    LastPage,
    ChevronLeft,
    ChevronRight,
    ArrowUpward
} from '@material-ui/icons';

const tableIcons = {
    FirstPage: forwardRef((props, ref) => <FirstPage {...props} ref={ref} />),
    LastPage: forwardRef((props, ref) => <LastPage {...props} ref={ref} />),
    NextPage: forwardRef((props, ref) => <ChevronRight {...props} ref={ref} />),
    PreviousPage: forwardRef((props, ref) => <ChevronLeft {...props} ref={ref} />),
    SortArrow: forwardRef((props, ref) => <ArrowUpward {...props} ref={ref} />)
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
                        search: false
                    }
                }
            />
        </Container>
    )
}
