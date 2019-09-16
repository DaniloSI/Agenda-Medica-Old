import React, { useState } from 'react';
import { login } from '../services/auth';
import api from '../services/api';
import { makeStyles } from '@material-ui/core/styles';
import TextField from '@material-ui/core/TextField';
import Container from '@material-ui/core/Container';
import Card from '@material-ui/core/Card';
import CardContent from '@material-ui/core/CardContent';
import CardActions from '@material-ui/core/CardActions';
import Button from '@material-ui/core/Button';
import Typography from '@material-ui/core/Typography';
import Box from '@material-ui/core/Box';

import * as Notifications from '../services/notifications';

export default function Login({ history }) {

  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');

  if (history.location.state && history.location.state.cadastroSucesso) {
    Notifications.showSuccess("Usuário cadastrado com sucesso!");
    history.replace('/Login', null);
  }

  async function handleSubmit(e) {
    e.preventDefault();

    const response = await api.post('/User/Login',
      {
        email,
        password,
      });

    const { token } = response.data;

    if(token !== null) login(token);

    history.push('/Home');
  }

  const useStyles = makeStyles(theme => ({
    root: {
      flexGrow: 1,
    },
    card: {
      width: '60%',
      margin: theme.spacing(2),
      marginTop: '250px',
      margin: 'auto',
      maxWidth: 500, 
    },
    textField: {
      marginLeft: theme.spacing(1),
      marginRight: theme.spacing(1),
      paddingRight: '25px'
    },
    button: {
      margin: theme.spacing(1),
    },
  }));

  const classes = useStyles();

  return (
    <div className={classes.root}>
      <Container fixed>
        <Card className={classes.card}>
          <CardContent>
            <Typography gutterBottom variant="h5" component="h2">
              Login
            </Typography>
            <form onSubmit={handleSubmit}>
              <TextField
                id="email"
                label="E-mail"
                className={classes.textField}
                onChange={e => setEmail(e.target.value)}
                fullWidth
                margin="normal"
                />
              <TextField
                id="password"
                label="Password"
                className={classes.textField}
                onChange={e => setPassword(e.target.value)}
                fullWidth
                type="password"
                autoComplete="current-password"
                margin="normal"
                />
              <CardActions>
                <Box display="flex" flexDirection="row-reverse" width="100%" p={1} m={1} bgcolor="background.paper">
                  <Box p={1}>
                    <Button variant="contained" color="secondary" className={classes.button} onClick={() => history.push('/Cadastrar')}>
                      Cadastrar
                    </Button>
                  </Box>
                  <Box p={1}>
                    <Button variant="contained" color="primary" className={classes.button} type="submit">
                      Entrar
                    </Button>
                  </Box>
                </Box>
              </CardActions>
            </form>
          </CardContent>
        </Card>
      </Container>
    </div>
  );
}