using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data.Map;
using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Data
{
    [Route("api/[controller]")]
    [ApiController]
    //Criando o contexto do Banco de Dados
    public class SistemaTarefasDBContext : DbContext
    {
        //Metodo Construtor
        public SistemaTarefasDBContext(DbContextOptions<SistemaTarefasDBContext> options)
            : base(options)
        {

        }

        //Trabalhando com ORM, facilitando trabalhar com Banco de dados, criando a estrutura e as tabelas pelo csharp

        //Tabela Usuarios
        public DbSet<UsuarioModel> Usuarios { get; set; }
        //Tabela Tarefass
        public DbSet<TarefaModel> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
