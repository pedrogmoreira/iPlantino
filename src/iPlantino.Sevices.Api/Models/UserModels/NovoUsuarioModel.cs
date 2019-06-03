using System.Collections.Generic;

namespace Egl.Sit.Api.V1.Usuarios.Models
{
    public class AdicionarUsuarioModel
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string ConfirmaSenha { get; set; }
        public IEnumerable<string> Grupos { get; set; }
    }
}
