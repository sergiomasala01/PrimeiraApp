using Microsoft.AspNetCore.Mvc;
using PrimeiraApp.Models;

namespace PrimeiraApp.Controllers
{
    public class ModelsController : Controller
    {
        public IActionResult Index() 
        {
            var Aluno = new Aluno();

            if (TryValidateModel(Aluno))
            {
                return View(Aluno);
            }

            return View();
        }
    }
}
