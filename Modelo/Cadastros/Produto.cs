using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modelo.Cadastros
{
    public class Produto
    {
        public long? ProdutoId { get; set; }
        public string Nome { get; set; }

        public long? CategoriaId { get; set; }
        public long? FabricanteId { get; set; }

        public Modelo.Tabelas.Categoria categoria { get; set; }
        public Modelo.Cadastros.Fabricante fabricante { get; set; }
    }
}