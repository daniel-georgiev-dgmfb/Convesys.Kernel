namespace Convesys.Kernel.Data.ORM
{
    public interface ISeeder<T> : ISeeder
    {
        void Seed(T builder);
    }
}