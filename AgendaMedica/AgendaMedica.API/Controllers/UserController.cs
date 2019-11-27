using AgendaMedica.Application.ViewModels;
using AgendaMedica.Application.ViewModels.PesquisaViewModels;
using AgendaMedica.Domain.Entities;
using AgendaMedica.Domain.Identity;
using AgendaMedica.Domain.Interfaces.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AgendaMedica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;
        private readonly IUsuarioPacienteRepository _usuarioPacienteRepository;
        private readonly IUsuarioProfissionalRepository _usuarioProfissionalRepository;

        public UserController(IConfiguration config,
                              UserManager<AppUser> userManager,
                              SignInManager<AppUser> signInManager,
                              IMapper mapper,
                              IUsuarioPacienteRepository usuarioPacienteRepository,
                              IUsuarioProfissionalRepository usuarioProfissionalRepository)
        {
            _signInManager = signInManager;
            _mapper = mapper;
            _config = config;
            _userManager = userManager;
            _usuarioPacienteRepository = usuarioPacienteRepository;
            _usuarioProfissionalRepository = usuarioProfissionalRepository;
        }

        [HttpGet("GetUser")]
        public IActionResult GetUser()
        {
            return Ok(new dynamic[]
            {
                _mapper.Map<UsuarioPaciente, UsuarioPacienteViewModel>(_usuarioPacienteRepository.GetById(1)),
                _mapper.Map<UsuarioProfissional, UsuarioProfissionalViewModel>(_usuarioProfissionalRepository.GetById(3))
            });
        }

        [HttpPost("Profissionais")]
        public JsonResult GetProfissionais(BuscaProfissionaisViewModel vm)
        {
            var profissionais = _usuarioProfissionalRepository.GetAll()
                .Include(x => x.Especialidades)
                .Include(x => x.Endereco)
                .AsNoTracking()
                .Where(vm.Filtro())
                .Select(p => new
                {
                    p.Id,
                    NomeCompleto = $"{p.Nome} {p.SobreNome}",
                    Endereco = p.Endereco != null ? p.Endereco.ToString() : "",
                    Avaliacao = 3.5,
                    Especialidades = p.Especialidades.Select(e => new
                    {
                        e.Especialidade.EspecialidadeId,
                        e.Especialidade.Codigo,
                        e.Especialidade.Nome,
                    }).ToArray()
                })
                .ToArray();

            return new JsonResult(profissionais);
        }

        [HttpPost("CadastroPaciente")]
        [AllowAnonymous]
        public async Task<IActionResult> CadastroPaciente(UsuarioPacienteViewModel paciente)
        {
            try
            {
                var user = _mapper.Map<UsuarioPaciente>(paciente);

                user.UserName = paciente.Email;

                var result = await _userManager.CreateAsync(user, paciente.Password);

                var userToReturn = _mapper.Map<UsuarioPacienteViewModel>(user);

                if (result.Succeeded)
                {
                    return Ok(new
                    {
                        sucesso = true,
                        Usuario = userToReturn
                    });
                }

                return Ok(new
                {
                    sucesso = false,
                    Usuario = userToReturn,
                    result.Errors
                });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"O Banco Dados Falhou {e.Message}!!");
            }
        }

        [HttpPost("CadastroProfissional")]
        [AllowAnonymous]
        public async Task<IActionResult> CadastroProfissional(UsuarioProfissionalViewModel profissional)
        {
            try
            {
                var user = _mapper.Map<UsuarioProfissional>(profissional);

                user.UserName = profissional.Email;

                var result = await _userManager.CreateAsync(user, profissional.Password);


                if (result.Succeeded)
                {
                    var usuario = _usuarioProfissionalRepository.GetById(user.Id);
                    return Ok(new
                    {
                        sucesso = true,
                        Usuario = _mapper.Map<UsuarioProfissionalViewModel>(usuario),
                        result.Errors
                    });
                }

                var userToReturn = _mapper.Map<UsuarioProfissionalViewModel>(user);
                return Ok(new
                {
                    sucesso = false,
                    Usuario = userToReturn,
                    result.Errors
                });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"O Banco Dados Falhou {e.Message}.");
            }
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel userLogin)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(userLogin.Email);

                if (user != null)
                {
                    var result = await _signInManager.CheckPasswordSignInAsync(user, userLogin.Password, false);

                    if (result.Succeeded)
                    {
                        var appUser = await _userManager.Users.FirstOrDefaultAsync(u => u.Email.ToUpper() == userLogin.Email.ToUpper());

                        var userToReturn = _mapper.Map<UsuarioViewModel>(appUser);

                        return Ok(GenerateJWToken(appUser).Result);
                    }
                }

                return Ok(new
                {
                    sucesso = false,
                    Erro = "Senha inválida ou usuário não existe"
                });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {e.Message}.");
            }
        }

        private async Task<object> GenerateJWToken(AppUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var roles = await _userManager.GetRolesAsync(user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new
            {
                sucesso = true,
                token = tokenHandler.WriteToken(token),
                tokenDescriptor.Expires,
                FullName = $"{(user as Usuario).Nome} {(user as Usuario).SobreNome}",
                user.Email,
                TipoUsuario = (user is UsuarioPaciente) ? 0 : (user is UsuarioProfissional) ? 1 : 2
            };
        }
    }
}
