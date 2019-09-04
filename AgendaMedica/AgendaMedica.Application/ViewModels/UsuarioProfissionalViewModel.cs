namespace AgendaMedica.Application.ViewModels
{
    public class UsuarioProfissionalViewModel : UsuarioViewModel
    {
        public string Cnpj { get; set; }
        public string Orgao { get; set; }
        public string Estado { get; set; }
        public string Registro { get; set; }
    }
}
