using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrimeiraApp.Data;
using PrimeiraApp.Models;

namespace PrimeiraApp.Controllers
{
    public class AlunosController : Controller
    {

        private readonly AppDbContext _context;

        public AlunosController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Alunos.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] //<--- metodo post
        [ValidateAntiForgeryToken] //<--- anti ataque de envio de formulario
        public async Task<IActionResult> Create([Bind("Id,Nome,DataNascimento,Email,EmailConfirmacao,Avaliacao,Ativo")]Aluno aluno) //<--- medoto assincrono ou seja esta conversando em tempo real com o bd
        {
            if (ModelState.IsValid)
            {
                _context.Alunos.Add(aluno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(aluno);
        }

        public async Task<IActionResult> Details(int id)
        {
            var aluno = (await _context.Alunos.FirstOrDefaultAsync(m => m.Id == id)); //<---- FirstOrDefaultAsync pega o primeiro que encontra com esse id
            return View(aluno);
        }

        public async Task<IActionResult> Edit(int id) 
        {
            var aluno = await _context.Alunos.FindAsync(id);
            return View(aluno);
        }

        [HttpPost] //<--- metodo post
        [ValidateAntiForgeryToken] //<--- anti ataque de envio de formulario
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,DataNascimento,Email,EmailConfirmacao,Avaliacao,Ativo")] Aluno aluno) //<--- medoto assincrono ou seja esta conversando em tempo real com o bd
        {

            if(id != aluno.Id) //se o id for diferente 
            {
                return NotFound();
            }

            ModelState.Remove("EmailConfirmacao"); //<- nao vamos utilizar a confirmacao email entao para nao ter erro de validação estamos removendo ela

            if(ModelState.IsValid)
            {
                _context.Alunos.Update(aluno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(aluno);
        }
    }
}
