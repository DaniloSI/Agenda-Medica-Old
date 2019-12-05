import React from 'react';
import ReactDOM from 'react-dom';
import { makeStyles } from '@material-ui/core/styles';
import Modal from '@material-ui/core/Modal';
import Backdrop from '@material-ui/core/Backdrop';
import Fade from '@material-ui/core/Fade';
import EventAvailableIcon from '@material-ui/icons/EventAvailable';
import Button from '@material-ui/core/Button';
import Grid from '@material-ui/core/Grid';
import DateFnsUtils from '@date-io/date-fns';
import FormControl from '@material-ui/core/FormControl';
import Select from '@material-ui/core/Select';
import InputLabel from '@material-ui/core/InputLabel';
import api from '../../services/api';
import MenuItem from '@material-ui/core/MenuItem';
import * as Notifications from '../../services/notifications';
import {
  MuiPickersUtilsProvider,
  KeyboardDatePicker,
} from '@material-ui/pickers';
import CreditCardInput from 'react-credit-card-input';
import Axios from 'axios';

const useStyles = makeStyles(theme => ({
  modal: {
    display: 'flex',
    alignItems: 'center',
    justifyContent: 'center',
  },
  paper: {
    backgroundColor: theme.palette.background.paper,
    border: '2px solid #000',
    boxShadow: theme.shadows[5],
    padding: theme.spacing(2, 4, 3),
    maxWidth: '350px'
  },
  button: {
    margin: theme.spacing(1),
  },
  leftIcon: {
    marginRight: theme.spacing(1),
  },
  formControl: {
    minWidth: 280,
  },
  selectEmpty: {
    marginTop: theme.spacing(2),
  },
  root: {
    display: 'flex',
    flexWrap: 'wrap',
  },
}));

