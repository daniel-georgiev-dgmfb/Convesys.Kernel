namespace Platform.Kernel.Smtp
{
    public interface ISmtpServerFactory
    {
        ISmtpServer CreateInstance();
    }
}