namespace Twilight.Kernel.Smtp
{
    public interface ISmtpServerFactory
    {
        ISmtpServer CreateInstance();
    }
}