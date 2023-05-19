using CadastroUsuariosTarefas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroUsuariosTarefas.Repositorios.Interface;

namespace CadastroUsuariosTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarTodosUsuarios()
        {
            List<UsuarioModel> usuarios = await _usuarioRepositorio.BuscarTodosUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarPorId(int id)
        {
            UsuarioModel usuarios = await _usuarioRepositorio.BuscarPorId(id);
            return Ok(usuarios);
        }

        [HttpPost]
        public async Task<ActionResult<List<UsuarioModel>>> Cadastrar([FromBody] UsuarioModel usuarioModel)
        {
            UsuarioModel usuarios = await _usuarioRepositorio.AdicionarUsuario(usuarioModel);
            return Ok(usuarios);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<UsuarioModel>>> Atualizar([FromBody] UsuarioModel usuarioModel, int id)
        {
            usuarioModel.Id = id;
            UsuarioModel usuarios = await _usuarioRepositorio.AtualizarUsuario(usuarioModel,id);
            return Ok(usuarios);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<UsuarioModel>>> Apagar(int id)
        {
            bool apagado = await _usuarioRepositorio.DeletarUsuario(id);
            return Ok(apagado);
        }
    }
}
