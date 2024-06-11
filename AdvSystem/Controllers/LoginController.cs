using AdvSystem.Data;
using AdvSystem.Helper;
using AdvSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdvSystem.Controllers
{
    public class LoginController : Controller
    {
        private readonly Context _context;
        private readonly ISessao _sessao;
        public LoginController(Context context, ISessao sessao)
        {
            _context = context;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            if(_sessao.BuscarSessao() != null) return RedirectToAction("Index", "Home");
            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessao();
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                { 
                    Usuario usuario = BuscarLogin(loginModel.Login);

                    if(usuario != null)
                    {
                        if (usuario.SenhaValida(loginModel.Senha))
                        {
                            _sessao.CriarSessao(usuario);
                            return RedirectToAction("Index", "Home");
                        }
                        TempData["MenssagemErro"] = "Senha Inválida!";
                    }
                    TempData["MenssagemErro"] = "Dados Inválidos!";
                    return View("Index");
                }
                return View("Index");
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public Usuario BuscarLogin(string login)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login);
        }
    }
}
