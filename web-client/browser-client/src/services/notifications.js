import React from 'react';

export const notific = ({message, ...rest}) =>{
    return(
        <h1>{message}</h1>
    )
}

export function showNotification({message}){
    return(
        <p>Olá mundo {message}</p>
    )
}

export function showError(message){
    return (
        <p>Olá mundo</p>
    )
}

export function showSuccess(message){
    return (
        <p>Olá mundo</p>
    )
}