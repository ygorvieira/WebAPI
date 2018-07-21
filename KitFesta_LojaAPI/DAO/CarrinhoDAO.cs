using KitFesta_LojaAPI.Models;
using System.Collections.Generic;

namespace KitFesta_LojaAPI.DAO
{
    public class CarrinhoDAO
    {
        private static Dictionary<long, Carrinho> banco = new Dictionary<long, Carrinho>();
        private static long contador = 1;

        static CarrinhoDAO()
        {
            Produto bolo = new Produto(6237, "Bolo do Relampago Marquinhos", 400, 1);
            Produto salgados = new Produto(3467, "Kit Salgados", 60, 2);
            Carrinho carrinho = new Carrinho();
            carrinho.Adiciona(bolo);
            carrinho.Adiciona(salgados);
            carrinho.Endereco = "Rua Ápia 10, bloco 3, Rio de Janeiro";
            carrinho.Id = 1;
            banco.Add(1, carrinho);
        }

        public void Adiciona(Carrinho carrinho)
        {
            contador++;
            carrinho.Id = contador;
            banco.Add(contador, carrinho);
        }

        public Carrinho Busca(long id)
        {
            return banco[id];
        }

        public void Remove(long id)
        {
            banco.Remove(id);
        }

    }
}
