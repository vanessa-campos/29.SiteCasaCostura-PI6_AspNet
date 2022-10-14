using System;
using System.Collections.Generic;

namespace PIE5_VanessaCampos.Models
{
    public partial class Carrinho
    {
        public int Id { get; set; }
        public int Usuario { get; set; }
        public string ProdutoNome { get; set; }
        public string ProdutoDescricao { get; set; }
        public string ProdutoTamanho { get; set; }
        public int Quantidade { get; set; }
        public bool Concluido { get; set; }
    }
}
