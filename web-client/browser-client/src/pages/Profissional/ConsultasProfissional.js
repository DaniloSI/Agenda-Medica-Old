import React, { forwardRef, useEffect }  from 'react'
import { makeStyles } from '@material-ui/core/styles';
import Paper from '@material-ui/core/Paper';
import Button from '@material-ui/core/Button';
import Box from '@material-ui/core/Box';
import Container from '@material-ui/core/Container';
import api from '../../services/api';
import * as Notifications from '../../services/notifications';
import Modal from '@material-ui/core/Modal';
import Backdrop from '@material-ui/core/Backdrop';
import Fade from '@material-ui/core/Fade';
import NavBarProfissional from './NavBarProfissional.js';
import FullCalendar from '@fullcalendar/react'
import dayGridPlugin from '@fullcalendar/daygrid'
import '@fullcalendar/core/main.css'
import '@fullcalendar/daygrid/main.css'

const useStyles = makeStyles(theme => ({
    button: {
        marginTop: theme.spacing(1),
    },
    paperCalendar: {
        padding: theme.spacing(3, 2),
    },
    paperModal: {
        backgroundColor: theme.palette.background.paper,
        border: '2px solid #000',
        boxShadow: theme.shadows[5],
        padding: theme.spacing(2, 4, 3),
    },
    modal: {
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'center',
    },
}));


