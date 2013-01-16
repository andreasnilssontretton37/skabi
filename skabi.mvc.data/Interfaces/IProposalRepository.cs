using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skabi.data.Repository.Interfaces
{
    using skabi.data.DomainModel;

    public interface IProposalRepository : IRepository<Proposal>
    {
        IEnumerable<Proposal> GetLatestProposals(int numberOf);
    }
}
