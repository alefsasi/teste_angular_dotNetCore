using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TesteConfitec.Entities;

namespace TesteConfitec.Repository.Implementacao
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Contexto _db;

        public UsuarioRepository(Contexto db)
        {
            _db = db;
        }

        public IEnumerable<Usuario> GetUsuarios()
        {
            return _db.Usuarios.Include(x => x.Escolaridade);
        }
        public Usuario GetUsuarioById(int id)
        {
            return _db.Usuarios.Where(x => x.Id == id).FirstOrDefault();
        }


        public void InsertUsuario(Usuario user)
        {
            try
            {
                _db.Usuarios.Add(user);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw ex;
            }

        }

        public void EditUsuario(Usuario user)
        {
            try
            {
                var usuarioUpdate = _db.Usuarios.Where(x => x.Id == user.Id).FirstOrDefault();

                usuarioUpdate.Nome = user.Nome;
                usuarioUpdate.Sobrenome = user.Sobrenome;
                usuarioUpdate.Email = user.Email;
                usuarioUpdate.DataNascimento = user.DataNascimento;
                user.EscolaridadeId = user.EscolaridadeId;

                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw ex;
            }

        }

        public void DeleteUsuario(Usuario user)
        {
            try
            {
                _db.Usuarios.Remove(user);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                throw ex;
            }

        }
    }
}
