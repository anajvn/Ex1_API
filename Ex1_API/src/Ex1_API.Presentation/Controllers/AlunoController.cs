using Ex1_API.Application.Inputs;
using Ex1_API.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ex1_API.Presentation.Controllers
{
    [ApiController]
    // Um Controller chamado “PessoaController”, porém, a rota deve ser “/api/person”
    [Route("api/student")]
    public class AlunoController : ControllerBase
    {
        // private static List<Aluno> _alunos;
        private readonly ICadastrarAlunoUseCase _cadastrarAlunoUseCase;

        public AlunoController(ICadastrarAlunoUseCase cadastrarAlunoUseCase)
        {
            _cadastrarAlunoUseCase = cadastrarAlunoUseCase;
        }

        // Criar: POST
        [HttpPost]
        public IActionResult Post([FromBody] CadastrarAlunoInput input)
        {
            var response = _cadastrarAlunoUseCase.Execute(input);

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
    }
}
