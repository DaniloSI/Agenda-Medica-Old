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
        // margin: theme.spacing(1),
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
        horaInicio: consulta.horaInicio,
        horaFim: consulta.horaFim
    });
  };

  const handleCloseModal = () => {
    setOpenModal({
        ...openModal,
        open: false
    });
  };

    useEffect(() => {
        api.get('/Consulta/ConsultasProfissional')
            .then(response => {
                setConsultas(response.data);
        });
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
                                        title: consulta.pacienteNome,
                                        start: consulta.dataHoraInicio,
                                        end: consulta.dataHoraFim
                                    }
                                })
                            }
                            eventTimeFormat={{
                                hour: '2-digit',
                                minute: '2-digit',
                                meridiem: false
                            }}
                            eventClick={(info) => {
                                console.log('ConsultaId: ' + info.event.id);
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
                                <br />
                                <Box width="100%" display="flex" flexDirection="row-reverse">
                                    <Box >
                                        <Button
                                            variant="contained"
                                            color="default"
                                            className={classes.button}
                                            right="true"
                                            onClick={() => {
                                                api.get('/Consulta/CancelarConsulta', {
                                                    params: {
                                                        consultaId: openModal.consultaId
                                                    }
                                                })
                                                    .then(response => {
                                                        if (response.status == 200){
                                                            if (response.data.validationResult.isValid) {
                                                                // TODO: Remover consulta do calendario.
                        
                                                                Notifications.showSuccess("Consulta cancelada com sucesso!");
                                                            } else {
                                                                response.data.validationResult.errors.forEach(function (e) {
                                                                    Notifications.showError(e.errorMessage);
                                                                })
                                                            }
                                                        }
                                                        handleCloseModal();
                                                    });
                                            }}>
                                            Cancelar Consulta
                                        </Button>
                                    </Box>
                                </Box>
                            </div>
                        </Fade>
                    </Modal>
                </Container>
            }
        />
    )
}
