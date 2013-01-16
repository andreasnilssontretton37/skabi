
using System.Linq;
using System.Collections.Generic;
using skabi.data.Repository.Interfaces;

namespace skabi.data.Repository
{
    using skabi.data.DomainModel;

    public partial class NewsRepository : INewsRepository
    {
        public IEnumerable<News> GetTopFiveNews()
        {
            return (from news in _objectSet
                    select news).Take(5);
        }
    }
}
