import React, { forwardRef } from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Container from '@material-ui/core/Container';
import MaterialTable from 'material-table';
import {
    ArrowUpward,
    Delete,
    Edit
} from '@material-ui/icons';
import NavBarProfissional from './NavBarProfissional.js';
import Fab from '@material-ui/core/Fab';
import AddIcon from '@material-ui/icons/Add';
import api from '../../services/api';
import ReactDOM from 'react-dom';
import * as Notifications from '../../services/notifications';


const tableIcons = {
    SortArrow: forwardRef((props, ref) => <ArrowUpward {...props} ref={ref} />)
};

const useStyles = makeStyles(theme => ({
    fab: {
        position: "fixed",
        margin: theme.spacing(1),
        bottom: theme.spacing(2),
        right: theme.spacing(6)
    },
    extendedIcon: {
        marginRight: theme.spacing(1),
    },
}));

function TableAgendas({history, agendas}) {
    const classes = useStyles();
    const [state, setState] = React.useState({
        columns: [
            { title: 'Título', field: 'titulo' },
            { title: 'Início', field: 'dataHoraInicio' },
            { title: 'Fim', field: 'dataHoraFim' }
        ],
        data: agendas
    });

    return (
        <div>
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
                columns={state.columns}
                data={state.data}
                actions={[
                    {
                        icon: () => <Edit />,
                        onClick: (event, rowData) => history.push('/GerenciamentoAgenda/' + rowData.agendaId)
                    },
                    {
                        icon: () => <Delete />,
                        onClick: (event, rowData) => {
                            api.get('/Agenda/Delete?agendaId=' + rowData.agendaId)
                                .then(response => {
                                    if (response.data.sucesso){
                                        console.log(rowData.data);
                                        const data = [...state.data];
                                        data.splice(data.indexOf(rowData.data), 1);
                                        setState({ ...state, data });
                                        Notifications.showSuccess("Agenda deletada com sucesso!");
                                    }
                                });
                        }
                    }
                ]}
            />
            <Fab color="primary" aria-label="add" className={classes.fab} onClick={() => history.push('/GerenciamentoAgenda')}>
                <AddIcon />
            </Fab>
        </div>
    )
}

export default function Agendas(props) {
    api.get('/Agenda/Agendas')
        .then(response => {
            console.log('RESPONSE: ', response);

            ReactDOM.render(
                <TableAgendas history={props.history} agendas={response.data} />,
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
