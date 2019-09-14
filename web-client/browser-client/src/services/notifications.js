import React from 'react';
import ReactDOM from 'react-dom';
import { toast, ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';


const configurations = {
    position: toast.POSITION.BOTTOM_LEFT,
    autoClose: false,
}

export function showError(message){
    toast.error(message, configurations);
    render();
}

export function showSuccess(message) {
    toast.success(message, configurations);
    render();
}

function render(){
    ReactDOM.render(
        <ToastContainer />,
        document.getElementById('notifications')
    );
}