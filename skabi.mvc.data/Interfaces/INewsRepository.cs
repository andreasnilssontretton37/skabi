using System.Collections.Generic;

namespace skabi.data.Repository.Interfaces
{
    using skabi.data.DomainModel;

    public interface INewsRepository : IRepository<News>
    {
        IEnumerable<News> GetTopFiveNews();
    }
}
