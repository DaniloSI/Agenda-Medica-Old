import React, { useState, useEffect } from 'react';

import api from '../services/api';
import * as Notifications from '../services/notifications';

import { makeStyles } from '@material-ui/core/styles';
import TextField from '@material-ui/core/TextField';
import Container from '@material-ui/core/Container';
import Card from '@material-ui/core/Card';
import CardContent from '@material-ui/core/CardContent';
import CardActions from '@material-ui/core/CardActions';
import Button from '@material-ui/core/Button';
import Typography from '@material-ui/core/Typography';
import Box from '@material-ui/core/Box';
import Radio from '@material-ui/core/Radio';
import RadioGroup from '@material-ui/core/RadioGroup';
import FormControlLabel from '@material-ui/core/FormControlLabel';
import FormControl from '@material-ui/core/FormControl';
import FormLabel from '@material-ui/core/FormLabel';
import DateFnsUtils from '@date-io/date-fns';
import {
  MuiPickersUtilsProvider,
  KeyboardDatePicker,
} from '@material-ui/pickers';


export default function Cadastrar({ history }) {

    const [form, setForm] = useState({
        Nome: "",
        Sobrenome: "",
        DataNascimento: null,
        cpf: "",
        Email: "",
        Senha: "",
        TipoUsuario: "0",
        cnpj: "",
        Orgao: "",
        Estado: "",
        Registro: "",
    });

    useEffect(() => {
        var camposProfissional = document.getElementById('professionalFields');
        var campoPaciente = document.getElementById('patientFields');

        if (form.TipoUsuario === "0") {
            camposProfissional.hidden = true;
            campoPaciente.hidden = false;
        }

        if (form.TipoUsuario === "1") {
            camposProfissional.hidden = false;
            campoPaciente.hidden = true;
        }
    }, [form]);

    async function handleSubmit(e) {
        e.preventDefault();

        if (form.TipoUsuario === "0") {
            handleResponse(
                await api.post('/User/CadastroPaciente',
                {
                    Nome: form.Nome,
                    SobreNome: form.Sobrenome,
                    DataNascimento: form.DataNascimento,
                    Email: form.Email,
                    Password: form.Senha,
                    Cpf: form.cpf,
                    PhoneNumber: "55704468412301"
                })
            );
        } else {
            handleResponse(
                await api.post('/User/CadastroProfissional',
                {
                    Nome: form.Nome,
                    SobreNome: form.Sobrenome,
                    DataNascimento: form.DataNascimento,
                    Email: form.Email,
                    Password: form.Senha,
                    Cnpj: form.cnpj,
                    PhoneNumber: "55704468412301",
                    Orgao: form.Orgao,
                    Estado: form.Estado,
                    Registro: form.Registro
                })
            );
        }

        function handleResponse(response) {
            if (response.data.sucesso) {
                history.push({
                    pathname: '/Login',
                    state: {
                        cadastroSucesso: true
                    }
                });
            } else {
                response.data.errors.forEach(error => {
                    Notifications.showError(error.description);
                });
            }
        }
    }

    const useStyles = makeStyles(theme => ({
        root: {
          flexGrow: 1,
        },
        card: {
          width: '60%',
          marginTop: '100px',
          margin: 'auto',
          maxWidth: 500, 
        },
        textField: {
          marginLeft: theme.spacing(1),
          marginRight: theme.spacing(1),
          paddingRight: '35px'
        },
        button: {
          margin: theme.spacing(1),
        },
        radio: {
            marginTop: '35px'
        }
      }));
    
      const classes = useStyles();

    return (
        <div className={classes.root}>
            <Container fixed>
                <Card className={classes.card}>
                    <CardContent>
                        <Typography gutterBottom variant="h5" component="h2">Cadastro de Usuário</Typography>
                        <form onSubmit={handleSubmit}>
                            <FormControl className={classes.radio}>
                                <FormLabel component="legend">Tipo de Usuário</FormLabel>
                                <RadioGroup
                                    aria-label="Tipo de Usuário"
                                    name="TipoUsuario"
                                    value={form.TipoUsuario}
                                    onChange={e => setForm(
                                        {
                                            ...form,
                                            TipoUsuario: e.target.value
                                        }
                                    )}
                                    row>
                                    <FormControlLabel value="0" control={<Radio />} label="Paciente" />
                                    <FormControlLabel value="1" control={<Radio />} label="Profissional" />
                                </RadioGroup>
                            </FormControl>
                            <TextField
                                id="Nome"
                                label="Primerio Nome"
                                className={classes.textField}
                                value={form.Nome}
                                onChange={e => setForm(
                                    {
                                        ...form,
                                        Nome: e.target.value
                                    }
                                )}
                                fullWidth
                                margin="normal"
                            />
                            <TextField
                                id="Sobrenome"
                                label="Sobrenome"
                                className={classes.textField}
                                value={form.Sobrenome}
                                onChange={e => setForm(
                                    {
                                        ...form,
                                        Sobrenome: e.target.value
                                    }
                                )}
                                fullWidth
                                margin="normal"
                            />
                            <MuiPickersUtilsProvider utils={DateFnsUtils}>
                                <KeyboardDatePicker
                                    id="DataNascimento"
                                    label="Data de Nascimento"
                                    fullWidth
                                    format="dd/MM/yyyy"
                                    className={classes.textField}
                                    value={form.DataNascimento}
                                    onChange={date => setForm(
                                        {
                                            ...form,
                                            DataNascimento: date
                                        }
                                    )}
                                    KeyboardButtonProps={{
                                        'aria-label': 'change date',
                                    }}
                                />
                            </MuiPickersUtilsProvider>
                            <TextField
                                id="email"
                                label="Email"
                                className={classes.textField}
                                type="email"
                                value={form.Email}
                                onChange={e => setForm(
                                    {
                                        ...form,
                                        Email: e.target.value
                                    }
                                )}
                                name="email"
                                fullWidth
                                autoComplete="email"
                                margin="normal"
                            />
                            <Box id="professionalFields" m={0}>
                                <TextField
                                    id="cnpj"
                                    label="CNPJ"
                                    className={classes.textField}
                                    value={form.cnpj}
                                    onChange={e => setForm(
                                        {
                                            ...form,
                                            cnpj: e.target.value
                                        }
                                    )}
                                    fullWidth
                                    margin="normal"
                                />
                                <TextField
                                    id="Orgao"
                                    label="Órgão"
                                    className={classes.textField}
                                    value={form.Orgao}
                                    onChange={e => setForm(
                                        {
                                            ...form,
                                            Orgao: e.target.value
                                        }
                                    )}
                                    fullWidth
                                    margin="normal"
                                />
                                <TextField
                                    id="Estado"
                                    label="Estado"
                                    className={classes.textField}
                                    value={form.Estado}
                                    onChange={e => setForm(
                                        {
                                            ...form,
                                            Estado: e.target.value
                                        }
                                    )}
                                    fullWidth
                                    margin="normal"
                                />
                                <TextField
                                    id="Registro"
                                    label="Registro"
                                    className={classes.textField}
                                    value={form.Registro}
                                    onChange={e => setForm(
                                        {
                                            ...form,
                                            Registro: e.target.value
                                        }
                                    )}
                                    fullWidth
                                    margin="normal"
                                />
                            </Box>
                            <Box id="patientFields" m={0}>
                                <TextField
                                    id="cpf"
                                    label="CPF"
                                    className={classes.textField}
                                    value={form.cpf}
                                    onChange={e => setForm(
                                        {
                                            ...form,
                                            cpf: e.target.value
                                        }
                                    )}
                                    fullWidth
                                    margin="normal"
                                />
                            </Box>
                            <TextField
                                id="password"
                                label="Password"
                                className={classes.textField}
                                value={form.Senha}
                                onChange={e => setForm({
                                    ...form,
                                    Senha: e.target.value
                                })}
                                fullWidth
                                type="password"
                                autoComplete="current-password"
                                margin="normal"
                            />
                            <TextField
                                id="confirm-password"
                                label="ConfirmPassword"
                                className={classes.textField}
                                fullWidth
                                type="password"
                                autoComplete="current-password"
                                margin="normal"
                            />
                            <CardActions>
                                <Box display="flex" flexDirection="row-reverse" width="100%" m={1}>
                                    <Box>
                                        <Button variant="contained" className={classes.button} onClick={() => history.push('/Login')}>
                                        Cancelar
                                        </Button>
                                    </Box>
                                    <Box>
                                        <Button variant="contained" color="primary" className={classes.button} type="submit">
                                        Cadastrar
                                        </Button>
                                    </Box>
                                </Box>
                            </CardActions>
                        </form>
                    </CardContent>
                </Card>
            </Container>
        </div>
        // <div className="container h-100">
        //     <div className="row align-items-center h-100">
        //         <div className="col-6 mx-auto">
        //             <div className="card">
        //                 <div className="card-body">
        //                     <h5 className="card-title" style={{ textAlign: 'center' }}>Cadastro de Usuário</h5>
        //                     <form onSubmit={handleSubmit}>
        //                         <div className="form-group">
        //                             <label htmlFor="nome">Primerio Nome</label>
        //                             <input
        //                                 type="text"
        //                                 className="form-control"
        //                                 id="nome"
        //                                 value={form.Nome}
        //                                 onChange={e => setForm(
        //                                     {
        //                                         ...form,
        //                                         Nome: e.target.value
        //                                     }
        //                                 )}
        //                                 placeholder="Primeiro Nome"></input>
        //                         </div>
        //                         <div className="form-group">
        //                             <label htmlFor="sobrenome">Sobrenome</label>
        //                             <input
        //                                 type="text"
        //                                 className="form-control"
        //                                 id="sobrenome"
        //                                 value={form.Sobrenome}
        //                                 onChange={e => setForm(
        //                                     {
        //                                         ...form,
        //                                         Sobrenome: e.target.value
        //                                     }
        //                                 )}
        //                                 placeholder="Sobrenome"></input>
        //                         </div>
        //                         <div className="form-group">
        //                             <label htmlFor="email">E-mail</label>
        //                             <input
        //                                 type="email"
        //                                 className="form-control"
        //                                 id="email"
        //                                 aria-describedby="emailHelp"
        //                                 value={form.Email}
        //                                 onChange={e => setForm(
        //                                     {
        //                                         ...form,
        //                                         Email: e.target.value
        //                                     }
        //                                 )}
        //                                 placeholder="Ex.: pessoa@dominio.com"></input>
        //                         </div>
        //                         <div className="form-group">
        //                             <label htmlFor="emailConfirmacao">Confirmação de E-mail</label>
        //                             <input type="email" className="form-control" id="emailConfirmacao" aria-describedby="emailHelp" placeholder="Confirmação de E-mail"></input>
        //                         </div>
        //                         <div className="form-group">
        //                             <label htmlFor="senha">Senha</label>
        //                             <input
        //                                 type="password"
        //                                 className="form-control"
        //                                 id="senha"
        //                                 value={form.Senha}
        //                                 onChange={e => setForm({
        //                                     ...form,
        //                                     Senha: e.target.value
        //                                 })}
        //                                 placeholder="Senha"></input>
        //                         </div>
        //                         <div className="form-group">
        //                             <label htmlFor="senhaConfirmacao">Confirmação de Senha</label>
        //                             <input type="password" className="form-control" id="senhaConfirmacao" placeholder="Confirmação de Senha"></input>
        //                         </div>
        //                         <div className="row">
        //                             <div className="pl-3 form-check form-check-inline">
        //                                 <input
        //                                     className="form-check-input"
        //                                     type="radio"
        //                                     name="tipoUsuarioOptions"
        //                                     id="tipoUsuarioPaciente"
        //                                     value={0}
        //                                     onChange={e => setForm({
        //                                         ...form,
        //                                         TipoUsuario: parseInt(e.target.value)
        //                                     })}
        //                                     checked={form.TipoUsuario === 0}></input>
        //                                 <label className="form-check-label" htmlFor="tipoUsuarioPaciente">Paciente</label>
        //                             </div>
        //                             <div className="col-1-2 form-check form-check-inline">
        //                                 <input
        //                                     className="form-check-input"
        //                                     type="radio"
        //                                     name="tipoUsuarioOptions"
        //                                     id="tipoUsuarioProfissional"
        //                                     value={1}
        //                                     onChange={e => setForm({
        //                                         ...form,
        //                                         TipoUsuario: parseInt(e.target.value)
        //                                     })}
        //                                     checked={form.TipoUsuario === 1}></input>
        //                                 <label className="form-check-label" htmlFor="tipoUsuarioProfissional">Profissional</label>
        //                             </div>
        //                         </div>
        //                         <div id="professionalFields" className="border-top border-secondary" style={{ marginTop: '20px' }}>
        //                             <div className="form-group mt-3">
        //                                 <label htmlFor="cnpj">CNPJ</label>
        //                                 <input
        //                                     type="text"
        //                                     className="form-control"
        //                                     id="cnpj"
        //                                     value={form.cnpj}
        //                                     onChange={e => setForm(
        //                                         {
        //                                             ...form,
        //                                             cnpj: e.target.value
        //                                         }
        //                                     )}
        //                                     placeholder="CNPJ"></input>
        //                             </div>
        //                             <div className="form-group">
        //                                 <label htmlFor="orgao">Órgão Regulador</label>
        //                                 <input
        //                                     type="text"
        //                                     className="form-control"
        //                                     id="orgao"
        //                                     value={form.Orgao}
        //                                     onChange={e => setForm(
        //                                         {
        //                                             ...form,
        //                                             Orgao: e.target.value
        //                                         }
        //                                     )}
        //                                     placeholder="Órgão"></input>
        //                             </div>
        //                             <div className="form-group">
        //                                 <label htmlFor="estado">Estado</label>
        //                                 <input
        //                                     type="text"
        //                                     className="form-control"
        //                                     id="estado"
        //                                     value={form.Estado}
        //                                     onChange={e => setForm(
        //                                         {
        //                                             ...form,
        //                                             Estado: e.target.value
        //                                         }
        //                                     )}
        //                                     placeholder="Estado"></input>
        //                             </div>
        //                             <div className="form-group">
        //                                 <label htmlFor="registro">Registro Profissional</label>
        //                                 <input
        //                                     type="text"
        //                                     className="form-control"
        //                                     id="registro"
        //                                     value={form.Registro}
        //                                     onChange={e => setForm(
        //                                         {
        //                                             ...form,
        //                                             Registro: e.target.value
        //                                         }
        //                                     )}
        //                                     placeholder="Registro"></input>
        //                             </div>
        //                         </div>
        //                         <div id="patientFields" className="border-top border-secondary" style={{marginTop: '20px'}}>
        //                             <div className="form-group mt-3">
        //                                 <label htmlFor="cpf">CPF</label>
        //                                 <input
        //                                     type="text"
        //                                     className="form-control"
        //                                     id="cpf"
        //                                     value={form.cpf}
        //                                     onChange={e => setForm(
        //                                         {
        //                                             ...form,
        //                                             cpf: e.target.value
        //                                         }
        //                                     )}
        //                                     placeholder="CPF"></input>
        //                             </div>
        //                         </div>
        //                         <div className="mt-3">
        //                             <button type="submit" className="btn btn-primary">Cadastrar</button>
        //                             <button className="btn btn-light float-right" onClick={() => history.push('/Login')} >Cancelar</button>
        //                         </div>
        //                     </form>
        //                 </div>
        //             </div>
        //         </div>
        //     </div>
        // </div>
    );
}