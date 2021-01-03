using System.Collections.Generic;
using TesteConfitec.Entities;

namespace TesteConfitec.Services.Implementacao
{
    public interface IEscolaridadeService
    {
        IEnumerable<Escolaridade> GetEscolaridades();
        Escolaridade GetEscolaridadeById(int id);
    }
}
