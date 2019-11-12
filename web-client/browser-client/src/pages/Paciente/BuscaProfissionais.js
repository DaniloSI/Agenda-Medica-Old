import React, { useEffect } from 'react';
import CssBaseline from '@material-ui/core/CssBaseline';
// import Typography from '@material-ui/core/Typography';
import Container from '@material-ui/core/Container'
import CardBuscaProfissionais from './CardBuscaProfissionais'
import api from '../../services/api';
import NavBarPaciente from './NavBarPaciente.js';


export default function BuscaProfissionais({ history }) {
  const [profissionais, setProfissionais] = React.useState([]);

  useEffect(() => {
    api.post('/User/Profissionais', {
      Nome: "",
      EspecialidadesIds: []
    })
      .then(response => {
          console.log(response.data);
          setProfissionais(response.data);
    });
  }, []);

  return (
    <NavBarPaciente
      history={history}
      content={
          <div>
            <CssBaseline />
            <Container maxWidth="xl">
              <CardBuscaProfissionais profissionais={profissionais} />
            </Container>
          </div>
      }
    />
  )
}