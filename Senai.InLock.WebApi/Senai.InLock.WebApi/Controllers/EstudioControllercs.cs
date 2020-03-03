using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[Controller]")]

    [ApiController]
    [Authorize]
    public class EstudioControllers : ControllerBase
    {
        private IEstudioRepository _estudioRepository { get; set; }

        public EstudioControllers()
        {
            _estudioRepository = new EstudioRepository();
        }
        [HttpGet]
        public IActionResult Get()
        { 
            return Ok(_estudioRepository.Listar());
        }
    }
}
