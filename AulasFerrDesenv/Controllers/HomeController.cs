using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AulasFerrDesenv.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public String BoasVindas(string nome, string teste, int cont=1)
        {
            return HttpUtility.HtmlEncode("Olá " + nome + ", contador está valendo " + cont+teste);
        }
    }
}