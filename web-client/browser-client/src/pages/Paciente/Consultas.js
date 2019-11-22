import React, { forwardRef, useEffect }  from 'react'
import { makeStyles } from '@material-ui/core/styles';
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
import NavBarPaciente from './NavBarPaciente.js';
import DoneIcon from '@material-ui/icons/Done';
import DoneAllIcon from '@material-ui/icons/DoneAll';
import CloseIcon from '@material-ui/icons/Close';
import Tooltip from '@material-ui/core/Tooltip';
import PaymentIcon from '@material-ui/icons/Payment';
import Grid from '@material-ui/core/Grid';
import IconButton from '@material-ui/core/IconButton';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import DialogContentText from '@material-ui/core/DialogContentText';
import DialogTitle from '@material-ui/core/DialogTitle';


const tableIcons = {
    FirstPage: forwardRef((props, ref) => <FirstPage {...props} ref={ref} />),
    LastPage: forwardRef((props, ref) => <LastPage {...props} ref={ref} />),
    NextPage: forwardRef((props, ref) => <ChevronRight {...props} ref={ref} />),
    PreviousPage: forwardRef((props, ref) => <ChevronLeft {...props} ref={ref} />),
    SortArrow: forwardRef((props, ref) => <ArrowUpward {...props} ref={ref} />),
    Cancel: forwardRef((props, ref) => <Cancel {...props} ref={ref} />)
};

const useStyles = makeStyles(theme => ({
    iconTableStatusPago: {
        color: "#4caf50",
    },
    iconTableStatusNaoPago: {
        color: "#212121",
    },
    dialogPaymentAction:{
        justifyContent:'center',
    }
}));

function TableConsultas({ consultas }) {
    const classes = useStyles();
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
            },
            {
                title: 'Status',
                field: 'estado',
                render: rowData => {
                    var classNameStatus = rowData.pagamentoConfirmado ? classes.iconTableStatusPago : classes.iconTableStatusNaoPago;
                    var titleComplementoPago = rowData.pagamentoConfirmado ? " e paga" : "";

                    if (rowData.estado == 0) {
                        return <Tooltip title={("Agendada" + titleComplementoPago)}><DoneIcon className={classNameStatus} /></Tooltip>;
                    } else if (rowData.estado == 1) {
                        return <Tooltip title={("Realizada" + titleComplementoPago)}><DoneAllIcon className={classNameStatus} /></Tooltip>;
                    } else {
                        return <Tooltip title={("Cancelada" + titleComplementoPago)}><CloseIcon className={classNameStatus} /></Tooltip>;
                    }
                }
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
                Action: rowData => {
                    if (rowData.data.estado == '0') {
                        return (
                            <Grid
                                container
                                direction="row"
                            >
                                <Grid item xs={6}>
                                    <Pagamento
                                        consulta={rowData.data}
                                    />
                                </Grid>
                                <Grid item xs={6}>
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
                                                            data[data.indexOf(rowData.data)].estado = response.data.estado;
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
                                </Grid>
                            </Grid>
                        );
                    }
                    else {
                        return (<p></p>);
                    }
                }
            }}
        />
    );
}

function Pagamento({ consulta }) {
    const classes = useStyles();
    const [open, setOpen] = React.useState(false);

    const handleClickOpen = () => {
        setOpen(true);
    };

    const handleClose = () => {
        setOpen(false);
    };

    useEffect(() => {
        
    }, []);

    return (
        <div>
            <Tooltip title="Pagar">
                <IconButton aria-label="cancelar" size='small'>
                    <PaymentIcon onClick={handleClickOpen} />
                </IconButton>
            </Tooltip>
            <Dialog
                open={open}
                onClose={handleClose}
                onEntered={() => {
                    window.renderButtonPaypal("paypal-button-container-" + consulta.consultaId, 'sb-fegkl615996@personal.example.com', '25');
                }}
                aria-labelledby="alert-dialog-title"
                aria-describedby="alert-dialog-description"
            >
                <DialogTitle id="alert-dialog-title">Pagar Consulta</DialogTitle>
                <DialogActions className={classes.dialogPaymentAction}>
                    <div id={("paypal-button-container-" + consulta.consultaId)}></div>
                </DialogActions>
            </Dialog>
        </div>
    )
}

export default function Consultas(props) {
    api.get('/Consulta/ConsultasPaciente')
        .then(response => {
            ReactDOM.render(
                <TableConsultas consultas={response.data} />,
                document.getElementById('table-consultas')
            );
    });

    return (
        <NavBarPaciente
            history={props.history}
            content={
                <Container maxWidth="xl">
                    <div id="table-consultas"></div>
                </Container>
            }
        />
    )
}
