using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Repositorios.Interfaces
{
    //Contratos de Usuarios
    public interface ITarefaRepositorio
    {
        //Metodo de listar todos os usuarios
        Task<List<TarefaModel>> BuscarTodasTarefas();

        //Metodo de retornar apenas um usuaio
        Task<TarefaModel> BuscarPorId(int id);
        
        //Metodo de adicionar usuario
        Task<TarefaModel> Adicionar(TarefaModel tarefa);

        //Metodo de atualizar usuario
        Task<TarefaModel> Atualizar(TarefaModel tarefa, int id);

        //Metodo de apagar usuario
        Task<bool> Apagar(int id);

    }
}