export default function ConsultasProfissional(props) {
    const classes = useStyles();
    const [consultas, setConsultas] = React.useState([]);
    const [openModal, setOpenModal] = React.useState({
        open: false,
        consultaId: -1
    });

  const handleOpenModal = (consultaId) => {
    const consulta = consultas.find(consulta => consulta.consultaId == consultaId);
    setOpenModal({
        open: true,
        consultaId: consultaId,
        pacienteNome: consulta.pacienteNome,
        especialidadeNome: consulta.especialidadeNome,
        pacienteNome: consulta.pacienteNome,
        cpf: consulta.cpf,
        email: consulta.email,
        phoneNumber: consulta.phoneNumber,
        data: consulta.data,
        pagamentoConfirmado: consulta.pagamentoConfirmado,
        horaInicio: consulta.horaInicio,
        horaFim: consulta.horaFim,
        estado: consulta.estado
    });
  };

  const handleCloseModal = () => {
    setOpenModal({
        ...openModal,
        open: false
    });
  };

  function atualizarConsultas() {
      api.get('/Consulta/ConsultasProfissional')
          .then(response => {
              setConsultas(response.data);
      });
  }

    useEffect(() => {
        atualizarConsultas();
    }, [])

    return (
        <NavBarProfissional
            history={props.history}
            content={
                <Container maxWidth="xl">
                    <Paper className={classes.paperCalendar}>
                        <FullCalendar
                            defaultView="dayGridWeek"
                            plugins={[ dayGridPlugin ]}
                            weekends={true}
                            header={{
                                left: 'prev,next',
                                center: 'title',
                                right: 'dayGridDay,dayGridWeek,dayGridMonth'
                            }}
                            height={'auto'}
                            editable={true}
                            events={
                                consultas.map((consulta) => {
                                    return {
                                        id: consulta.consultaId,
                                        title: ((consulta.pagamentoConfirmado) ? "[PAGO] " : "") + consulta.pacienteNome,
                                        start: consulta.dataHoraInicio,
                                        end: consulta.dataHoraFim,
                                        backgroundColor: (consulta.estado == 0 ? /* Agendada */ "" : (consulta.estado == 1 ? /* Realizada */ "#757575" : /* Cancelada */ "#e0e0e0"))
                                    }
                                })
                            }
                            eventTimeFormat={{
                                hour: '2-digit',
                                minute: '2-digit',
                                meridiem: false
                            }}
                            eventClick={(info) => {
                                handleOpenModal(info.event.id);
                            }
                            }
                        />
                    </Paper>
                    <Modal
                        className={classes.modal}
                        open={openModal.open}
                        onClose={handleCloseModal}
                        closeAfterTransition
                        BackdropComponent={Backdrop}
                        BackdropProps={{
                        timeout: 200,
                        }}
                    >
                        <Fade in={openModal.open}>
                            <div className={classes.paperModal}>
                                <h2>Informações da Consulta</h2>
                                <br />
                                <p><strong>Especialidade</strong>: {openModal.especialidadeNome}</p>
                                <p><strong>Paciente</strong>: {openModal.pacienteNome}</p>
                                <p><strong>CPF</strong>: {openModal.cpf}</p>
                                <p><strong>E-mail</strong>: {openModal.email}</p>
                                <p><strong>Telefone</strong>: {openModal.phoneNumber}</p>
                                <p><strong>Data</strong>: {openModal.data}</p>
                                <p><strong>Horario de Início</strong>: {openModal.horaInicio}</p>
                                <p><strong>Horario de Fim</strong>: {openModal.horaFim}</p>
                                <p><strong>Estado</strong>: {(openModal.estado == 0) ? "Agendada" : (openModal.estado == 1 ? "Realizada" : "Cancelada")}</p>
                                <p><strong>Pagamento</strong>: {(openModal.pagamentoConfirmado) ? "Pago" : "Não Pago"}</p>
                                <br />
                                {openModal.estado !== 2 && !openModal.pagamentoConfirmado && (
                                    <Box width="100%" display="flex">
                                        <Button
                                            variant="contained"
                                            color="secondary"
                                            className={classes.button}
                                            right="true"
                                            fullWidth
                                            onClick={() => {
                                                api.get('/Consulta/ConfirmarPagamento', {
                                                    params: {
                                                        consultaId: openModal.consultaId
                                                    }
                                                })
                                                    .then(response => {
                                                        if (response.status == 200){
                                                            if (response.data.validationResult.isValid) {
                                                                Notifications.showSuccess("Pagamento da consulta confirmado com sucesso!");
                                                            } else {
                                                                response.data.validationResult.errors.forEach(function (e) {
                                                                    Notifications.showError(e.errorMessage);
                                                                })
                                                            }
                                                        }
                                                        handleCloseModal();
                                                        atualizarConsultas();
                                                    });
                                            }}>
                                            Confirmar Pagamento
                                        </Button>
                                    </Box>
                                )}
                                {(openModal.estado == 0) && (
                                    <div>
                                        <Box width="100%" display="flex">
                                            <Button
                                                variant="contained"
                                                color="primary"
                                                className={classes.button}
                                                right="true"
                                                fullWidth
                                                onClick={() => {
                                                    api.get('/Consulta/RealizarConsulta', {
                                                        params: {
                                                            consultaId: openModal.consultaId
                                                        }
                                                    })
                                                        .then(response => {
                                                            if (response.status == 200){
                                                                if (response.data.validationResult.isValid) {
                                                                    Notifications.showSuccess("Consulta marcada como realizada com sucesso!");
                                                                } else {
                                                                    response.data.validationResult.errors.forEach(function (e) {
                                                                        Notifications.showError(e.errorMessage);
                                                                    })
                                                                }
                                                            }
                                                            handleCloseModal();
                                                            atualizarConsultas();
                                                        });
                                                }}>
                                                Marcar como Realizada
                                            </Button>
                                        </Box>
                                        <Box width="100%" display="flex">
                                            <Button
                                                variant="contained"
                                                color="default"
                                                className={classes.button}
                                                right="true"
                                                fullWidth
                                                onClick={() => {
                                                    api.get('/Consulta/CancelarConsulta', {
                                                        params: {
                                                            consultaId: openModal.consultaId
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
                                                            handleCloseModal();
                                                            atualizarConsultas();
                                                        });
                                                }}>
                                                Cancelar
                                            </Button>
                                        </Box>
                                    </div>
                                )}
                            </div>
                        </Fade>
                    </Modal>
                </Container>
            }
        />
    )
}
