namespace Convesys.Kernel.Authorisation
{
    public interface IAuthorizationServerOptionsProvider<TOptions>
    {
        TOptions GetOptions();
    }
}