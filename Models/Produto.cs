using System;
using System.Collections.Generic;

namespace PIE5_VanessaCampos.Models
{
    public partial class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Tamanho { get; set; }
        public int Quantidade { get; set; }
    }
}
