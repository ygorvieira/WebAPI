﻿namespace KitFesta_LojaAPI.Models
{
    public class Produto
    {
        public long Id { get; set; }
        public double Preco { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }

        public Produto()
        {

        }

        public Produto(long id, string nome, double preco, int quantidade)
        {
            this.Id = id;
            this.Nome = nome;
            this.Preco = preco;
            this.Quantidade = quantidade;
        }
    }
}
