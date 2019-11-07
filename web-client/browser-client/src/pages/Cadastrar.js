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
        Endereco: {
            Cep: "",
            Estado: "",
            Cidade: "",
            Bairro: "",
            Rua: "",
            Numero: "",
            Complemento: ""
        }
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
                    PhoneNumber: "55704468412301",
                    Endereco: form.Endereco
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
                    Registro: form.Registro,
                    Endereco: form.Endereco
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
        },
        tituloCampos: {
            marginTop: theme.spacing(4),
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
                            <Typography variant="h6" gutterBottom className={classes.tituloCampos}>Informações Básicas</Typography>
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
                                required={true}
                                fullWidth
                                margin="normal"
                            />
                            <TextField
                                id="Sobrenome"
                                label="Sobrenome"
                                required={true}
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
                                    required={true}
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
                            <Box id="professionalFields" m={0}>
                                <TextField
                                    id="cnpj"
                                    required={form.TipoUsuario === "1"}
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
                                    required={form.TipoUsuario === "0"}
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
                            <Typography variant="h6" gutterBottom className={classes.tituloCampos}>Endereço</Typography>
                            <TextField
                                id="Cep"
                                label="CEP"
                                required={true}
                                className={classes.textField}
                                value={form.Endereco.Cep}
                                onChange={e => {
                                    var endereco = {
                                        ...form.Endereco
                                    };
                                    endereco.Cep = e.target.value;

                                    setForm(
                                    {
                                        ...form,
                                        Endereco: endereco
                                    });
                                }}
                                fullWidth
                                margin="normal"
                            />
                            <TextField
                                id="Estado"
                                label="Estado"
                                required={true}
                                className={classes.textField}
                                value={form.Endereco.Estado}
                                onChange={e => {
                                    var endereco = {
                                        ...form.Endereco
                                    };
                                    endereco.Estado = e.target.value;

                                    setForm(
                                    {
                                        ...form,
                                        Endereco: endereco
                                    });
                                }}
                                fullWidth
                                margin="normal"
                            />
                            <TextField
                                id="Cidade"
                                label="Cidade"
                                required={true}
                                className={classes.textField}
                                value={form.Endereco.Cidade}
                                onChange={e => {
                                    var endereco = {
                                        ...form.Endereco
                                    };
                                    endereco.Cidade = e.target.value;

                                    setForm(
                                    {
                                        ...form,
                                        Endereco: endereco
                                    });
                                }}
                                fullWidth
                                margin="normal"
                            />
                            <TextField
                                id="Bairro"
                                label="Bairro"
                                required={true}
                                className={classes.textField}
                                value={form.Endereco.Bairro}
                                onChange={e => {
                                    var endereco = {
                                        ...form.Endereco
                                    };
                                    endereco.Bairro = e.target.value;

                                    setForm(
                                    {
                                        ...form,
                                        Endereco: endereco
                                    });
                                }}
                                fullWidth
                                margin="normal"
                            />
                            <TextField
                                id="Rua"
                                label="Rua"
                                required={true}
                                className={classes.textField}
                                value={form.Endereco.Rua}
                                onChange={e => {
                                    var endereco = {
                                        ...form.Endereco
                                    };
                                    endereco.Rua = e.target.value;

                                    setForm(
                                    {
                                        ...form,
                                        Endereco: endereco
                                    });
                                }}
                                fullWidth
                                margin="normal"
                            />
                            <TextField
                                id="Numero"
                                label="Numero"
                                required={true}
                                className={classes.textField}
                                value={form.Endereco.Numero}
                                onChange={e => {
                                    var endereco = {
                                        ...form.Endereco
                                    };
                                    endereco.Numero = e.target.value;

                                    setForm(
                                    {
                                        ...form,
                                        Endereco: endereco
                                    });
                                }}
                                fullWidth
                                margin="normal"
                            />
                            <TextField
                                id="Complemento"
                                label="Complemento"
                                required={true}
                                className={classes.textField}
                                value={form.Endereco.Complemento}
                                onChange={e => {
                                    var endereco = {
                                        ...form.Endereco
                                    };
                                    endereco.Complemento = e.target.value;

                                    setForm(
                                    {
                                        ...form,
                                        Endereco: endereco
                                    });
                                }}
                                fullWidth
                                margin="normal"
                            />

                            <Typography variant="h6" gutterBottom className={classes.tituloCampos}>Informações da Conta</Typography>
                            <TextField
                                id="email"
                                label="Email"
                                required={true}
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
                            <TextField
                                id="password"
                                label="Password"
                                required={true}
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
    );
}