using System.Collections.Generic;
using System.Linq;
using TesteConfitec.Entities;

namespace TesteConfitec.Repository.Implementacao
{
    public class EscolaridadeRepository : IEscolaridadeRepository
    {
        private readonly Contexto _db;

        public EscolaridadeRepository(Contexto db)
        {
            _db = db;
        }


        public IEnumerable<Escolaridade> GetEscolaridades()
        {
            return _db.Escolaridades;
        }

        public Escolaridade GetEscolaridadeById(int id)
        {
            return _db.Escolaridades.Where(x => x.Id == id).FirstOrDefault();
        }


    }
}
