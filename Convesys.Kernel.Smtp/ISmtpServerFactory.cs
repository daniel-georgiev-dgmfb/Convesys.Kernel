namespace Convesys.Kernel.Smtp
{
    public interface ISmtpServerFactory
    {
        ISmtpServer CreateInstance();
    }
}