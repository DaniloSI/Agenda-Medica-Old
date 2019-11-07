namespace AgendaMedica.Domain.Entities
{
    public class Endereco
    {
        public int EnderecoId { get; set; }
        public string CEP { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }

        public override string ToString()
        {
            return $"Rua {Rua}, CEP {CEP}, Nº {Numero}";
        }
    }
}
