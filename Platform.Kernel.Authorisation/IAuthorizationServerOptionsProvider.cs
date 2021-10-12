namespace Platform.Kernel.Authorisation
{
    public interface IAuthorizationServerOptionsProvider<TOptions>
    {
        TOptions GetOptions();
    }
}