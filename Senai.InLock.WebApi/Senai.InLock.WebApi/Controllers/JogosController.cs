using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interface;
using Senai.InLock.WebApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[Controller]")]

    [Authorize]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private IJogosRepository _jogosRepository { get; set; }

        public JogosController()
        {
            _jogosRepository = new JogosRepository();
        }

        /// <summary>
        /// Lista todos os Itens
        /// </summary>
        /// <returns>Lista de Jogos</returns>
        /// <response code="200">Retorna Ok ao Listar</response>
        /// <response code="404">Se não conseguir Listar</response> 

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get()
        {
            //Status Code - 200 
            return Ok(_jogosRepository.Listar());
        }

        /// <summary>
        /// Deleta item por ID na URL
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Item Deletado</returns>
        /// <response code="200">Retorna Ok ao Deletar Item da Lista</response>
        /// <response code="404">Se não conseguir Deletar </response> 
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            _jogosRepository.Deletar(id);

            return Ok("Jogo Apagado");
        }

        /// <summary>
        /// Cadastra item na lista de Jogos
        /// </summary>
        /// <param name="novoJogo"></param>
        /// <returns>Jogo Cadastrado</returns>
        /// /// <response code="201">Retorna Created ao Cadastrar o Item na Lista</response>
        /// <response code="400">Se não conseguir Cadastrar</response> 
        [Authorize(Roles = "1")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post(JogosDomain novoJogo)
        {
            _jogosRepository.Cadastrar(novoJogo);

            return Created("http://localhost:5000/api/Jogos", novoJogo);
        }
    }
}
