using System.Collections.Generic;
using skabi.data.DomainModel;

namespace skabi.common.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Carbrand> Carbrands { get; set; }
    }
}