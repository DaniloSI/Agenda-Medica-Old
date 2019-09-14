import React from 'react';
import ReactDOM from 'react-dom';
import { toast, ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';


export function showError(message){
    toast.error(message, {
        position: toast.POSITION.BOTTOM_LEFT,
        autoClose: 10000
    });
    render();
}

export function showSuccess(message) {
    toast.success(message,  {
        position: toast.POSITION.BOTTOM_LEFT,
        autoClose: 6000
    });
    render();
}

function render(){
    ReactDOM.render(
        <ToastContainer />,
        document.getElementById('notifications')
    );
}