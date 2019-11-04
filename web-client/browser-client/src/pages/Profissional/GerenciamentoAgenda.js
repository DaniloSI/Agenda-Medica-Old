import React, { useEffect } from 'react'
import Typography from '@material-ui/core/Typography';
import { makeStyles } from '@material-ui/core/styles';
import CssBaseline from '@material-ui/core/CssBaseline';
import Container from '@material-ui/core/Container';
import NavBarProfissional from './NavBarProfissional.js';
import Box from '@material-ui/core/Box';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemSecondaryAction from '@material-ui/core/ListItemSecondaryAction';
import ListItemText from '@material-ui/core/ListItemText';
import ListSubheader from '@material-ui/core/ListSubheader';
import IconButton from '@material-ui/core/IconButton';
import DeleteIcon from '@material-ui/icons/Delete';
import SaveIcon from '@material-ui/icons/Save';
import TextField from '@material-ui/core/TextField';
import DateFnsUtils from '@date-io/date-fns';
import {
    MuiPickersUtilsProvider,
    KeyboardDatePicker
} from '@material-ui/pickers';
import Grid from '@material-ui/core/Grid';
import Paper from '@material-ui/core/Paper';
import AdicionarHorario from './AdicionarHorario';
import clsx from 'clsx';
import Button from '@material-ui/core/Button';
import * as Notifications from '../../services/notifications';
import api from '../../services/api';
import InputAdornment from '@material-ui/core/InputAdornment';
import NumberFormat from 'react-number-format';
import PropTypes from 'prop-types';


const useStyles = makeStyles(theme => ({
    root: {
      width: '100%',
      maxWidth: 360,
      backgroundColor: theme.palette.background.paper,
    },
    paper: {
        padding: theme.spacing(3),
    },
    saveButton: {
        position: "fixed",
        margin: theme.spacing(1),
        bottom: theme.spacing(2),
        right: theme.spacing(17)
    },
    closeButton: {
        position: "fixed",
        margin: theme.spacing(1),
        bottom: theme.spacing(2),
        right: theme.spacing(6)
    },
    extendedIcon: {
        marginRight: theme.spacing(1),
    },
}));


function NumberFormatCustom(props) {
    const { inputRef, onChange, ...other } = props;

    return (
        <NumberFormat
            {...other}
            getInputRef={inputRef}
            onValueChange={values => {
                onChange({
                    target: {
                        value: values.value,
                    },
                });
            }}
            thousandSeparator="."
            decimalSeparator=","
            isNumericString
            prefix="R$ "
        />
    );
}

NumberFormatCustom.propTypes = {
    inputRef: PropTypes.func.isRequired,
    onChange: PropTypes.func.isRequired,
};

