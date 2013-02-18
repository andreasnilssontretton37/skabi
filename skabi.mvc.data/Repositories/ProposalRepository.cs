
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
            //return _objectSet.OrderByDescending(proposal => proposal.ProposalID).Take(numberOf);
            
            var list = _objectSet.Where(proposal => proposal.CarmodelTypesProposals.Any())
                                 .OrderByDescending(proposal => proposal.ProposalID)
                                 .Take(4);

            return list;

        }
    }
}
