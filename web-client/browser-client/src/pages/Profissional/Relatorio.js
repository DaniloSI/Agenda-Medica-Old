import React, { useEffect } from 'react'
import { makeStyles } from '@material-ui/core/styles';
import NavBarProfissional from './NavBarProfissional.js';
import Container from '@material-ui/core/Container';
import Paper from '@material-ui/core/Paper';
import Grid from '@material-ui/core/Grid';
import Typography from '@material-ui/core/Typography';
import InputLabel from '@material-ui/core/InputLabel';
import FormControl from '@material-ui/core/FormControl';
import Select from '@material-ui/core/Select';
import MenuItem from '@material-ui/core/MenuItem';
import {
    ResponsiveContainer, BarChart, Bar, Cell, XAxis, YAxis, CartesianGrid, Tooltip, Legend
} from 'recharts';
import { randomColor } from 'randomcolor';
import CssBaseline from '@material-ui/core/CssBaseline';
import * as Notifications from '../../services/notifications';
import api from '../../services/api';


const useStyles = makeStyles(theme => ({
    root: {
        flexGrow: 1,
    },
    paper: {
        padding: theme.spacing(2),
        textAlign: 'center',
        color: theme.palette.text.secondary,
    },
    formControl: {
        margin: theme.spacing(1),
        minWidth: 120,
    },
}));


function getEspecialidades(consultasTotais) {
    var especialidadesArray = [];
    consultasTotais.forEach(consultas => 
        especialidadesArray = especialidadesArray.concat(Object.keys(consultas).filter(prop => prop != "Mes"))
    );
    return Array.from(new Set(especialidadesArray));
}

export default function Relatorio(props) {
    const classes = useStyles();
    const [ano, setAno] = React.useState(new Date().getFullYear());
    const [mes, setMes] = React.useState(new Date().getMonth());
    const [consultasAno, setConsultasAno] = React.useState([]);
    const [consultasMes, setConsultasMes] = React.useState([]);
    const especialidades = getEspecialidades(consultasAno);

    function buscaConsultasAno(ano) {
        api.get('Consulta/RelatorioConsultasAno?ano=' + ano)
            .then(response => {
                setConsultasAno(response.data);
        });
    }

    function buscaConsultasMes(ano, mes) {
        api.get('Consulta/RelatorioConsultasMes?ano=' + ano + '&mes=' + (mes + 1))
            .then(response => {
                setConsultasMes(response.data);
        });
    }

    useEffect(() => {
        buscaConsultasAno(ano);
        buscaConsultasMes(ano, mes);
    }, [])

    return (
        <NavBarProfissional
            history={props.history}
            content={
                <Container maxWidth="xl">
                    <Grid container spacing={3}>
                        <Grid item xs={6}>
                            <Paper className={classes.paper}>
                                <Grid container spacing={3}>
                                    {/* Select - Ano */}
                                    <Grid item xs={12}>
                                        <FormControl className={classes.formControl}>
                                            <InputLabel htmlFor="ano">Ano</InputLabel>
                                            <Select
                                                value={ano}
                                                onChange={event => {
                                                    setAno(event.target.value);
                                                    buscaConsultasAno(event.target.value);
                                                    buscaConsultasMes(event.target.value, mes);
                                                }}
                                                inputProps={{
                                                    name: 'ano',
                                                    id: 'ano',
                                                }}
                                            >
                                                <MenuItem value={2018}>2018</MenuItem>
                                                <MenuItem value={2019}>2019</MenuItem>
                                                <MenuItem value={2020}>2020</MenuItem>
                                            </Select>
                                        </FormControl>
                                    </Grid>
                                    <Grid item xs={12}>
                                        <ResponsiveContainer height={400}>
                                            <BarChart
                                                data={consultasAno}
                                                margin={{
                                                    top: 5, right: 30, left: 20, bottom: 5,
                                                }}
                                            >
                                                <CartesianGrid strokeDasharray="3 3" />
                                                <XAxis dataKey="Mes" />
                                                <YAxis />
                                                <Tooltip />
                                                <Legend />
                                                {especialidades.map((especialidade, index) => 
                                                    <Bar dataKey={especialidade} stackId="totalConsultas" fill={randomColor({seed: especialidade})} />
                                                )}
                                            </BarChart>
                                        </ResponsiveContainer>
                                    </Grid>
                                </Grid>
                            </Paper>
                        </Grid>
                        <Grid item xs={6}>
                            <Paper className={classes.paper}>
                                <Grid container spacing={3}>
                                    {/* Select - Mês */}
                                    <Grid item xs={12}>
                                        <FormControl className={classes.formControl}>
                                            <InputLabel htmlFor="mes">Mês</InputLabel>
                                            <Select
                                                value={mes}
                                                onChange={event => {
                                                    setMes(event.target.value);
                                                    buscaConsultasMes(ano, event.target.value);
                                                }}
                                                inputProps={{
                                                    name: 'mes',
                                                    id: 'mes',
                                                }}
                                            >
                                                <MenuItem value={0}>Janeiro</MenuItem>
                                                <MenuItem value={1}>Fevereiro</MenuItem>
                                                <MenuItem value={2}>Março</MenuItem>
                                                <MenuItem value={3}>Abril</MenuItem>
                                                <MenuItem value={4}>Maio</MenuItem>
                                                <MenuItem value={5}>Junho</MenuItem>
                                                <MenuItem value={6}>Julho</MenuItem>
                                                <MenuItem value={7}>Agosto</MenuItem>
                                                <MenuItem value={8}>Setembro</MenuItem>
                                                <MenuItem value={9}>Outubro</MenuItem>
                                                <MenuItem value={10}>Novembro</MenuItem>
                                                <MenuItem value={11}>Dezembro</MenuItem>
                                            </Select>
                                        </FormControl>
                                    </Grid>
                                    <Grid item xs={12}>
                                        <ResponsiveContainer height={400}>
                                            <BarChart
                                                data={consultasMes}
                                                margin={{
                                                    top: 5, right: 30, left: 20, bottom: 5,
                                                }}
                                            >
                                                <CartesianGrid strokeDasharray="3 3" />
                                                <XAxis dataKey="Dia" tick={({ x, y, payload }) =>
                                                    <g transform={`translate(${x},${y})`}>
                                                        <text x={0} y={0} dy={16} textAnchor="end" fill="#666">{new Date(payload.value).getDate()}</text>
                                                    </g>
                                                } />
                                                <YAxis />
                                                <Tooltip
                                                    labelFormatter={(value) => ( new Date(value).toLocaleDateString() )}
                                                />
                                                <Legend />
                                                {especialidades.map((especialidade, index) => 
                                                    <Bar dataKey={especialidade} stackId="totalConsultas" fill={randomColor({seed: especialidade})} />
                                                )}
                                            </BarChart>
                                        </ResponsiveContainer>
                                    </Grid>
                                </Grid>
                            </Paper>
                        </Grid>
                        <Grid item xs={12}>
                            <Paper className={classes.paper}>
                            <Typography variant="h5" gutterBottom>
                                Tabela do Relatório
                            </Typography>
                            </Paper>
                        </Grid>
                    </Grid>
                </Container>
            }
        />
    )
}
