import React, { forwardRef }  from 'react'
import Container from '@material-ui/core/Container';
import MaterialTable from 'material-table';
import {
    Search,
    Clear,
    FirstPage,
    LastPage,
    ChevronLeft,
    ChevronRight,
    ArrowUpward
} from '@material-ui/icons';

const tableIcons = {
    Search: forwardRef((props, ref) => <Search {...props} ref={ref} />),
    FirstPage: forwardRef((props, ref) => <FirstPage {...props} ref={ref} />),
    LastPage: forwardRef((props, ref) => <LastPage {...props} ref={ref} />),
    NextPage: forwardRef((props, ref) => <ChevronRight {...props} ref={ref} />),
    PreviousPage: forwardRef((props, ref) => <ChevronLeft {...props} ref={ref} />),
    Clear: forwardRef((props, ref) => <Clear {...props} ref={ref} />),
    ResetSearch: forwardRef((props, ref) => <Clear {...props} ref={ref} />),
    SortArrow: forwardRef((props, ref) => <ArrowUpward {...props} ref={ref} />)
};

export default function Agenda() {
    const [state, setState] = React.useState({
        columns: [
            {
                title: 'Profissional',
                field: 'nome'
            },
            {
                title: 'Data',
                field: 'data',
                type: 'date'
            },
            {
                title: 'Horário de Início',
                field: 'horarioInicio'
            },
            {
                title: 'Horário de Fim',
                field: 'horarioFim',
                type: 'time'
            }
        ],
        data: [
            {
                nome: 'Mehmet da Silva',
                data: '16/09/2019',
                horarioInicio: '15:30',
                horarioFim: '16:30'
            },
            {
                nome: 'Mehmet Soarez de Sousa',
                data: '21/09/2019',
                horarioInicio: '08:30', 
                horarioFim: '10:30'
            }
        ],
      });
    return (
        <Container maxWidth="lg">
            <MaterialTable
                title="Agenda"
                columns={state.columns}
                data={state.data}
                icons={tableIcons}
                options={
                    {
                        paging: false
                    }
                }
            />
        </Container>
    )
}
