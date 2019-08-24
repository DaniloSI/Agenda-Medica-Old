namespace AgendaMedica.Domain.Entities
{
    public class UsuarioProfissional : Usuario
    {
        public string Cnpj { get; set; }
        public string Orgao { get; set; }
        public string Estado { get; set; }
        public string Registro { get; set; }
    }
}
