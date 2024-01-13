﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PrimeiraApp.Controllers
{
    [Route("/", Order = 0)]
    [Route("minha-conta", Order = 1)]
    [Route("gestao-da-conta", Order = 2)]
    public class TestesController : Controller
    {
        public ActionResult Index()
        {
            return View(); 
        }

        [HttpGet("detalhes/{id:int}/{id2?}")] //parametros opcionais 
        public ActionResult Details(int id, int id2 = 0)
        {
            return View();
        }

        [HttpGet("novo")] //< ---- rotas que eu mesmo defino
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost("novo")]
        [ValidateAntiForgeryToken]

        //public ActionResult Create([FromForm] IFormCollection collection) especifica o formulario todo
        public ActionResult Create([Bind("id, nome, nota")] IFormCollection collection) // especifica somente o q vc quiser
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet("editar/{id:int}")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost("editar/{id:int}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [FromForm] IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet("excluir/{id:int}")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost("excluir/{id:int}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
