using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using skabi.data.Repository;



namespace skabi.services
{
    using skabi.data.Repository;
    using skabi.data.RpdbModel;

    public class RpdbService : IRpdbService
    {

        private readonly ICarbrandRepository _carbrandRepository;
 
        public RpdbService(ICarbrandRepository carbrandRepository)
        {
            var _carbrandRepository = carbrandRepository;
            
           
        }

        public IEnumerable<Carbrand> GetAllCarbrands()
        {
            return _carbrandRepository.GetAll();
        }
    }
}
