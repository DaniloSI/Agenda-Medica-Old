import React, { useEffect } from 'react';
import CssBaseline from '@material-ui/core/CssBaseline';
// import Typography from '@material-ui/core/Typography';
import Container from '@material-ui/core/Container'
import CardBuscaProfissionais from './CardBuscaProfissionais'
import api from '../../services/api';
import NavBarPaciente from './NavBarPaciente.js';
import { makeStyles } from '@material-ui/core/styles';
import Paper from '@material-ui/core/Paper';
import Grid from '@material-ui/core/Grid';
import TextField from '@material-ui/core/TextField';

import FormControl from '@material-ui/core/FormControl';
import Input from '@material-ui/core/Input';
import InputLabel from '@material-ui/core/InputLabel';
import MenuItem from '@material-ui/core/MenuItem';
import Select from '@material-ui/core/Select';
import Button from '@material-ui/core/Button';
import FilterListIcon from '@material-ui/icons/FilterList';


const useStyles = makeStyles(theme => ({
  root: {
    flexGrow: 1,
  },
  paper: {
    padding: theme.spacing(3),
    // textAlign: 'center',
    color: theme.palette.text.secondary,
  },
  formControl: {
    minWidth: '100%',
    textAlign: 'center',
    fullWidth: true,
  }
}));

export default function BuscaProfissionais({ history }) {
  const classes = useStyles();
  const [profissionais, setProfissionais] = React.useState([]);
  const [filtro, setFiltro] = React.useState({
    nome: '',
    EspecialidadesIds: []
  });
  const [especialidades, setEspecialidades] = React.useState([]);
  const handleChangeEspecialidade = event => {
    console.log('Selecionados, teóricamente: ', event.target.value);

    setFiltro({
      ...filtro,
      EspecialidadesIds: event.target.value
    });
  };

  function atualizaProfissionais() {
    api.post('/User/Profissionais', filtro)
      .then(response => {
          console.log(response.data);
          setProfissionais(response.data);
    });
  }

  useEffect(() => {
    atualizaProfissionais();
    api.get('/Especialidade')
      .then(response => {
          console.log(response.data);
          setEspecialidades(response.data);
    });
  }, []);

  return (
    <NavBarPaciente
      history={history}
      content={
          <div>
            <CssBaseline />
            <Grid container spacing={3}>
              <Grid item xs={12}>
                <Paper className={classes.paper}>
                  <Grid container spacing={3}>
                    <Grid item xs={12}>
                      <h3>Filtro</h3>
                    </Grid>
                    <Grid item xs={6}>
                      <TextField
                        id="Nome"
                        className={classes.textField}
                        label="Nome"
                        fullWidth
                        onChange={event => {
                          setFiltro({
                            ...filtro,
                            Nome: event.target.value
                          });
                        }}
                      />
                    </Grid>
                    <Grid item xs={6}>
                      <FormControl className={classes.formControl}>
                        <InputLabel id="especialidades-label">Especialidades</InputLabel>
                        <Select
                          labelid="especialidades-label"
                          className={classes.formControl}
                          id="especialidades"
                          multiple
                          value={filtro.EspecialidadesIds}
                          onChange={handleChangeEspecialidade}
                          input={<Input />}
                        >
                          {especialidades.map(especialidade => (
                            <MenuItem key={especialidade.especialidadeId} value={especialidade.especialidadeId}>
                              {especialidade.nome}
                            </MenuItem>
                          ))}
                        </Select>
                      </FormControl>
                    </Grid>
                  </Grid>
                  <Grid container spacing={3} justify="flex-end" alignContent="flex-end">
                    <Grid item>
                      <Button
                        variant="contained"
                        color="primary"
                        onClick={event => {
                          atualizaProfissionais();
                        }}
                      >
                        <FilterListIcon /> Filtrar
                      </Button>
                    </Grid>
                  </Grid>
                </Paper>
              </Grid>
              <Grid item xs={12}>
                <CardBuscaProfissionais profissionais={profissionais} />
              </Grid>
            </Grid>
            {/* <Container maxWidth="xl">
            </Container> */}
          </div>
      }
    />
  )
}