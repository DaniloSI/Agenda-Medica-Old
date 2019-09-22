import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Card from '@material-ui/core/Card';
import CardHeader from '@material-ui/core/CardHeader';
import Avatar from '@material-ui/core/Avatar';
import Typography from '@material-ui/core/Typography';
import { red } from '@material-ui/core/colors';
import AgendarHorarioBuscaProfissional from './AgendarHorarioBuscaProfissional';
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

export default function CardBuscaProfissionais(props) {
  const classes = useStyles();
  const profissionais = props.profissionais;

  return (
    profissionais.map(profissional => 
      <Card className={classes.card} key={profissional.id}>
        <CardHeader
          avatar={
            <Avatar aria-label="recipe" className={classes.avatar}>
              {profissional.nomeCompleto.substring(0, 1)}
            </Avatar>
          }
          action={
            <Grid container>
              <Grid container justify="flex-end" direction="row">
                <AgendarHorarioBuscaProfissional profissional={profissional} />
              </Grid>
              <Grid container justify="flex-end" direction="row">
                <Button color="secondary" size="small"  className={classes.button}>
                  <VisibilityIcon className={classes.leftIcon} />
                  Visualizar Perfil
                </Button>
              </Grid>
            </Grid>
          }
          title={profissional.nomeCompleto}
          subheader={
            <Grid container>
              <Grid item xs={12}>
                <Typography variant="body2" color="textSecondary" component="p">
                  {profissional.endereco}
                </Typography>
              </Grid>
              <Grid item xs={12}>
                <Rating size="small" precision={0.5} value={profissional.avaliacao} readOnly />
              </Grid>
              <Grid item xs={12}>
                {profissional.especialidades && profissional.especialidades.map((especialidade, index) =>
                  <Chip size="small" label={especialidade.nome} className={classes.chip} key={especialidade.especialidadeId}/>
                )}
              </Grid>
            </Grid>
          }
        />
      </Card>
    )
  );
}
