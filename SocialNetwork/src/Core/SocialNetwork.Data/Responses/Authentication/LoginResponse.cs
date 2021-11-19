﻿using System;

namespace SocialNetwork.Data.Responses.Authentication
{
    public class LoginResponse
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string JWToken { get; set; }
    }
}
