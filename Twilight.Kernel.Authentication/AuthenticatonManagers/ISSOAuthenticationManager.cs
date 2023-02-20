﻿using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Convesys.Kernel.Authentication.AuthenticatonManagers
{
    public interface ISSOAuthenticationManager
    {
        Task Authenticate(ClaimsIdentity identity, Func<object, Task> postAuthDelegate);
    }
}