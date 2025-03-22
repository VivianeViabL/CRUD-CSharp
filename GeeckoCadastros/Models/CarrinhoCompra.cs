using System.Data.SqlClient;
using System.Collections.Generic;

namespace GeeckoCadastros.Models
{
    public class CarrinhoCompras
    {
        // Lista para armazenar os produtos no carrinho
        public List<Produtos> Produtos { get; private set; }

        // Construtor para inicializar a lista de produtos
        public CarrinhoCompras()
        {
            Produtos = new List<Produtos>();
        }

        // Método para adicionar um produto ao carrinho
        public void AdicionarProduto(Produtos produto)
        {
            Produtos.Add(produto);
        }

        // Método para remover um produto do carrinho pelo código do produto
        public void RemoverProduto(int cod_Prod)
        {
            var produto = Produtos.Find(p => p.Cod_Prod == cod_Prod);
            if (produto != null)
            {
                Produtos.Remove(produto);
            }
        }

        // Método para obter todos os produtos no carrinho
        public List<Produtos> ObterProdutos()
        {
            return Produtos;
        }
    }
}
