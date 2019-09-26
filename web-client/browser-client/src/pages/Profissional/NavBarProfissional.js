import React from 'react';
import NavBar from '../NavBar.js';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';
import EventNoteIcon from '@material-ui/icons/EventNote';
import DateRangeIcon from '@material-ui/icons/DateRange';

export default function NavBarProfissional(props) {
    return (
        <NavBar
            title="Profissional"
            history={props.history}
            listLeftMenu={
                <List>
                    <ListItem
                        button
                        key='Consultas'
                        // onClick={
                        //     () => props.history.push('/ConsultasPaciente')
                        // }
                        >
                        <ListItemIcon>
                        <EventNoteIcon />
                        </ListItemIcon>
                        <ListItemText primary='Consultas' />
                    </ListItem>
                    <ListItem
                        button
                        key='Gerenciar Agendas'
                        // onClick={
                        //     () => props.history.push('/BuscaProfissionais')
                        // }
                    >
                        <ListItemIcon>
                        <DateRangeIcon />
                        </ListItemIcon>
                        <ListItemText primary='Gerenciar Agendas' />
                    </ListItem>
                </List>
            }
            content={
                props.content
            }
        />
    )
}