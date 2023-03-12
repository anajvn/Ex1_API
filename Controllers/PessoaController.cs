using Ex1_API.Application;
using Ex1_API.Application.Inputs;
using Ex1_API.Application.Interfaces;
using Ex1_API.Core;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Ex1_API.Controllers
{
    [ApiController]
    // Um Controller chamado “PessoaController”, porém, a rota deve ser “/api/person”
    [Route("api/person")]
    public class PessoaController : ControllerBase
    {
        private static List<Aluno> _pessoas;

        private readonly ICadastrarAlunoUseCase _cadastrarPessoaUseCase;

        public PessoaController(ICadastrarAlunoUseCase cadastrarPessoaUseCase)
        {
            _cadastrarPessoaUseCase = _cadastrarPessoaUseCase;
        }

        private readonly ILogger<PessoaController> _logger;

        public PessoaController(ILogger<PessoaController> logger)
        {
            _logger = logger;
        }

        // Criar: POST
        [HttpPost]
        public IActionResult Post([FromBody]CadastrarAlunoInput input, [FromServices]ICadastrarAlunoUseCase useCase)
        {
            var response = _cadastrarPessoaUseCase.Execute(input);

            if (response.HasErrors)
                return BadRequest(response.Errors);

            return Ok(response.Data);

            // return Status(response);
        }
        /*// Editar: PUT
        [HttpPut]
        public IActionResult Put([FromBody] CadastrarPessoaInput input, [FromServices] ICadastrarPessoaUseCase useCase, [FromHeader] string profile)
        {
            return Ok();
        }
        // Remover: DELETE
        [HttpDelete]
        public IActionResult Delete([FromBody] CadastrarPessoaInput input, [FromServices] ICadastrarPessoaUseCase useCase, [FromHeader] string profile)
        {
            return Ok();
        }
        // Listar todos: GET parâmetros: nome, cidade
        [HttpGet]
        public IActionResult GetAll([FromBody] CadastrarPessoaInput input, [FromServices] ICadastrarPessoaUseCase useCase, [FromHeader] string profile)
        {
            return Ok();
        }
        // Listar por Id: GET /{id}
        [HttpGet]
        public IActionResult GetId([FromBody] CadastrarPessoaInput input, [FromServices] ICadastrarPessoaUseCase useCase, [FromHeader] string profile)
        {
            return Ok();
        }*/

        /* ----- Metodos para organizar os resultados ----- */
        /*public IActionResult Status(UseCaseOutput response)
        {
            if (response.HasErrors)
                return BadRequest(response.Errors);

            return Ok(response.Data);
        }*/


    }
}