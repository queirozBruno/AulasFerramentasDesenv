using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modelo.Tabelas
{
    public class Categoria
    {
        public long CategoriaId { get; set; }
        public string nome { get; set; }

        public virtual ICollection<Modelo.Cadastros.Produto> Produtos { get; set; }//Criando a ligação entre Categorias e Produtos na tabela
    }
}