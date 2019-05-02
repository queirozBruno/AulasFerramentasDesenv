using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
//using GerencProdAndCateg.Contexts;
using Modelo.Cadastros;
using Modelo.Tabelas;

namespace GerencProdAndCateg.Controllers
{
    public class CategoriasController : Controller
    {
        private EFContext context = new EFContext();

        private static IList<Categoria> categorias = new List<Categoria>()
        {          

            new Categoria()
            {
                CategoriaId = 1,
                nome = "Notebooks"
            },
            new Categoria()
            {
                CategoriaId = 2,
                nome = "Monitores"
            },
            new Categoria()
            {
                CategoriaId = 3,
                nome = "Impressoras"
            },
            new Categoria()
            {
                CategoriaId = 4,
                nome = "Mouses"
            },
            new Categoria()
            {
                CategoriaId = 5,
                nome = "Desktops"
            }
        };

        // GET: Categorias
        public ActionResult Index()
        {
            return View(context.Categorias.OrderBy(c=>c.nome));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(Categoria categoria)
        {
            context.Categorias.Add(categoria);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(long? id) //long? Significa que pode ser passado um valor nulo
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = context.Categorias.Find(id);
            if (categoria==null)
            {
                HttpNotFound();
            }
            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(Categoria categoria)
        {
            if (ModelState.IsValid) //Testa se modelo é válido
            {
                context.Entry(categoria).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        public ActionResult Details(long? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = context.Categorias.Find(id);
            if (categoria==null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        public ActionResult Delete(long? id)
        {
            if (id==null) 
            { 
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = context.Categorias.Find(id);
            if (categoria==null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Delete(long id)
        {
            Categoria categoria = context.Categorias.Find(id);
            context.Categorias.Remove(categoria);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}