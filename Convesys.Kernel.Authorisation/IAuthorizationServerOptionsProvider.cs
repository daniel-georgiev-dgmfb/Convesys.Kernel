namespace Twilight.Kernel.Authorisation
{
    public interface IAuthorizationServerOptionsProvider<TOptions>
    {
        TOptions GetOptions();
    }
}