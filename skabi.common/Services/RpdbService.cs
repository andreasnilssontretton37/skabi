using System;
using System.Collections.Generic;
using skabi.data.DomainModel;
using skabi.data.Repository;
using skabi.data.Repository.Interfaces;


namespace skabi.common.Services
{

    public class RpdbService : IRpdbService
    {
        private readonly ICarbrandRepository _carbrandRepository;
        private readonly ICarmodelRepository _carmodelRepository;
        private readonly ICarmodelTypeRepository _carmodelTypeRepository;
        private readonly IProposalRepository _proposalRepository;
        
 
        public RpdbService(ICarbrandRepository carbrandRepository,
            ICarmodelRepository carmodelRepository,
            ICarmodelTypeRepository carmodelTypeRepository,
            IProposalRepository proposalRepository)
        {
            _carbrandRepository = carbrandRepository;
            _proposalRepository = proposalRepository;
            _carmodelRepository = carmodelRepository;
            _carmodelTypeRepository = carmodelTypeRepository;
        }

        public IEnumerable<Proposal> GetLatestProposals(int numberOf)
        {
            return _proposalRepository.GetLatestProposals(numberOf);
        }

        public IEnumerable<Carmodel> GetCarbrandModels(int carbrandId)
        {
            try
            {
                return _carbrandRepository.GetById(carbrandId).Carmodels;
            }
            catch (Exception e)
            {
                return new List<Carmodel>();
            }
        }

        public IEnumerable<Carmodel> GetCarbrandModels(string carbrandName)
        {

            try
            {
                return _carbrandRepository.GetByName(carbrandName).Carmodels;
            }
            catch (Exception e)
            {
                return new List<Carmodel>();
            }
        }

        public IEnumerable<Carbrand> GetAllCarbrands()
        {
            return _carbrandRepository.GetAll();
        }

        public IEnumerable<Carmodel> GetAllCarmodels()
        {
            return _carmodelRepository.GetAllCarmodels();
        }

        public IEnumerable<CarmodelType> GetCarmodelTypesForModel(int carmodelId)
        {
            try
            {
                return _carmodelTypeRepository.GetCarmodelTypesForModel(carmodelId);
            }
            catch (Exception e)
            {
                return  new List<CarmodelType>();
            }

        }

        public IEnumerable<CarmodelType> GetCarmodelTypesForModel(string carmodelName)
        {
            try
            {
                return _carmodelTypeRepository.GetCarmodelTypesForModel(carmodelName);
            }
            catch (Exception e)
            {
                return new List<CarmodelType>();
            }
        }
    }
}
