using Microsoft.AspNetCore.Mvc;
using PrimeiraApp.Models;

namespace PrimeiraApp.ViewComponents
{
    public class SaudacaoAlunoViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //pegar o aluno no db
            var aluno = new Aluno() { Nome = "Sérgio" };

            return View(aluno);
        }
    }
}
