import React from 'react';
import CssBaseline from '@material-ui/core/CssBaseline';
// import Typography from '@material-ui/core/Typography';
import Container from '@material-ui/core/Container'
import CardBuscaProfissionais from './CardBuscaProfissionais'


export default function BuscaProfissionais() {
    return (
        <div>
            <CssBaseline />
            <Container fixed>
                {/* <Typography component="div" style={{ backgroundColor: '#cfe8fc', height: '100vh' }} /> */}
                <CardBuscaProfissionais />
            </Container>
        </div>
    )
}