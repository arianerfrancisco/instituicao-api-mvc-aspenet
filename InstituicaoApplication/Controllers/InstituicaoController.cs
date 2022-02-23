using InstituicaoApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace InstituicaoApplication.Controllers;

public class InstituicaoController : Controller
{
    // o campo static é para permitir ser compartilhador entre as requisições
    private static IList<Instituicao> instituicoes =
        new List<Instituicao>()
        {
            new Instituicao()
            {
                InstituicaoID = 1,
                Nome = "UniParaná",
                Endereco = "Paraná"
            },
            new Instituicao()
            {
                InstituicaoID = 2,
                Nome = "UniSanta",
                Endereco = "Santa Catarina"
            },
            new Instituicao()
            {
                InstituicaoID = 3,
                Nome = "UniSãoPaulo",
                Endereco = "São Paulo"
            },
            new Instituicao()
            {
                InstituicaoID = 4,
                Nome = "UniSulgrandense",
                Endereco = "Rio Grande do Sul"
            },
            new Instituicao()
            {
                InstituicaoID = 5,
                Nome = "UniCarioca",
                Endereco = "Rio de Janeiro"
            }
        };

    public IActionResult Index()
    {
        return View(instituicoes);
       // retorno em ordem alfabetica return View(instituicoes.OrderBy(i => i.Nome));
    }

    public ActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Instituicao instituicao)
    {
        instituicoes.Add(instituicao);
        instituicao.InstituicaoID =
            instituicoes.Select(m => m.InstituicaoID).Max() + 1; // criar o ID. Obtém o valor máximo de Id
        // que será o ultimo e incrementa +1
        return RedirectToAction("Index");
    }
    
    public ActionResult Edit(long id)
    {
        return View(instituicoes.Where(i => i.InstituicaoID == id).First());
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Instituicao instituicao)
    {
        instituicoes.Remove(instituicoes.Where(i => i.InstituicaoID == instituicao.InstituicaoID)
            .First());
        instituicoes.Add(instituicao);
        return RedirectToAction("Index");
        
    }
    public ActionResult Details(long id)
    {
        return View(instituicoes.Where(
            i => i.InstituicaoID == id).First());
    }
    public ActionResult Delete(long id)
    {
        return View(instituicoes.Where(
            i => i.InstituicaoID == id).First());
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(Instituicao instituicao)
    {
        instituicoes.Remove(instituicoes.Where(
                i => i.InstituicaoID == instituicao.InstituicaoID)
            .First());
        return RedirectToAction("Index");
    }
}