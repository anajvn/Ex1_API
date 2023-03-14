using Ex1_API.Application.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1_API.Application.Interfaces
{
    public interface IEditarAlunoUseCase
    {
        UseCaseOutput Execute(Guid id, EditarAlunoInput input);
    }
}
