using AdvSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace AdvSystem.Filters
{
    public class SecEstLogado : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string sessaoUsuario = context.HttpContext.Session.GetString("sessaousuariologado");
            if(string.IsNullOrEmpty(sessaoUsuario))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary {{"controller", "Login"}, {"action", "Index"}});
            }
            else
            {
                Usuario usuario = JsonConvert.DeserializeObject<Usuario>(sessaoUsuario);
                if(usuario == null)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
                }
                if(usuario.Perfil != Models.Enums.Perfil.Secretario && usuario.Perfil != Models.Enums.Perfil.Estagiario)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Restrito" }, { "action", "Index" } });
                }
            }

            base.OnActionExecuting(context);
        }
    }
}
