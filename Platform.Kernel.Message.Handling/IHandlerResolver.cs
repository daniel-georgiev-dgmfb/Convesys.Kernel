﻿using System;
using System.Collections.Generic;

namespace Platform.Kernel.Message.Handling
{
    public interface IHandlerResolver
    {
        ICollection<object> ResolveAllHandlersFor(Type targetType);
        
        ICollection<object> ResolveHandlersFor(Type targetType, Func<Type, IHandlerResolverSettings, bool> filter);
    }
}
