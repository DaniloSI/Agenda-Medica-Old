import React from 'react';
import NavBar from '../NavBar.js';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';
import ListIcon from '@material-ui/icons/List';


export default function NavBarAdmin(props) {
    return (
        <NavBar
            title="Admin"
            history={props.history}
            listLeftMenu={
                <List>
                    <ListItem button key='Especialidades' onClick={() => props.history.push('/Especialidades')}>
                        <ListItemIcon>
                            <ListIcon />
                        </ListItemIcon>
                        <ListItemText primary='Especialidades' />
                    </ListItem>
                </List>
            }
            content={
                props.content
            }
        />
    )
}