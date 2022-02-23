using Microsoft.AspNetCore.Mvc;

namespace InstituicaoApplication.Controllers;

public class InstituicaoController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}