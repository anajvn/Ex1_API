using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex1_API.Core;

namespace Ex1_API.Application.Output
{
    public class AlunoPresenter
    {
        public Guid Id { get; set; }

        public string Dados { get; set; }
        public AlunoPresenter(Aluno aluno)
        {
            Id = aluno.Id;
            Dados = $"Nome: {aluno.Nome} - Cidade: {aluno.Cidade}";

            if (aluno.Idade != null)
            {
                Dados += $" - Idade: {aluno.Idade}";
            }
        }
    }
}
