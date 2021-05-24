using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinhaEscolaDigital.API.Application.ApplicationObjects;
using MinhaEscolaDigital.API.Application.Messages.Mediator;
using MinhaEscolaDigital.API.Application.Messages.Queries.AlunoQuery;
using MinhaEscolaDigital.Domain.Utils;
using System.Threading.Tasks;

namespace MinhaEscolaDigital.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : BaseController
    {

        private readonly IMediatorHandler _mediator;

        public AlunoController(IMediatorHandler mediator)
        {
            _mediator = mediator;
        }

        // GET: api/aluno
        /// <summary>
        /// Obtêm os aluno
        /// </summary>
        /// <returns>Coleção de objetos aluno</returns>                
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            var obterTodosAlunoQuery = new ObterTodosAlunoQuery();

            var alunos = await _mediator.EnviarQuery(obterTodosAlunoQuery);

            return ListUtils.isEmpty(alunos) ? NotFound() : CustomResponse(alunos);
        }

        // GET api/<AlunoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AlunoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AlunoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AlunoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
