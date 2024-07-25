namespace SistemaDeTarefas.Models
{
    //Criando as tabelas usuarios do banco de dados pelo C#
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; } //A string pode vir nula.
        public string? Email { get; set; }

    }
}
