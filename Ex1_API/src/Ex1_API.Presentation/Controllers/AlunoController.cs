using Ex1_API.Application;
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
        private readonly IEditarAlunoUseCase _editarAlunoUseCase;

        public AlunoController(ICadastrarAlunoUseCase cadastrarAlunoUseCase)
        {
            _cadastrarAlunoUseCase = cadastrarAlunoUseCase;
        }
        public AlunoController(IEditarAlunoUseCase editarAlunoUseCase)
        {
            _editarAlunoUseCase = editarAlunoUseCase;
        }

        // Criar: POST
        [HttpPost]
        public IActionResult Post([FromBody] CadastrarAlunoInput input)
        {
            var response = _cadastrarAlunoUseCase.Execute(input);

            if (response.HasErrors)
                return BadRequest(response.Errors);

            return Ok(response.Data);
        }

        // Editar: PUT
        [HttpPut]
        public IActionResult Put([FromBody] EditarAlunoInput input)
        {
            var response = _editarAlunoUseCase.Execute(input);

            if (response.HasErrors)
                return BadRequest(response.Errors);

            return Ok(response.Data);
        }
        /* // Remover: DELETE
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
        }*/

        // Listar por Id: GET /{id}
        //[HttpGet("{id}")]
        //public IActionResult GetId([FromBody] CadastrarPessoaInput input, [FromServices] ICadastrarPessoaUseCase useCase, [FromHeader] string profile)
        //{
        //    return Ok();
        //}
    }
}
