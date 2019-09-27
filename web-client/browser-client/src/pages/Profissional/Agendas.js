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

const tableIcons = {
    SortArrow: forwardRef((props, ref) => <ArrowUpward {...props} ref={ref} />)
};

const useStyles = makeStyles(theme => ({
    fab: {
        position: "fixed",
        margin: theme.spacing(1),
        bottom: theme.spacing.unit * 2,
        right: theme.spacing.unit * 6
    },
    extendedIcon: {
        marginRight: theme.spacing(1),
    },
}));

export default function Agendas(props) {
    const classes = useStyles();

    return (
        <NavBarProfissional
            history={props.history}
            content={
                <Container maxWidth="lg">
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
                                { titulo: 'Segundo Semestre', inicio: '01/07/2019', fim: '31/12/2019' }
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
                        <Fab color="primary" aria-label="add" className={classes.fab} onClick={() => props.history.push('/GerenciamentoAgenda')}>
                            <AddIcon />
                        </Fab>
                    </div>
                </Container>
            }
        />
    )
}
