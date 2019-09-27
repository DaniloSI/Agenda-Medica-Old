import React from 'react'
import { makeStyles } from '@material-ui/core/styles';
import CssBaseline from '@material-ui/core/CssBaseline';
import Container from '@material-ui/core/Container';
import NavBarProfissional from './NavBarProfissional.js';
import Box from '@material-ui/core/Box';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemSecondaryAction from '@material-ui/core/ListItemSecondaryAction';
import ListItemText from '@material-ui/core/ListItemText';
import ListSubheader from '@material-ui/core/ListSubheader';
import IconButton from '@material-ui/core/IconButton';
import DeleteIcon from '@material-ui/icons/Delete';


const useStyles = makeStyles(theme => ({
    root: {
      width: '100%',
      maxWidth: 360,
      backgroundColor: theme.palette.background.paper,
    },
  }));

export default function GerenciamentoAgenda(props) {
    const classes = useStyles();
    const diasSemana = [
        "Domingo",
        "Segunda-Feira",
        "Terça-Feira",
        "Quarta-Feira",
        "Quinta-Feira",
        "Sexta-Feira",
        "Sábado"
    ];
    const horarios = [
        {
            horarioId : 1,
            diaSemana: 0,
            horaInicio: '08:00',
            horaFim: '09:00'
        },
        {
            horarioId : 2,
            diaSemana: 0,
            horaInicio: '09:00',
            horaFim: '10:00'
        },
        {
            horarioId : 3,
            diaSemana: 1,
            horaInicio: '08:00',
            horaFim: '09:00'
        },
        {
            horarioId : 4,
            diaSemana: 1,
            horaInicio: '09:00',
            horaFim: '10:00'
        },
        {
            horarioId : 5,
            diaSemana: 2,
            horaInicio: '08:00',
            horaFim: '09:00'
        },
        {
            horarioId : 6,
            diaSemana: 2,
            horaInicio: '09:00',
            horaFim: '10:00'
        },
        {
            horarioId : 7,
            diaSemana: 3,
            horaInicio: '08:00',
            horaFim: '09:00'
        },
        {
            horarioId : 8,
            diaSemana: 3,
            horaInicio: '09:00',
            horaFim: '10:00'
        }
    ];

    return (
        <NavBarProfissional
            history={props.history}
            content={
                <div>
                    <CssBaseline />
                    <Container maxWidth="lg" style={{ height: '20vh' }}>
                        
                    </Container>
                    <br />
                    <Container maxWidth="xl">
                        <Box width="100%" height={100} display="flex" alignItems="flex-start">
                            {diasSemana.map((diaSemana, index) => 
                                <Box width={1 / diasSemana.length} p={1} display="inline-block" maxHeight={5}>
                                    <List subheader={<ListSubheader>{diaSemana}</ListSubheader>} className={classes.root} bgcolor="background.paper" key={index}>
                                        {horarios.filter(h => h.diaSemana == index)
                                            .map(h => 
                                                <ListItem key={h.horarioId}>
                                                    <ListItemText id={h.horarioId} primary={"De " + h.horaInicio + " às " + h.horaFim} />
                                                    <ListItemSecondaryAction>
                                                        <IconButton edge="end" aria-label="delete">
                                                            <DeleteIcon />
                                                        </IconButton>
                                                    </ListItemSecondaryAction>
                                                </ListItem>
                                            )}
                                    </List>
                                </Box>
                            )}
                        </Box>
                    </Container>
                </div>
            }
        />
    )
}
