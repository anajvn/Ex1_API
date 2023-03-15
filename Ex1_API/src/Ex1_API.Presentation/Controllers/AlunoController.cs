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
        private readonly IBuscarAlunosUseCase _buscarAlunosUseCase;
        private readonly IBuscarAlunoUseCase _buscarAlunoUseCase;
        private readonly IDeletarAlunoUseCase _deletarAlunoUseCase;

        public AlunoController(
            ICadastrarAlunoUseCase cadastrarAlunoUseCase,
            IEditarAlunoUseCase editarAlunoUseCase,
            IBuscarAlunosUseCase buscarAlunosUseCase,
            IBuscarAlunoUseCase buscarAlunoUseCase,
            IDeletarAlunoUseCase deletarAlunoUseCase)
        {
            _cadastrarAlunoUseCase = cadastrarAlunoUseCase;
            _editarAlunoUseCase = editarAlunoUseCase;
            _buscarAlunosUseCase = buscarAlunosUseCase;
            _buscarAlunoUseCase = buscarAlunoUseCase;
            _deletarAlunoUseCase = deletarAlunoUseCase;
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
        
        // Remover: DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var response = _deletarAlunoUseCase.Execute(id);

            if (response.HasErrors)
                return BadRequest(response.Errors);

            return Ok(response.Code);
        }

        // Listar todos: GET parâmetros: nome, cidade
        [HttpGet]
        public IActionResult GetAll()
        {
            var alunosResponse = _buscarAlunosUseCase.Execute();

            return Ok(alunosResponse.Data);
        }

        // Listar por Id: GET /{id}
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute]Guid id)
        {
            var response = _buscarAlunoUseCase.Execute(id);

            if (response.HasErrors)
                return BadRequest(response.Errors);

            return Ok(response.Data);
        }
    }
}
