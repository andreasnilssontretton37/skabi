using System.Collections.Generic;

namespace skabi.data.Repository.Interfaces
{
    using skabi.data.DomainModel;

    public interface ICarmodelTypeRepository : IRepository<CarmodelType>
    {
        IEnumerable<CarmodelType> GetAllCarmodelTypes();
        IEnumerable<CarmodelType> GetCarmodelTypesForModel(int carmodelId);
        IEnumerable<CarmodelType> GetCarmodelTypesForModel(string carmodelName);
    }
}
