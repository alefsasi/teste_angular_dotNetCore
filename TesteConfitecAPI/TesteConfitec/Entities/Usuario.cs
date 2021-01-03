using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteConfitec.Entities
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string Email { get; set; }

        public DateTime DataNascimento { get; set; }

        public int EscolaridadeId { get; set; }

        public Escolaridade Escolaridade { get; set; }
    }
}