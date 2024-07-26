using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.Interfaces;

namespace SistemaDeTarefas.Repositorios
{
    //Implementa os metodos
    public class TarefaRepositorio : ITarefaRepositorio //f12 vai para definição
    {
        private readonly SistemaTarefasDBContext _dbContext;
        //Construtor
        public TarefaRepositorio(SistemaTarefasDBContext sistemaTarefasDBContext) //Injetando o DbContext
        {
            _dbContext = sistemaTarefasDBContext;
        }

        //Metodo que busca por Id
        public async Task<TarefaModel> BuscarPorId(int id)
        {
            //Retornando todos usuarios onde o id do usuario == id que esta vindo por parametro
            return await _dbContext.Tarefas
                .Include(x => x.Usuario) //Trazendo os dados do usuario
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        //Metodo que retorna todas as tarefas
        public async Task<List<TarefaModel>> BuscarTodasTarefas()
        {
            return await _dbContext.Tarefas
                .Include(x => x.Usuario) //Trazendo os dados do usuario
                .ToListAsync();
        }

        //Metodo adicionar tarefas
        public async Task<TarefaModel> Adicionar(TarefaModel tarefa)
        {
            await _dbContext.Tarefas.AddAsync(tarefa);
            await _dbContext.SaveChangesAsync();

            return tarefa;
        }

        //Metodo atualizar tarefas
        public async Task<TarefaModel> Atualizar(TarefaModel tarefa, int id)
        {
            TarefaModel tarefaPorId = await BuscarPorId(id);
            if (tarefaPorId == null)
            {
                throw new Exception($"Tarefa para o ID: {id} não foi encontrada no banco de dados."); //Dispara uma excessão caso usuario for nulo
            }

            tarefaPorId.Nome = tarefa.Nome;
            tarefaPorId.Descricao = tarefa.Descricao;
            tarefaPorId.Status = tarefa.Status;
            tarefaPorId.UsuarioId = tarefa.UsuarioId;

            _dbContext.Tarefas.Update(tarefaPorId);
            await _dbContext.SaveChangesAsync();

            return tarefaPorId;
        }

        //Metodo apagar tarefas
        public async Task<bool> Apagar(int id)
        {
            TarefaModel tarefaPorId = await BuscarPorId(id);
            if (tarefaPorId == null)
            {
                throw new Exception($"Tarefa para o ID: {id} não foi encontrada no banco de dados.");
            }

            _dbContext.Tarefas.Remove(tarefaPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        

    }
}
