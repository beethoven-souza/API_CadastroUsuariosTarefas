using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroUsuariosTarefas.Enums
{
    public enum StatusTarefas
    {
        [Description("A Fazer")]
        AFazer = 1,
        [Description("Em Andamento")]
        EmAndamento = 2,
        [Description("Concluido")]
        Concluido = 3
    }
}
