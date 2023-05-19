using CadastroUsuariosTarefas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroUsuariosTarefas.Repositorios.Interface
{
    public interface ITarefaRepositorio
    {
        Task<List<TarefaModel>> BuscarTodasTarefas();
        Task<TarefaModel> BuscarPorId(int id);
        Task<TarefaModel> AdicionarTarefa(TarefaModel tarefa);
        Task<TarefaModel> AtualizarTarefa(TarefaModel tarefa, int id);
        Task<bool> DeletarTarefa(int id);
    }
}
