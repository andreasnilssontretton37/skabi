using System.Collections.Generic;
using skabi.data.DomainModel;

namespace skabi.common.Services
{
    public interface INewsService
    {
        IEnumerable<News> GetTopFiveNews();
    }
}
