using System;
using System.Collections.Generic;
using TesteConfitec.Entities;
using TesteConfitec.Repository;

namespace TesteConfitec.Services.Implementacao
{
    public class UsuarioService : IUsuarioService
    {

        private IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }


        public IEnumerable<Usuario> GetUsuarios()
        {
            return _repository.GetUsuarios();
        }

        public Usuario GetUsuarioById(int id)
        {
            var usuario = _repository.GetUsuarioById(id);

            if (usuario == null)
                throw new Exception("Usuário não existe.");

            return usuario;
        }

        public void InsertUsuario(Usuario usuario)
        {
            try
            {
                _repository.InsertUsuario(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao inserir o usuário: {ex.Message}");
            }

        }

        public void EditUsuario(int id, Usuario usuario)
        {
            try
            {
                if (_repository.GetUsuarioById(id) == null)
                    throw new Exception("Usuário não existe.");

                _repository.EditUsuario(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao Atualizar o usuário: {ex.Message}");
            }
        }

        public void DeleteUsuario(int id)
        {
            try
            {
                var user = _repository.GetUsuarioById(id);

                if (user == null)
                    return;

                _repository.DeleteUsuario(user);
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao Excluir o usuário: {ex.Message}");
            }
        }
    }
}
