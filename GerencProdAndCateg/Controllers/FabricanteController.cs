using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GerencProdAndCateg.Contexts;
//using GerencProdAndCateg.Models;
using System.Net;
using System.Data.Entity;
using Modelo.Cadastros;
using Modelo.Tabelas;

namespace GerencProdAndCateg.Controllers
{
    public class FabricanteController : Controller
    {
        private EFContext context = new EFContext();

        private static IList<Fabricante> fabricantes = new List<Fabricante>()
        {
            new Fabricante()
            {
                FabricanteId = 1,
                Nome="LG"                
            }
        };

        // GET: Fabricante
        public ActionResult Index()
        {
            return View(context.Fabricantes.OrderBy(c=>c.Nome));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(Fabricante fabricante)
        {
            context.Fabricantes.Add(fabricante);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(long? id) //long? Significa que pode ser passado um valor nulo
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabricante fabricante = context.Fabricantes.Find(id);
            if (fabricante == null)
            {
                return HttpNotFound();
            }
            return View(fabricante);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(Fabricante fabricante)
        {
            if (ModelState.IsValid) //Testa se o modelo é válido como por exemplo se nenhum valor inválido foi inserido
            {
                context.Entry(fabricante).State = EntityState.Modified; //Avisa ao EF que houve uma MODIFICAÇÃO nos dados
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fabricante);
        }

        public ActionResult Details(long? id) //long? significa que pode ser passado um valor nulo
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabricante fabricante = context.Fabricantes.Find(id);
            if (fabricante == null)
            {
                return HttpNotFound();
            }
            return View(fabricante);
        }

        public ActionResult Delete(long? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabricante fabricante = context.Fabricantes.Find(id);
            if (fabricante==null)
            {
                return HttpNotFound();
            }
            return View(fabricante);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Delete(long id)
        {
            Fabricante fabricante = context.Fabricantes.Find(id);
            context.Fabricantes.Remove(fabricante);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}