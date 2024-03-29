﻿using System;
using System.Collections.Generic;
using System.Net;
using Twilight.Kernel.Smtp.IO;

namespace Twilight.Kernel.Smtp
{
    public interface ISessionContext
    {
        event EventHandler<EventArgs> SessionAuthenticated;

        EndPoint RemoteEndPoint { get; }

        ISmtpServerOptions ServerOptions { get; }

        INetworkClient NetworkClient { get; }

        IMessageTransaction Transaction { get; }

        int TransactionCount { get; set; }

        bool IsQuitRequested { get; set; }

        bool IsAuthenticated { get; }

        void SetAuthenticated(bool authenticated);

        IDictionary<string, object> Properties { get; }
    }
}