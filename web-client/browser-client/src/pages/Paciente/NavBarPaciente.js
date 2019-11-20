import React from 'react';
import NavBar from '../NavBar.js';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';
import EventNoteIcon from '@material-ui/icons/EventNote';
import SearchIcon from '@material-ui/icons/Search';


export default function NavBarPaciente(props) {
    return (
        <NavBar
            title="Paciente"
            history={props.history}
            listLeftMenu={
                <List>
                    <ListItem button key='Minha Agenda' onClick={() => props.history.push('/ConsultasPaciente')}>
                        <ListItemIcon>
                        <EventNoteIcon />
                        </ListItemIcon>
                        <ListItemText primary='Minhas Consultas' />
                    </ListItem>
                    <ListItem button key='Procurar Profissionais' onClick={() => props.history.push('/BuscaProfissionais')}>
                        <ListItemIcon>
                        <SearchIcon />
                        </ListItemIcon>
                        <ListItemText primary='Procurar Profissionais' />
                    </ListItem>
                </List>
            }
            content={
                props.content
            }
        />
    )
}