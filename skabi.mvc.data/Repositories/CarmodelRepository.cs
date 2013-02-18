

using System.Collections.Generic;
using System.Linq;
using skabi.data.Repository.Interfaces;

namespace skabi.data.Repository
{
    using skabi.data.DomainModel;

    public partial class CarmodelRepository : ICarmodelRepository
    {
        public IEnumerable<Carmodel> GetAllCarmodels()
        {
            return _objectSet.OrderByDescending(carmodel => carmodel.CarbrandID);
        }
    }
}
