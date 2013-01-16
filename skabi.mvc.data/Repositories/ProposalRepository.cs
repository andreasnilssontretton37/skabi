
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using skabi.data.Repository.Interfaces;


namespace skabi.data.Repository
{
    using skabi.data.DomainModel;

    public partial class ProposalRepository : IProposalRepository
    {
        public IEnumerable<Proposal> GetLatestProposals(int numberOf)
        {
            return _objectSet.OrderBy(proposal => proposal.id).Take(numberOf);
        }
    }
}
