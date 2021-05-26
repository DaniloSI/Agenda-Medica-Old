import React from "react";
import { isAuthenticated } from "./services/auth";
import { HashRouter, Route, Switch, Redirect } from "react-router-dom";

import Login from "./pages/Login";
import Cadastrar from "./pages/Cadastrar";
import CadastrarHorarios from "./pages/Profissional/CadastrarHorarios";
import BuscaProfissionais from "./pages/Paciente/BuscaProfissionais";
import Consultas from "./pages/Paciente/Consultas";
import ConsultasProfissional from "./pages/Profissional/ConsultasProfissional";
import GerenciamentoAgenda from "./pages/Profissional/GerenciamentoAgenda";
import Agendas from "./pages/Profissional/Agendas";
import Relatorio from "./pages/Profissional/Relatorio";
import AgendamentoHorario from "./pages/AgendamentoHorario";
// import pacienteConsultas from './pages/pacienteConsultas'
import Especialidades from "./pages/Admin/Especialidades";

const PrivateRoute = ({ component: Component, tipoUsuario, ...rest }) => (
  <Route
    {...rest}
    render={(props) =>
      isAuthenticated() &&
      (!tipoUsuario ||
        (tipoUsuario &&
          localStorage.getItem("TIPO_USUARIO") == tipoUsuario)) ? (
        <Component {...props} />
      ) : (
        <Redirect
          to={{
            pathname: process.env.PUBLIC_URL + "/",
            state: { from: props.location },
          }}
        />
      )
    }
  />
);

export default function Routes() {
  return (
    <HashRouter basename={process.env.PUBLIC_URL}>
      <Switch>
        <Route path="/" exact component={Login}></Route>
        <Route path="/Login" component={Login}></Route>
        <Route path="/Cadastrar" component={Cadastrar}></Route>
        <PrivateRoute
          path="/ConsultasPaciente"
          component={Consultas}
          tipoUsuario="0"
        ></PrivateRoute>
        <Route
          path="/ConsultasProfissional"
          component={ConsultasProfissional}
          tipoUsuario="1"
        ></Route>
        <PrivateRoute
          path="/GerenciamentoAgenda"
          exact
          component={GerenciamentoAgenda}
          tipoUsuario="1"
        ></PrivateRoute>
        <PrivateRoute
          path="/GerenciamentoAgenda/:agendaId"
          component={GerenciamentoAgenda}
          tipoUsuario="1"
        ></PrivateRoute>
        <PrivateRoute
          path="/Agendas"
          component={Agendas}
          tipoUsuario="1"
        ></PrivateRoute>
        <Route
          path="/BuscaProfissionais"
          component={BuscaProfissionais}
          tipoUsuario="0"
        ></Route>
        <Route
          path="/CadastrarHorarios"
          component={CadastrarHorarios}
          tipoUsuario="1"
        ></Route>
        <Route path="/AgendamentoHorario" component={AgendamentoHorario} />
        <Route path="/Relatorio" component={Relatorio} />
        <Route
          path="/Especialidades"
          component={Especialidades}
          tipoUsuario="2"
        ></Route>
        {/* <PrivateRoute path="/consultas" component={pacienteConsultas}/> */}
      </Switch>
    </HashRouter>
  );
}
