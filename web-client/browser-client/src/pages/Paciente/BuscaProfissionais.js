import React from 'react';
import ReactDOM from 'react-dom';
import CssBaseline from '@material-ui/core/CssBaseline';
// import Typography from '@material-ui/core/Typography';
import Container from '@material-ui/core/Container'
import CardBuscaProfissionais from './CardBuscaProfissionais'
import api from '../../services/api';
import NavBarPaciente from './NavBarPaciente.js';


export default function BuscaProfissionais({ history }) {

  async function showProfissionais() {
    const response = await api.get("/User/Profissionais");
    const profissionais = response.data;

    ReactDOM.render(
      <CardBuscaProfissionais profissionais={profissionais} />,
      document.getElementById('cards-profissionais')
    );
  }

  showProfissionais()

  return (
    <NavBarPaciente
      history={history}
      content={
          <div>
            <CssBaseline />
            <Container maxWidth="xl">
                <div id="cards-profissionais">
                </div>
            </Container>
          </div>
      }
    />
  )
}