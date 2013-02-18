using System.Collections.Generic;

namespace skabi.data.Repository.Interfaces
{
    using skabi.data.DomainModel;

    public interface ICarmodelRepository : IRepository<Carmodel>
    {
        IEnumerable<Carmodel> GetAllCarmodels();
    }
}
