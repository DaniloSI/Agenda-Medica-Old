import React from 'react';
import {isAuthenticated} from './services/auth';
import { BrowserRouter, Route, Switch, Redirect } from 'react-router-dom';

import Login from './pages/Login'
import Cadastrar from './pages/Cadastrar'
import CadastrarHorarios from './pages/Profissional/CadastrarHorarios'
import BuscaProfissionais from './pages/Paciente/BuscaProfissionais'
import Consultas from './pages/Paciente/Consultas'

import AgendamentoHorario from './pages/AgendamentoHorario'
// import pacienteConsultas from './pages/pacienteConsultas'

const PrivateRoute = ({component: Component, ...rest}) => (
    <Route
        {...rest}
        render = {
            props => isAuthenticated() ? 
            (<Component {...props}/>) : 
            (<Redirect to={{ pathname: '/', state: { from: props.location }}}/>)
        }
    />
);

export default function Routes() {
    return (
        <BrowserRouter>
            <Switch>
                <Route path="/" exact component={Login}></Route>
                <Route path="/Login" component={Login}></Route>
                <Route path="/Cadastrar" component={Cadastrar}></Route>
                <Route path="/ConsultasPaciente" component={Consultas}></Route>
                <Route path="/BuscaProfissionais" component={BuscaProfissionais}></Route>
                <Route path="/CadastrarHorarios" component={CadastrarHorarios}></Route>
                <Route path="/AgendamentoHorario" component={AgendamentoHorario}/>
                {/* <PrivateRoute path="/consultas" component={pacienteConsultas}/> */}
            </Switch>
        </BrowserRouter>
    )
}