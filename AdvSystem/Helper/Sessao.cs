using AdvSystem.Models;
using Newtonsoft.Json;

namespace AdvSystem.Helper
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public Sessao(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public Usuario BuscarSessao()
        {
            string sessaoUsuario = _contextAccessor.HttpContext.Session.GetString("sessaousuariologado");
            if (string.IsNullOrEmpty(sessaoUsuario)) return null;
            return JsonConvert.DeserializeObject<Usuario>(sessaoUsuario);
        }

        public void CriarSessao(Usuario usuario)
        {
            string valor = JsonConvert.SerializeObject(usuario);

            _contextAccessor.HttpContext.Session.SetString("sessaousuariologado", valor);
        }

        public void RemoverSessao()
        {
            _contextAccessor.HttpContext.Session.Remove("sessaousuariologado");
        }
    }
}
