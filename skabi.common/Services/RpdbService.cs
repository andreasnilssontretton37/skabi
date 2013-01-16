using System.Collections.Generic;
using skabi.data.DomainModel;
using skabi.data.Repository.Interfaces;


namespace skabi.common.Services
{

    public class RpdbService : IRpdbService
    {

        private readonly ICarbrandRepository _carbrandRepository;
 
        public RpdbService(ICarbrandRepository carbrandRepository)
        {
            _carbrandRepository = carbrandRepository;
            
           
        }

        public IEnumerable<Carbrand> GetAllCarbrands()
        {
            return _carbrandRepository.GetAll();
        }
    }
}
