namespace Platform.Kernel.Configuration
{
    public interface ICustomConfigurator<in T>
    {
        void Configure(T configurable);
    }
}