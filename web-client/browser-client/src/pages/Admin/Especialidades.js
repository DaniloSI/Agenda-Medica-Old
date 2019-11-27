import React, { forwardRef, useEffect }  from 'react';
import Container from '@material-ui/core/Container';
import api from '../../services/api';
import NavBarAdmin from './NavBarAdmin.js';
import MaterialTable from 'material-table';
import * as Notifications from '../../services/notifications';
import {
    FirstPage,
    LastPage,
    ChevronLeft,
    ChevronRight,
    ArrowUpward,
    Add,
    Save,
    Delete,
    Check,
    Clear,
    Edit
} from '@material-ui/icons';


const tableIcons = {
    FirstPage: forwardRef((props, ref) => <FirstPage {...props} ref={ref} />),
    LastPage: forwardRef((props, ref) => <LastPage {...props} ref={ref} />),
    NextPage: forwardRef((props, ref) => <ChevronRight {...props} ref={ref} />),
    PreviousPage: forwardRef((props, ref) => <ChevronLeft {...props} ref={ref} />),
    SortArrow: forwardRef((props, ref) => <ArrowUpward {...props} ref={ref} />),
    Add: forwardRef((props, ref) => <Add {...props} ref={ref} />),
    Save: forwardRef((props, ref) => <Save {...props} ref={ref} />),
    Delete: forwardRef((props, ref) => <Delete {...props} ref={ref} />),
    Check: forwardRef((props, ref) => <Check {...props} ref={ref} />),
    Clear: forwardRef((props, ref) => <Clear {...props} ref={ref} />),
    Edit: forwardRef((props, ref) => <Edit {...props} ref={ref} />)
};

export default function Especialidades(props) {
    var [especialidades, setEspecialidades ] = React.useState([]);

    function fetchEspecialidades() {
        api.get('/Especialidade')
            .then(response => {
                setEspecialidades(response.data);
            });
    }

    useEffect(() => {
        fetchEspecialidades();
    }, []);

    return (
        <NavBarAdmin
            history={props.history}
            content={
                <Container maxWidth="lg">
                    <MaterialTable
                        title="Especialidades"
                        columns={[
                            { title: 'Especialidade', field: 'nome' },
                            { title: 'Código', field: 'codigo' },
                        ]}
                        data={especialidades}
                        icons={tableIcons}
                        options={
                            {
                                paging: false,
                                search: false,
                                actionsColumnIndex: -1
                            }
                        }
                        editable={{
                            onRowAdd: newData =>
                                api.post('/Especialidade', newData)
                                    .then(response => {
                                        if (response.status == 200){
                                            if (response.data.validationResult.isValid) {
                                                Notifications.showSuccess("Consulta cancelada com sucesso!");
                                                fetchEspecialidades();
                                            } else {
                                                response.data.validationResult.errors.forEach(function (e) {
                                                    Notifications.showError(e.errorMessage);
                                                })
                                            }
                                        }
                                    }),
                            onRowUpdate: (newData, oldData) =>
                                api.post('/Especialidade', newData)
                                    .then(response => {
                                        if (response.status == 200){
                                            if (response.data.validationResult.isValid) {
                                                Notifications.showSuccess("Consulta cancelada com sucesso!");
                                                fetchEspecialidades();
                                            } else {
                                                response.data.validationResult.errors.forEach(function (e) {
                                                    Notifications.showError(e.errorMessage);
                                                })
                                            }
                                        }
                                    }),
                            onRowDelete: oldData =>
                              new Promise((resolve, reject) => {
                                setTimeout(() => {
                                  {
                                    const index = especialidades.indexOf(oldData);
                                    especialidades.splice(index, 1);
                                    setEspecialidades(especialidades);
                                  }
                                  resolve()
                                }, 1000)
                              }),
                        }}
                    />
                </Container>
            }
        />
    )
}