export default function AgendarHorarioBuscaProfissional({ profissional }) {
  const classes = useStyles();

  const pag = {
    DINHEIRO: 1,
    BOLETO: 2,
    CREDITO: 3
  }

  const [open, setOpen] = React.useState(false);
  const [selectedDate, setSelectedDate] = React.useState(null);
  const [listaHorarios, setListaHorarios] = React.useState([]);
  const [horario, setHorario] = React.useState({
    horarioId: '',
    Intervalo: '',
  });
  const [formaPagamento, setFormaPagamento] = React.useState(pag.DINHEIRO);
  const [dadosPagamento, setDadosPagamento] = React.useState(
    {
      cardNumber: '',
      expiry: '',
      cvc: ''
    }
  );
  const [especialidade, setEspecialidade] = React.useState({
    especialidadeId: '',
    intervalo: '',
  });

  function validatePagamento() {
    return (formaPagamento !== pag.CREDITO) || (formaPagamento === pag.CREDITO && dadosPagamento.cvc && dadosPagamento.expiry && dadosPagamento.cardNumber);
  }

  function handleChangeHorario(event) {
    setHorario(oldHorario => ({
      ...oldHorario,
      [event.target.name]: event.target.value,
    }));
  }

  function handleChangeEspecialidade(event) {
    setEspecialidade(oldEspecialidade => ({
      ...oldEspecialidade,
      [event.target.name]: event.target.value,
    }));
  }

  async function handleDateChange(date) {
    setSelectedDate(date);

    const response = await api.get("/Agenda/HorariosPorData", {
      params: {
        profissionalId: profissional.id,
        data: date
      }
    });

    if (response.status == 200) {
      setListaHorarios(response.data);
    } else {
      Notifications.showError("Erro ao atualizar lista de Horários.");
    }
  }

  function handleChangePagamento(event) {
    setFormaPagamento(event.target.value);

    if (event.target.value !== pag.CREDITO)
      setDadosPagamento({
        cardNumber: '',
        expiry: '',
        cvc: ''
      });
  }

  async function handleBoleto(e){
    const axios = require('axios');

    if ('cpfPayer') {
        axios.get('https://sandbox.boletobancario.com/boletofacil/integration/api/v1/issue-charge',
            { params:{
                token: 'DBD36248D7E26F938D39AB344BD8C3EFF4BD1B1B07F929C7E7F080BBF1E269EF',
                description: 'Agenda Medica - Pagamento Boleto',
                amount: 50.00,
                payerName: 'Lucas Erlacher',
                payerCpfCnpj: '17025193763'
            }
            }
        ).then(
          function(response) {
            console.log(response);
            var response_boleto = response.data.data.charges[0];
            window.open(response_boleto.link, '_blank');          
          }
        );
        
       
    }
    else {
        alert('empty');
    }
}

  const handleOpen = () => {
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
    setHorario(oldHorario => ({
      ...oldHorario,
      'horarioId': '',
    }));
    setEspecialidade(oldEspecialidade => ({
      ...oldEspecialidade,
      'especialidadeId': '',
    }));
    setSelectedDate(null);
    setDadosPagamento({
      cardNumber: '',
      expiry: '',
      cvc: ''
    });
    setFormaPagamento(pag.DINHEIRO);
  };

  async function handleAgendar() {
    if (!selectedDate || !horario.horarioId || !especialidade.especialidadeId || !validatePagamento()) {
      Notifications.showError("É necessário preencher todos os campos!");
    } else {
      const response = await api.post("/Consulta",{
        data: new Date(selectedDate.getFullYear(), selectedDate.getMonth(), selectedDate.getDate()),
        horaInicio: listaHorarios.filter(h => h.horarioId == horario.horarioId).pop().horaInicio,
        horaFim: listaHorarios.filter(h => h.horarioId == horario.horarioId).pop().horaFim,
        profissionalId: profissional.id,
        especialidadeId: especialidade.especialidadeId,
        tipoPagamento: formaPagamento,
        cartao: (formaPagamento !== pag.CREDITO ? null : dadosPagamento)
      });

      if (response.status == 200) {
        if (response.data.validationResult.isValid) {
          handleClose();
          Notifications.showSuccess("Horário agendado com sucesso!");
        } else {
          response.data.validationResult.errors.forEach(function (error) {
            Notifications.showError(error.errorMessage);
          });
        }
      } else {
        Notifications.showError("Erro '" + response.status + "'");
      }
    }
  };

  function renderEspecialidade(e) {
    return <MenuItem key={e.especialidadeId} value={e.especialidadeId}>{e.nome}</MenuItem>
  }

  return (
    <div>
      <Button color="primary" size="small" className={classes.button} onClick={handleOpen}>
            <EventAvailableIcon className={classes.leftIcon} />
            Agendar Horário
        </Button>
      <Modal
        aria-labelledby="transition-modal-title"
        aria-describedby="transition-modal-description"
        className={classes.modal}
        open={open}
        onClose={handleClose}
        closeAfterTransition
        BackdropComponent={Backdrop}
        BackdropProps={{
          timeout: 500,
        }}
      >
        <Fade in={open}>
          <div className={classes.paper}>
            <h2 id="transition-modal-title">Agendamento de Horário</h2>
            <p id="transition-modal-description"><strong>Profissional</strong>: {profissional.nomeCompleto}</p>
            <form autoComplete="off" className={{flexGrow: 1}}>
              <Grid container spacing={3} justify="center">
                <Grid item xs={12}>
                  <MuiPickersUtilsProvider utils={DateFnsUtils}>
                    <KeyboardDatePicker
                      id="date-picker-data-consulta"
                      className={classes.formControl}
                      label="Data da Consulta"
                      format="MM/dd/yyyy"
                      value={selectedDate}
                      onChange={handleDateChange}
                      KeyboardButtonProps={{
                        'aria-label': 'change date',
                      }}
                    />
                  </MuiPickersUtilsProvider>
                </Grid>
                <Grid item xs={12}>
                  <FormControl className={classes.formControl}>
                    <InputLabel htmlFor="especialidade">Especialidade</InputLabel>
                    <Select
                      value={especialidade.especialidadeId}
                      onChange={handleChangeEspecialidade}
                      displayEmpty
                      inputProps={{
                        name: 'especialidadeId',
                        id: 'especialidade',
                      }}
                    >
                      {profissional.especialidades.map(e => renderEspecialidade(e))}
                    </Select>
                  </FormControl>
                </Grid>
                <Grid item xs={12}>
                  <FormControl className={classes.formControl}>
                    <InputLabel htmlFor="horario">Horário</InputLabel>
                    <Select
                      value={horario.horarioId}
                      onChange={handleChangeHorario}
                      displayEmpty
                      inputProps={{
                        name: 'horarioId',
                        id: 'horario',
                      }}
                    >
                      {
                        listaHorarios.map(horario =>
                          <MenuItem key={horario.horarioId} value={horario.horarioId}>De {horario.horaInicio} às {horario.horaFim}</MenuItem>
                        )
                      }
                    </Select>
                  </FormControl>
                </Grid>
                <Grid item xs={12}>
                  <FormControl className={classes.formControl}>
                    <InputLabel htmlFor="pagamento">Forma de Pagamento</InputLabel>
                    <Select
                      value={formaPagamento}
                      onChange={handleChangePagamento}
                      displayEmpty
                      inputProps={{
                        name: 'pagamentoId',
                        id: 'pagamento',
                      }}
                    >                                              
                          <MenuItem key={pag.DINHEIRO} value={pag.DINHEIRO}>Dinheiro</MenuItem>                        
                          <MenuItem key={pag.BOLETO} value={pag.BOLETO}>Boleto</MenuItem>                        
                          <MenuItem key={pag.CREDITO} value={pag.CREDITO}>Crédito</MenuItem>                                              
                    </Select>                    
                  </FormControl>
                </Grid>                
                <Grid item xs={12} id="formaPagamento">
                  {(formaPagamento === pag.CREDITO) && (
                    <CreditCardInput 
                    cardNumberInputProps={{ value: dadosPagamento.cardNumber, onChange: (e) => {
                      setDadosPagamento({
                        ...dadosPagamento,
                        cardNumber: e.target.value
                      })
                    }}}
                    cardExpiryInputProps={{ value: dadosPagamento.expiry, onChange: (e) => {
                      setDadosPagamento({
                        ...dadosPagamento,
                        expiry: e.target.value
                      })
                    }}}
                    cardCVCInputProps={{ value: dadosPagamento.cvc, onChange: (e) => {
                      setDadosPagamento({
                        ...dadosPagamento,
                        cvc: e.target.value
                      })
                    }}}
                    fieldClassName="input"
                    />
                  )}                  
                </Grid>
                <Grid item xs={6}>  
                {(formaPagamento === pag.BOLETO) &&
                  (<Button variant="contained" color="primary" className={classes.button} onClick={handleBoleto}>
                    GERAR BOLETO
                  </Button>)
                }                
                </Grid>
                <Grid item xs={6}>
                  <Button variant="contained" color="primary" className={classes.button} onClick={handleAgendar}>
                    Agendar
                  </Button>
                </Grid>
                <Grid item xs={6}>
                  <Button variant="contained" className={classes.button} onClick={handleClose}>
                    Fechar
                  </Button>
                </Grid>
              </Grid>
            </form>
          </div>
        </Fade>
      </Modal>
    </div>
  );
}
