using PortalS.Filtros;
using PortalS.Models;
using System;
using System.Web.Mvc;


namespace PortalS.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            var login = new Login()
            {
                TipoLogin = "G",
                User = " ",
                Senha = " "
            };

            return View(login);
        }

        [HttpPost]
        public ActionResult ExecutaLogin(string TipoLogin, string User, string Senha)
        {
            ViewData["TipoLogin"] = TipoLogin;
            ViewData["User"] = User;
            ViewData["Senha"] = Senha;
            
            if (User.Equals("usuario") && Senha.Equals("123456"))
            {
                Session["User"] = User;
                return RedirectToAction("Afinidades");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }
        

        [HttpPost]
        [FiltroAcesso]
        public ActionResult Cadastro(string TipoLogin)
        {
            ViewData["TipoLogin"] = TipoLogin;

            if (TipoLogin == "G")
            {
                return RedirectToAction("CadastroGoverno");
            }
            else if (TipoLogin == "E")
            {
                return RedirectToAction("CadastroEntidade"); 
            }
            else if (TipoLogin == "V")
            {
                return RedirectToAction("CadastroVoluntario"); 
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

        [FiltroAcesso]
        public ActionResult FinalizarCadastro()
        {
            return RedirectToAction("Index");
        }

        [FiltroAcesso]
        public ActionResult ExecutaAfinidades()
        {
            return RedirectToAction("Index");
        }

        [FiltroAcesso]
        public ActionResult Cadastrar(string TipoLogin)
        {
            return View();

        }

        [FiltroAcesso]
        public ActionResult CadastroGoverno()
        {
            return View();
        }

        [FiltroAcesso]
        public ActionResult CadastroEntidade()
        {
            return View();
        }

        [FiltroAcesso]
        public ActionResult CadastroVoluntario()
        {
            return View();
        }

        [FiltroAcesso]
        public ActionResult Afinidades()
        {
            if(Session["User"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}