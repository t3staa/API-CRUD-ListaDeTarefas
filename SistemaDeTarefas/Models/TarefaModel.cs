using SistemaDeTarefas.Enums;

namespace SistemaDeTarefas.Models
{
    //Criando as tabelas de tarefas do banco pelo C#
    public class TarefaModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public StatusTarefas Status { get; set; }
        public int? UsuarioId { get; set; }
        public virtual UsuarioModel? Usuario { get; set; }

    }
}
