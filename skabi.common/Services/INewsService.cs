using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using skabi.data.DomainModel;

namespace skabi.common.Services
{
    public interface INewsService
    {
        IEnumerable<News> GetTopFiveNews();
        News Add(News item);
    }
}
