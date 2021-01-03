using System;
using System.Collections.Generic;
using TesteConfitec.Entities;
using TesteConfitec.Repository;

namespace TesteConfitec.Services.Implementacao
{
    public class EscolaridadeService : IEscolaridadeService
    {
        private IEscolaridadeRepository _repository;

        public EscolaridadeService(IEscolaridadeRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Escolaridade> GetEscolaridades()
        {
            return _repository.GetEscolaridades();
        }


        public Escolaridade GetEscolaridadeById(int id)
        {
            var escolaridade = _repository.GetEscolaridadeById(id);

            if (escolaridade == null)
                throw new Exception("Escolaridade não existe.");

            return escolaridade;
        }
    }
}
