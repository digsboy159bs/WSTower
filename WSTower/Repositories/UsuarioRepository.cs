using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using WSTower.Contexts;
using WSTower.Domains;

namespace WSTower.Repositories
{
    public class UsuarioRepository
    {
        public Usuario BuscarPorEmailSenha(string email, string senha)
        {
            using (WSTowerContext ctx = new WSTowerContext())
            {
                return ctx.Usuario.FirstOrDefault(x => x.Email == email && x.Senha == senha);
            }
        }

        public List<Usuario> ListarUsuarios()
        {
            using (WSTowerContext ctx = new WSTowerContext())
            {
                return ctx.Usuario.ToList();
            }
        }

        public void Cadastrar(Usuario usuario)
        {
            using (WSTowerContext ctx = new WSTowerContext())
            {
                ctx.Usuario.Add(usuario);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (WSTowerContext ctx = new WSTowerContext())
            {
                Usuario usuarioid = ctx.Usuario.Find(id);
                ctx.Usuario.Remove(usuarioid);
                ctx.SaveChanges();
            }
        }

        public void Atualizar(Usuario usuario)
        {
            using (WSTowerContext ctx = new WSTowerContext())
            {
                Usuario usuarioAtualizado = ctx.Usuario.FirstOrDefault(x => x.Id == usuario.Id);
                usuarioAtualizado.Id = usuario.Id;
                ctx.Usuario.Update(usuarioAtualizado);
                ctx.SaveChanges();
            }
        }

        public Usuario BuscarPorId(int id)
        {
            using (WSTowerContext ctx = new WSTowerContext())
            {
                return ctx.Usuario.FirstOrDefault(x => x.Id == id);
            }
        }
    }
}
