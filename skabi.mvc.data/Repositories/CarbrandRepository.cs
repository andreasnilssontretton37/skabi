

using System.Collections.Generic;
using System.Linq;
using skabi.data.Repository.Interfaces;


namespace skabi.data.Repository
{
    using skabi.data.DomainModel;

    public partial class CarbrandRepository : ICarbrandRepository
    {
        public Carbrand GetByName(string carbrandName)
        {
            return _objectSet.SingleOrDefault(e => e.Name == carbrandName);
        
        }
    }
}
