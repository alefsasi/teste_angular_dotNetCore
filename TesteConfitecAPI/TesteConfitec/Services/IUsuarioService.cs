using System.Collections.Generic;
using TesteConfitec.Entities;

namespace TesteConfitec.Services
{
    public interface IUsuarioService
    {
        IEnumerable<Usuario> GetUsuarios();

        Usuario GetUsuarioById(int id);

        void InsertUsuario(Usuario usuario);

        void EditUsuario(int id, Usuario usuario);

        void DeleteUsuario(int id);

    }
}
