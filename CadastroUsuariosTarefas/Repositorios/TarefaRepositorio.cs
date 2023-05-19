using CadastroUsuariosTarefas.Data;
using CadastroUsuariosTarefas.Models;
using CadastroUsuariosTarefas.Repositorios.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroUsuariosTarefas.Repositorios
{
    public class TarefaRepositorio : ITarefaRepositorio
    {
        private readonly SistemaTarefasDBContex _dbContext;
        public TarefaRepositorio(SistemaTarefasDBContex sistemaTarefasDBContex)
        {
            _dbContext = sistemaTarefasDBContex;
        }

        
        public async Task<TarefaModel> AdicionarTarefa(TarefaModel tarefa)
        {
            await _dbContext.Tarefas.AddAsync(tarefa);
            await _dbContext.SaveChangesAsync();
            return tarefa;
        }

        public async Task<TarefaModel> AtualizarTarefa(TarefaModel tarefa, int id)
        {
            TarefaModel tarefaPorId = await BuscarPorId(id);
            if(tarefaPorId == null)
            {
                throw new Exception("A Tarefa não pode ser atualizada com base nos dados informados.");
            }
            tarefaPorId.Nome = tarefa.Nome;
            tarefaPorId.Descricao = tarefa.Descricao;
            tarefaPorId.Status = tarefa.Status;
            tarefaPorId.UsuarioId = tarefa.UsuarioId;
            
            _dbContext.Tarefas.Update(tarefaPorId);
            await _dbContext.SaveChangesAsync();

            return tarefaPorId;
        }

        public async Task<TarefaModel> BuscarPorId(int id)
        {
            return await _dbContext.Tarefas.Include(x=>x.Usuario).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TarefaModel>> BuscarTodasTarefas()
        {
            return await _dbContext.Tarefas.Include(x=>x.Usuario).ToListAsync();
        }

        public async Task<bool> DeletarTarefa(int id)
        {
            TarefaModel tarefaPorId = await BuscarPorId(id);
            if (tarefaPorId == null)
            {
                throw new Exception("Usuario não pode ser deletado com base nos dados informados.");
            }

            _dbContext.Tarefas.Remove(tarefaPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
