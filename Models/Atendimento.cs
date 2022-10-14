using System;
using System.Collections.Generic;

namespace PIE5_VanessaCampos.Models
{
    public partial class Atendimento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Mensagem { get; set; }
        public bool Atendido { get; set; }
    }
}
