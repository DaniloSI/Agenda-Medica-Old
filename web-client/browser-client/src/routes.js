import React from 'react';
import {BrowserRouter, Route} from 'react-router-dom';

import Login from './pages/Login'

export default function Routes(){
    return(
        <BrowserRouter>
            <Route path="/" exact component={Login}></Route>
            <Route path="/Login" component={Login}></Route>
        </BrowserRouter>
    )
}