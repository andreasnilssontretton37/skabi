using System;
using System.Data.Objects;

namespace skabi.data.DomainModel
{
    public interface IObjectContext : IDisposable
    {
        IObjectSet<T> CreateObjectSet<T>() where T : class;
        IObjectSet<T> CreateObjectSet<T>(string name) where T : class;
        int SaveChanges();
    }
}
