using System.Collections.Generic;
using TesteConfitec.Entities;

namespace TesteConfitec.Repository
{
    public interface IEscolaridadeRepository
    {
        IEnumerable<Escolaridade> GetEscolaridades();
        Escolaridade GetEscolaridadeById(int id);
    }
}
