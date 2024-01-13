using Microsoft.AspNetCore.Mvc;
using PrimeiraApp.Data;
using PrimeiraApp.Models;

namespace PrimeiraApp.Controllers
{
    public class TesteEFController : Controller
    {
        public AppDbContext Db {  get; set; }
        public TesteEFController(AppDbContext db)
        {
            Db = db;
        }
        public IActionResult Index()
        {

            var aluno = new Aluno()
            {
                Nome = "Sérgio",
                Email = "sergiomasala@gmail.com",
                DataNascimento = new DateTime(2004, 09, 09),
                Avaliacao = 5,
                Ativo = true
            };

            //Db.Alunos.Add(aluno);
            //Db.SaveChanges();

            var alunosChange = Db.Alunos.Where(a => a.Nome.Contains("Sérgio")).FirstOrDefault();
            //alunosChange.Nome = "Sérgio Masala";

            //Db.Alunos.Update(alunosChange);
            //Db.SaveChanges();

            Db.Alunos.Remove(alunosChange);
            Db.SaveChanges();

            return Content("");
        }
    }
}
