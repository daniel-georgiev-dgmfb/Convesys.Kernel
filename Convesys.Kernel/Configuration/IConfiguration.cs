namespace Twilight.Kernel.Configuration
{
    public interface IConfiguration
    {
        string this[string key] { get; set; }

        T GetValue<T>(string key);

        void SetValue<T>(string key, T value);
    }
}
