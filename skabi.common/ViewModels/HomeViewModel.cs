using System.Collections.Generic;
using skabi.data.DomainModel;

namespace skabi.common.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Carbrand> Carbrands { get; set; }
        public IEnumerable<News> News { get; set; }
        public IEnumerable<Proposal> LatestProposals { get; set; }
    }
}