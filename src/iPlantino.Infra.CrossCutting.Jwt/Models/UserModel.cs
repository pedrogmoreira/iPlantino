﻿using System;

namespace iPlantino.Infra.CrossCutting.Jwt.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
    }
}