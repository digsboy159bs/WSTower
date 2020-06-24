using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using WSTower.Contexts;
using WSTower.Domains;

namespace WSTower.Repositories
{
    public class SelecaoRepository
    {
        public List<Selecao> Listar()
        {
            using (WSTowerContext ctx = new WSTowerContext())
            {
                
                return ctx.Selecao.Include(x => x.Jogador).ToList();
            }
        }
    }
}
