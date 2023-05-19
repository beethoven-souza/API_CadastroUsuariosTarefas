using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroUsuariosTarefas.Enums;

namespace CadastroUsuariosTarefas.Models
{
    public class TarefaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public StatusTarefas Status { get; set; }
        public int? UsuarioId { get; set; }
        public UsuarioModel? Usuario { get; set; }
        
    }
}
