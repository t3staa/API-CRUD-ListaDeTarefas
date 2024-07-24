namespace SistemaDeTarefas.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; } //A string pode vir nula.
        public string? Email { get; set; }

    }
}
