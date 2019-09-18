import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Card from '@material-ui/core/Card';
import CardHeader from '@material-ui/core/CardHeader';
import Avatar from '@material-ui/core/Avatar';
import Typography from '@material-ui/core/Typography';
import { red } from '@material-ui/core/colors';
import EventAvailableIcon from '@material-ui/icons/EventAvailable';
import Rating from '@material-ui/lab/Rating';
import Chip from '@material-ui/core/Chip';
import Grid from '@material-ui/core/Grid';
import Button from '@material-ui/core/Button';
import VisibilityIcon from '@material-ui/icons/Visibility';


const useStyles = makeStyles(theme => ({
  card: {
    marginBottom: theme.spacing(1.5)
  },
  avatar: {
    backgroundColor: red[500],
  },
  chip: {
    marginRight: theme.spacing(1),
  },
  button: {
    margin: theme.spacing(1),
  },
  leftIcon: {
    marginRight: theme.spacing(1),
  },
}));

export default function RecipeReviewCard() {
  const classes = useStyles();
  const profissionais = [
    {
      NomeCompleto: "Marlene Esther Ayla Nunes",
      Endereco: "Endereço: R. Coelho Filho, 38 - Parque Res. Laranjeiras, Serra - ES, 29191-275",
      Especialidades: [
        "Clínico Geral",
        "Fisioterapeuta",
        "Ortopedista"
      ],
      Avaliacao: 4.5
    },
    {
      NomeCompleto: "Fábio Raul Moraes",
      Endereco: "Endereço: R. Coelho Sobrinho, 83 - Morada de Laranjeiras, Serra - ES, 29191-123",
      Especialidades: [
        "Pediatra",
        "Fisioterapeuta"
      ],
      Avaliacao: 4
    },
    {
      NomeCompleto: "Fábio Raul Moraes",
      Endereco: "Endereço: R. Coelho Sobrinho, 83 - Morada de Laranjeiras, Serra - ES, 29191-123",
      Especialidades: [
        "Pediatra",
        "Fisioterapeuta"
      ],
      Avaliacao: 4
    },
    {
      NomeCompleto: "Fábio Raul Moraes",
      Endereco: "Endereço: R. Coelho Sobrinho, 83 - Morada de Laranjeiras, Serra - ES, 29191-123",
      Especialidades: [
        "Pediatra",
        "Fisioterapeuta"
      ],
      Avaliacao: 4
    },
    {
      NomeCompleto: "Fábio Raul Moraes",
      Endereco: "Endereço: R. Coelho Sobrinho, 83 - Morada de Laranjeiras, Serra - ES, 29191-123",
      Especialidades: [
        "Pediatra",
        "Fisioterapeuta"
      ],
      Avaliacao: 4
    },
    {
      NomeCompleto: "Fábio Raul Moraes",
      Endereco: "Endereço: R. Coelho Sobrinho, 83 - Morada de Laranjeiras, Serra - ES, 29191-123",
      Especialidades: [
        "Pediatra",
        "Fisioterapeuta"
      ],
      Avaliacao: 4
    },
    {
      NomeCompleto: "Fábio Raul Moraes",
      Endereco: "Endereço: R. Coelho Sobrinho, 83 - Morada de Laranjeiras, Serra - ES, 29191-123",
      Especialidades: [
        "Pediatra",
        "Fisioterapeuta"
      ],
      Avaliacao: 4
    },
    {
      NomeCompleto: "Fábio Raul Moraes",
      Endereco: "Endereço: R. Coelho Sobrinho, 83 - Morada de Laranjeiras, Serra - ES, 29191-123",
      Especialidades: [
        "Pediatra",
        "Fisioterapeuta"
      ],
      Avaliacao: 4
    },
    {
      NomeCompleto: "Fábio Raul Moraes",
      Endereco: "Endereço: R. Coelho Sobrinho, 83 - Morada de Laranjeiras, Serra - ES, 29191-123",
      Especialidades: [
        "Pediatra",
        "Fisioterapeuta"
      ],
      Avaliacao: 4
    },
    {
      NomeCompleto: "Fábio Raul Moraes",
      Endereco: "Endereço: R. Coelho Sobrinho, 83 - Morada de Laranjeiras, Serra - ES, 29191-123",
      Especialidades: [
        "Pediatra",
        "Fisioterapeuta"
      ],
      Avaliacao: 4
    },
    {
      NomeCompleto: "Fábio Raul Moraes",
      Endereco: "Endereço: R. Coelho Sobrinho, 83 - Morada de Laranjeiras, Serra - ES, 29191-123",
      Especialidades: [
        "Pediatra",
        "Fisioterapeuta"
      ],
      Avaliacao: 4
    },
    {
      NomeCompleto: "Fábio Raul Moraes",
      Endereco: "Endereço: R. Coelho Sobrinho, 83 - Morada de Laranjeiras, Serra - ES, 29191-123",
      Especialidades: [
        "Pediatra",
        "Fisioterapeuta"
      ],
      Avaliacao: 4
    },
    {
      NomeCompleto: "Fábio Raul Moraes",
      Endereco: "Endereço: R. Coelho Sobrinho, 83 - Morada de Laranjeiras, Serra - ES, 29191-123",
      Especialidades: [
        "Pediatra",
        "Fisioterapeuta"
      ],
      Avaliacao: 4
    },
    {
      NomeCompleto: "Fábio Raul Moraes",
      Endereco: "Endereço: R. Coelho Sobrinho, 83 - Morada de Laranjeiras, Serra - ES, 29191-123",
      Especialidades: [
        "Pediatra",
        "Fisioterapeuta"
      ],
      Avaliacao: 4
    }
  ];

  return (
    profissionais.map(profissional => 
      <Card className={classes.card}>
        <CardHeader
          avatar={
            <Avatar aria-label="recipe" className={classes.avatar}>
              {profissional.NomeCompleto.substring(0, 1)}
            </Avatar>
          }
          action={
            <Grid>
              <Grid container xs={12} justify="flex-end" direction="row">
                <Button color="primary" size="small" className={classes.button}>
                  <EventAvailableIcon className={classes.leftIcon} />
                  Agendar Horário
                </Button>
              </Grid>
              <Grid container xs={12} justify="flex-end" direction="row">
                <Button color="secondary" size="small"  className={classes.button}>
                  <VisibilityIcon className={classes.leftIcon} />
                  Visualizar Perfil
                </Button>
              </Grid>
            </Grid>
          }
          title={profissional.NomeCompleto}
          subheader={
            <Grid container>
              <Grid item xs={12}>
                <Typography variant="body2" color="textSecondary" component="p">
                  {profissional.Endereco}
                </Typography>
              </Grid>
              <Grid item xs={12}>
                <Rating size="small" precision={0.5} value={profissional.Avaliacao} readOnly />
              </Grid>
              <Grid item xs={12}>
                {profissional.Especialidades.map(especialidade =>
                  <Chip size="small" label={especialidade} className={classes.chip} />
                )}
              </Grid>
            </Grid>
          }
        />
      </Card>
    )
  );
}
