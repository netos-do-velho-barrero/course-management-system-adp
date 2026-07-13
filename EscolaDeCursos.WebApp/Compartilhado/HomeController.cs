using Microsoft.AspNetCore.Mvc;

namespace EscolaDeCursos.WebApp.Compartilhado.Apresentacao;

public class HomeController : Controller
{
    [HttpGet]
    public ActionResult Index()
    {
        return RedirectToAction("Login");
    }

    [HttpGet]
    public ActionResult Login()
    {
        return View();
    }

    [HttpGet]
    public ActionResult Dashboard()
    {
        return View();
    }
}
