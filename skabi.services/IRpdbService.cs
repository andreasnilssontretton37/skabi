using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using skabi.data.RpdbModel;

namespace skabi.services
{
    public interface IRpdbService
    {
        IEnumerable<Carbrand> GetAllCarbrands();
    }
}
