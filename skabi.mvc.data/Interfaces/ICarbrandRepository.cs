


using System.Collections.Generic;

namespace skabi.data.Repository.Interfaces
{
    using skabi.data.DomainModel;

    public interface ICarbrandRepository : IRepository<Carbrand>
    {
        Carbrand GetByName(string carbrandName);
    }
}
