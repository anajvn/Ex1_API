using Ex1_API.Application.Inputs;
using Ex1_API.Application.Interfaces;
using Ex1_API.Application.Outputs;
using Ex1_API.Core;
using System.Net;
using Ex1_API.Application.Interfaces.Repositories;

namespace Ex1_API.Application.UseCases
{
    public class CadastrarAlunoUseCase : ICadastrarAlunoUseCase
    {
        private readonly IAlunoRepository _alunoRepository;
        public CadastrarAlunoUseCase(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }
        public UseCaseOutput Execute(CadastrarAlunoInput input)
        {
            var aluno = new Aluno
            (
                input.Nome,
                input.Cidade,
                input.Idade
            );

            if (!aluno.IsValid)
            {
                return new UseCaseOutput(aluno.Validations);
            }

            // Chama o banco de dados:
            //íf já existe esse aluno...

            //se não, salva aluno:
            _alunoRepository.Adicionar(aluno);


            return new UseCaseOutput(new AlunoPresenter(aluno));
        }
    }
}
