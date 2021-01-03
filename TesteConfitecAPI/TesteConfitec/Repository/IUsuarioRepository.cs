using System.Collections.Generic;
using TesteConfitec.Entities;

namespace TesteConfitec.Repository
{
    public interface IUsuarioRepository
    {
        IEnumerable<Usuario> GetUsuarios();

        Usuario GetUsuarioById(int id);

        void InsertUsuario(Usuario user);

        void EditUsuario(Usuario user);

        void DeleteUsuario(Usuario user);
    }
}
