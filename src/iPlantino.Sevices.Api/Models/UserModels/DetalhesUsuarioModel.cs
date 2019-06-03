﻿using System;
using System.Collections.Generic;

namespace Egl.Sit.Api.V1.Usuarios.Models
{
    public class DetalhesUsuarioModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Login { get; set; }
        public DateTime? DataFimDoBloqueio { get; set; }
        public int ContadorErroSenha { get; set; }
        public IEnumerable<string> Grupos { get; set; }
    }
}
