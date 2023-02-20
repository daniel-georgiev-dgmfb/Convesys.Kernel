﻿using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Twilight.Kernel.Authentication.AuthenticatonManagers
{
    public interface ISSOAuthenticationManager
    {
        Task Authenticate(ClaimsIdentity identity, Func<object, Task> postAuthDelegate);
    }
}