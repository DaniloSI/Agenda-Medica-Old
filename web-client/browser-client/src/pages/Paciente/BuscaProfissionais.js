import React from 'react';
import ReactDOM from 'react-dom';
import CssBaseline from '@material-ui/core/CssBaseline';
// import Typography from '@material-ui/core/Typography';
import Container from '@material-ui/core/Container'
import CardBuscaProfissionais from './CardBuscaProfissionais'
import api from '../../services/api';


export default function BuscaProfissionais() {

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
      <div>
          <CssBaseline />
          <Container fixed>
              <div id="cards-profissionais">
              </div>
          </Container>
      </div>
  )
}