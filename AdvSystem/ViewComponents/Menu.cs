using AdvSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AdvSystem.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string sessaoUsuario = HttpContext.Session.GetString("sessaousuariologado");
            if (string.IsNullOrEmpty(sessaoUsuario)) return null;
            Usuario usuario = JsonConvert.DeserializeObject<Usuario>(sessaoUsuario);
            return View(usuario);
        }
    }
}
