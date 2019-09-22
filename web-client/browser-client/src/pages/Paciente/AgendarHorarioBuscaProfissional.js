import React from 'react';
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
import MenuItem from '@material-ui/core/MenuItem';
import * as Notifications from '../../services/notifications';
import {
  MuiPickersUtilsProvider,
  KeyboardDatePicker,
} from '@material-ui/pickers';

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
    minWidth: 250,
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
  const [open, setOpen] = React.useState(false);
  const [selectedDate, setSelectedDate] = React.useState(new Date());
  const [horario, setHorario] = React.useState({
    horarioId: '',
    Intervalo: '',
  });
  const [especialidade, setEspecialidade] = React.useState({
    especialidadeId: '',
    intervalo: '',
  });

  function handleChangeHorario(event) {
    console.log(event)
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

  function handleDateChange(date) {
    setSelectedDate(date);
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
  };

  const handleAgendar = () => {
    setOpen(false);
    setHorario(oldHorario => ({
      ...oldHorario,
      'horarioId': '',
    }));
    Notifications.showSuccess("Horário agendado com sucesso!");
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
                      <MenuItem value={'1'}>De 05:00 às 06:00</MenuItem>
                      <MenuItem value={'2'}>De 06:00 às 07:00</MenuItem>
                      <MenuItem value={'3'}>De 07:00 às 08:00</MenuItem>
                    </Select>
                  </FormControl>
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
