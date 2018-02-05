using System.Collections.Generic;

namespace Sessao.Models
{
    public class Carrinho
    {
        public List<Produto> Produtos;

        public Carrinho()
        {
            Produtos = new List<Produto>();
        }
    }
}