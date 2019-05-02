using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
//using GerencProdAndCateg.Models;
using Modelo.Cadastros;
using Modelo.Tabelas;

namespace Persistencia.Contexts
{
    public class EFContext:DbContext //Extende de DBContext
    {
        public EFContext() : base("Asp_Net_MVC_CS") {
            Database.SetInitializer<EFContext>(new
                DropCreateDatabaseIfModelChanges<EFContext>()); //Faz com que o BD seja recriado toda vez que uma modificação acontecer
        } /*este construtor estende ao contrutor da classe base.
        O argumento refere-se ao nome da connection string definida no arquivo Web.config */

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Fabricante> Fabricantes { get; set; }
        public DbSet<Produto> Produtos { get; set; } //Criei essa linha depois que criei a classe Produto em Models

        //public System.Data.Entity.DbSet<Modelo.Cadastros.Produto> Produtoes { get; set; }

        //resolve o problema da pluralização das tabelas
        //importar System.Data.Entity.ModelConfiguration.Conventions;
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}