function FormularioAgenda(props) {
    const classes = useStyles();
    const diasSemana = [
        "Domingo",
        "Segunda-Feira",
        "Terça-Feira",
        "Quarta-Feira",
        "Quinta-Feira",
        "Sexta-Feira",
        "Sábado"
    ];
    const [horarios, setHorarios] = React.useState([]);
    const [dataInicio, setDataInicio] = React.useState(null);
    const [dataFim, setDataFim] = React.useState(null);
    const [titulo, setTitulo] = React.useState('');
    const [precoConsulta, setPrecoConsulta] = React.useState('');
    const agendaId = props.match.params.agendaId;

    useEffect(() => {
        if (agendaId) {
            api.get('/Agenda?agendaId=' + agendaId)
                .then(response => {
                    setHorarios(response.data.horarios);
                    setDataInicio(response.data.dataHoraInicio);
                    setDataFim(response.data.dataHoraFim);
                    setTitulo(response.data.titulo);
                    setPrecoConsulta(response.data.precoConsulta);
            });
        }
    }, [])

    async function SalvarAgenda() {
        const response = await api.post('/Agenda',
        {
            agendaId,
            titulo,
            dataHoraInicio: dataInicio,
            dataHoraFim: dataFim,
            precoConsulta,
            horarios
        });

        if (response.data.validationResult.isValid) {
            Notifications.showSuccess("Agenda salva/alterada com sucesso!");
            props.history.push('/Agendas');            
        } else {
            response.data.validationResult.errors.forEach(function (error) {
                Notifications.showError(error.errorMessage);
            });
        }
    }

    return (
        <div>
            <CssBaseline />
            <Container maxWidth="xl">
                <Box mb={5}>
                    <Paper className={classes.paper}>
                        <Typography variant="h5" component="h6">Agenda</Typography>
                        <br />
                        <form noValidate autoComplete="off" >
                            <Grid container spacing={3} justify="flex-start" direction="row">
                                <Grid item xs={6}>
                                    <TextField
                                        id="titulo"
                                        label="Título"
                                        width="100%"
                                        fullWidth
                                        value={titulo}
                                        onChange={(t) => setTitulo(t.target.value)}
                                    />
                                </Grid>
                                <Grid item xs={2}>
                                    
                                    <TextField
                                        id="precoConsulta"
                                        label="Preço da Consulta"
                                        width="100%"
                                        fullWidth
                                        InputProps={{
                                            inputComponent: NumberFormatCustom,
                                        }}
                                        value={precoConsulta}
                                        onChange={(t) => setPrecoConsulta(t.target.value)}
                                    />

                                </Grid>
                                <Grid item xs={2}>
                                    <MuiPickersUtilsProvider utils={DateFnsUtils}>
                                        <KeyboardDatePicker
                                            id="date-picker-data-inicio-vigencia"
                                            label="Início da Vigência"
                                            format="MM/dd/yyyy"
                                            fullWidth
                                            value={dataInicio}
                                            onChange={(data) => {
                                                if (data != null) {
                                                    data = new Date(data.getFullYear(), data.getMonth(), data.getDate());
                                                }
                                                setDataInicio(data);
                                            }}
                                            KeyboardButtonProps={{
                                                'aria-label': 'change date',
                                            }}
                                        />
                                    </MuiPickersUtilsProvider>
                                </Grid>
                                <Grid item xs={2}>
                                    <MuiPickersUtilsProvider utils={DateFnsUtils}>
                                        <KeyboardDatePicker
                                            id="date-picker-data-fim-vigencia"
                                            label="Fim da Vigência"
                                            format="MM/dd/yyyy"
                                            fullWidth
                                            value={dataFim}
                                            onChange={(data) => {
                                                if (data != null) {
                                                    data = new Date(data.getFullYear(), data.getMonth(), data.getDate());
                                                }
                                                setDataFim(data);
                                            }}
                                            KeyboardButtonProps={{
                                                'aria-label': 'change date',
                                            }}
                                        />
                                    </MuiPickersUtilsProvider>
                                </Grid>
                                <Grid item xs={12}>
                                    <Box display="flex" justifyContent="flex-end">
                                        <AdicionarHorario callBackAdicionar={(h) => {
                                            var novosHorarios = horarios.slice();
                                            novosHorarios.push(h);
                                            setHorarios(old => novosHorarios);
                                        }}/>
                                    </Box>
                                </Grid>
                            </Grid>
                        </form>
                    </Paper>
                </Box>
            </Container>
            <Container maxWidth="xl">
                <Box width="100%" height={100} display="flex" alignItems="flex-start">
                    {diasSemana.map((diaSemana, index) => 
                        <Box width={1 / diasSemana.length} p={1} display="inline-block" maxHeight={5} key={index}>
                            <List subheader={<ListSubheader>{diaSemana}</ListSubheader>} className={classes.root} bgcolor="background.paper">
                                {horarios.filter(h => h.diaSemana == index)
                                    .map((h, indexHorario) => 
                                        <ListItem key={indexHorario}>
                                            <ListItemText id={h.horarioId} primary={"De " + h.horaInicio + " às " + h.horaFim} />
                                            <ListItemSecondaryAction>
                                                <IconButton
                                                    edge="end"
                                                    aria-label="delete"
                                                    onClick={() => {
                                                        setHorarios(horarios.filter(horario => horario != h));
                                                    }}
                                                >
                                                    <DeleteIcon />
                                                </IconButton>
                                            </ListItemSecondaryAction>
                                        </ListItem>
                                    )}
                            </List>
                        </Box>
                    )}
                </Box>
                <Button
                    variant="contained"
                    color="primary"
                    size="small"
                    className={classes.saveButton}
                    onClick={SalvarAgenda}
                >
                    <SaveIcon className={clsx(classes.leftIcon, classes.iconSmall)} />
                    &nbsp;
                    Salvar
                </Button>
                <Button variant="contained" size="small" className={classes.closeButton} onClick={() => props.history.push('/Agendas')}>
                    Fechar
                </Button>
            </Container>
        </div>
    );
}

export default function GerenciamentoAgenda(props) {
    return (
        <NavBarProfissional
            history={props.history}
            content={
                <FormularioAgenda
                    history={props.history}
                    match={props.match}
                />
            }
        />
    )
}
