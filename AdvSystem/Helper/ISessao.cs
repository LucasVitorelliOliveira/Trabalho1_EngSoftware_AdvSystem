using AdvSystem.Models;

namespace AdvSystem.Helper
{
    public interface ISessao
    {
        void CriarSessao(Usuario usuario);
        void RemoverSessao();
        Usuario BuscarSessao();
    }
}
