using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.Interfaces;

namespace SistemaDeTarefas.Repositorios
{
    //Implementa os metodos
    public class UsuarioRepositorio : IUsuarioRepositorio //f12 vai para definição
    {
        private readonly SistemaTarefasDBContext _dbContext;
        //Construtor
        public UsuarioRepositorio(SistemaTarefasDBContext sistemaTarefasDBContext) //Injetando o DbContext
        {
            _dbContext = sistemaTarefasDBContext;
        }

        //Metodo que busca por Id
        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            //Retornando todos usuarios onde o id do usuario == id que esta vindo por parametro
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        //Metodo que retorna todos os usuarios
        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

        //Metodo adicionar usuarios
        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }

        //Metodo atualizar usuarios
        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);
            if (usuarioPorId == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados."); //Dispara uma excessão caso usuario for nulo
            }

            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.Email = usuario.Email;

            _dbContext.Usuarios.Update(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return usuarioPorId;
        }

        //Metodo apagar usuarios
        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);
            if (usuarioPorId == null)
            {
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Usuarios.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        

    }
}
