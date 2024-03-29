﻿namespace Twilight.Kernel.Smtp.Protocol
{
    public interface ISmtpResponse
    {
        string Message { get; }
        SmtpReplyCode ReplyCode { get; }
    }
}