namespace AgendaMedica.Domain.Entities.ManyToManys
{
    public class UsuarioProfissionalEspecialidade
    {
        public int Id { get; set; }
        public virtual UsuarioProfissional UsuarioProfissional { get; set; }
        public int EspecialidadeId { get; set; }
        public virtual Especialidade Especialidade { get; set; }

        public UsuarioProfissionalEspecialidade()
        {
        }

        public UsuarioProfissionalEspecialidade(int Id, int EspecialidadeId)
        {
            this.Id = Id;
            this.EspecialidadeId = EspecialidadeId;
        }
    }
}
