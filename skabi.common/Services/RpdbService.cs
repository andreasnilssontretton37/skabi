using System.Collections.Generic;
using skabi.data.DomainModel;
using skabi.data.Repository.Interfaces;


namespace skabi.common.Services
{

    public class RpdbService : IRpdbService
    {

        private readonly ICarbrandRepository _carbrandRepository;
        private readonly IProposalRepository _proposalRepository;
 
        public RpdbService(ICarbrandRepository carbrandRepository, IProposalRepository proposalRepository)
        {
            _carbrandRepository = carbrandRepository;
            _proposalRepository = proposalRepository;

        }

        public IEnumerable<Proposal> GetLatestProposals(int numberOf)
        {
            return _proposalRepository.GetLatestProposals(numberOf);
        }

        public IEnumerable<Carbrand> GetAllCarbrands()
        {
            return _carbrandRepository.GetAll();
        }
    }
}
