

using System.Collections.Generic;
using System.Linq;
using skabi.data.Repository.Interfaces;

namespace skabi.data.Repository
{
    using skabi.data.DomainModel;

    public partial class CarmodelTypeRepository : ICarmodelTypeRepository
    {
        public IEnumerable<CarmodelType> GetAllCarmodelTypes()
        {
            return _objectSet.OrderByDescending(carModelType => carModelType.CarmodelTypeID);
        }

        public IEnumerable<CarmodelType> GetCarmodelTypesForModel(int carmodelId)
        {
            return _objectSet.Where(carmodelType => carmodelType.CarmodelID.Equals(carmodelId));
        }

        public IEnumerable<CarmodelType> GetCarmodelTypesForModel(string carmodelName)
        {
            return _objectSet.Where(carmodelType => carmodelType.Carmodel.Name.Equals(carmodelName));
        }
    }
}
