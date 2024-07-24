using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Repositorios.Interfaces
{
    //Contratos de Usuarios
    public interface IUsuarioRepositorio
    {
        //Metodo de listar todos os usuarios
        Task<List<UsuarioModel>> BuscarTodosUsuarios();

        //Metodo de retornar apenas um usuaio
        Task<UsuarioModel> BuscarPorId(int id);
        
        //Metodo de adicionar usuario
        Task<UsuarioModel> Adicionar(UsuarioModel usuario);

        //Metodo de atualizar usuario
        Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id);

        //Metodo de apagar usuario
        Task<bool> Apagar(int id);

    }
}
