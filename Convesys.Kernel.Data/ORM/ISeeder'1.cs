﻿namespace Twilight.Kernel.Data.ORM
{
    public interface ISeeder<T> : ISeeder
    {
        void Seed(T builder);
    }
}