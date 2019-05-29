﻿using Microsoft.IdentityModel.Tokens;
using System;

namespace iPlantino.Infra.CrossCutting.Jwt
{
    public class TokenOptions
    {
        public string Issuer { get; set; }

        //sub (subject) = Entidade à quem o token pertence, normalmente o ID do usuário;
        public string Subject { get; set; }

        public string Audience { get; set; }

        public DateTime NotBefore { get; set; } = DateTime.UtcNow;

        //iat (issued at) = Timestamp de quando o token foi criado;
        public DateTime IssuedAt { get; set; } = DateTime.UtcNow;

        public TimeSpan ValidFor { get; set; } = TimeSpan.FromDays(1000);

        //exp (expiration) = Timestamp de quando o token irá expirar;
        public DateTime Expiration => IssuedAt.Add(ValidFor);

        public Func<string> JtiGenerator => () => Guid.NewGuid().ToString();

        public SigningCredentials SigningCredentials { get; set; }
    }
}