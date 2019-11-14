import React from 'react';
import NavBar from '../NavBar.js';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';
import EventNoteIcon from '@material-ui/icons/EventNote';
import SearchIcon from '@material-ui/icons/Search';
import AttachMoneyIcon from '@material-ui/icons/AttachMoney';
import Modal from '@material-ui/core/Modal';

import Gif from '../../assets/tenor.gif';


export default function NavBarPaciente(props) {

    const [openModal, setOpenModal] = React.useState(false);

    function handleEstorno() {
        setOpenModal(!openModal);
    }

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
                    <ListItem button key='Estorno de Pagamento' onClick={handleEstorno}>
                        <ListItemIcon>
                        <AttachMoneyIcon />
                        </ListItemIcon>
                        <ListItemText primary='Estorno de Pagamento' />
                    </ListItem>
                    <Modal
                        open={openModal}
                        onClose={handleEstorno}
                        style={{
                            display: 'flex',
                            alignItems: 'center',
                            justifyContent: 'center',
                          }}
                    >
                        <form autoComplete="off" className={{flexGrow: 1}}>
                            <div>
                                <img src={Gif}></img>
                            </div>
                        </form>                        
                    </Modal>
                </List>
            }
            content={
                props.content
            }
        />
    )
}