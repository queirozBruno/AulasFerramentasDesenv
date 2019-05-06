using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using Modelo.Cadastros;
using Modelo.Tabelas;
using Servico.Cadastros;
using Servico.Tabelas;

namespace GerencProdAndCateg.Controllers
{
    public class ProdutosController : Controller
    {
        private ProdutoServico produtoServico = new ProdutoServico();
        private CategoriaServico categoriaServico = new CategoriaServico();
        private FabricanteServico fabricanteServico = new FabricanteServico();

        // GET: Produtos
        public ActionResult Index()
        {
            return View(produtoServico.ObterProdutosClassificadosPorNome());
        }

        private ActionResult ObterVisaoProdutoPorId(long? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = produtoServico.ObterProdutoPorId((long)id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        //Passando conteúdos em viewbags que alimentarão os dropDownLists nas Views 
        private void PopularViewBag(Produto produto = null)
        {
            if (produto == null)
            {
                ViewBag.CategoriaId = new SelectList(categoriaServico.ObterCategoriasClassificadasPorNome(), "CategoriaId", "Nome", produto.CategoriaId);
                ViewBag.FabricanteId = new SelectList(fabricanteServico.ObterFabricanteClassificadosPorNome(), "FabricanteId", "Nome", produto.FabricanteId);
            }
        }

        //Adaptação das Actions Http POST. Método privado que simplifica a tarefa de atualização e inserção
        ActionResult GravarProduto(Produto produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    produtoServico.GravarProduto(produto);
                    return RedirectToAction("Index");
                }
                return View(produto);
            }
            catch 
            {
                return View(produto);
            }
        }

        // GET: Produtos/Details/5
        public ActionResult Details(long? id)
        {
            //if (id==null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Produto produto = context.Produtos.Where(p => p.ProdutoId == id).Include(c => c.categoria).Include(f => f.fabricante).First();
            //if (produto==null)
            //{
            //    return HttpNotFound();
            //}
            //return View(produto);
            return ObterVisaoProdutoPorId(id);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            //ViewBag.CategoriaId = new SelectList(context.Categorias.OrderBy(b => b.nome), "CategoriaId", "Nome");
            //ViewBag.FabricanteId = new SelectList(context.Fabricantes.OrderBy(b => b.Nome), "FabricanteId", "Nome");
            PopularViewBag();
            return View();
        }

        // POST: Produtos/Create
        [HttpPost]
        public ActionResult Create(Produto produto)
        {
            //try
            //{
            //    // TODO: Add insert logic here
            //    context.Produtos.Add(produto);
            //    context.SaveChanges();  
            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View(produto);
            //}
            return GravarProduto(produto);
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(long? id)
        {
            PopularViewBag(produtoServico.ObterProdutoPorId((long)id));
            return ObterVisaoProdutoPorId(id);
            //if (id==null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Produto produto = context.Produtos.Find(id);

            //if (produto==null)
            //{
            //    return HttpNotFound();
            //}

            //ViewBag.CategoriaId = new SelectList(context.Categorias.OrderBy(b => b.nome), "CategoriaId", "Nome", produto.CategoriaId);
            //ViewBag.FabricanteId = new SelectList(context.Fabricantes.OrderBy(b => b.Nome), "FabricanteId", "Nome", produto.FabricanteId);
            //return View(produto);
        }

        // POST: Produtos/Edit/5
        [HttpPost]
        public ActionResult Edit(Produto produto)
        {
            //try
            //{
            //    // TODO: Add update logic here
            //    if (ModelState.IsValid)
            //    {
            //        context.Entry(produto).State = EntityState.Modified;
            //        context.SaveChanges();
            //        return RedirectToAction("Index");
            //    }
            //    return View(produto);
            //}
            //catch
            //{
            //    return View(produto);
            //}
            return GravarProduto(produto);
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(long? id)
        {
            //if (id==null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Produto produto = context.Produtos.Where(p => p.ProdutoId == id).Include(c => c.categoria).Include(f => f.fabricante).First();
            //if (produto==null)
            //{
            //    return HttpNotFound();
            //}
            //return View(produto);
            return ObterVisaoProdutoPorId(id);
        }

        // POST: Produtos/Delete/5
        [HttpPost]
        public ActionResult Delete(long id)
        {
            try
            {
                // TODO: Add delete logic here
                Produto produto = produtoServico.EliminarProdutoPorId(id);//context.Produtos.Find(id);
                //context.Produtos.Remove(produto);
                //context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
