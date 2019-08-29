import React from 'react';
import {isAuthenticated} from './services/auth';
import { BrowserRouter, Route, Switch, Redirect } from 'react-router-dom';

import Login from './pages/Login'
import Cadastrar from './pages/Cadastrar'
import Home from './pages/Home'

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
                <PrivateRoute path="/Home" component={Home}/>
            </Switch>
        </BrowserRouter>
    )
}