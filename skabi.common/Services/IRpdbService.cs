using System.Collections.Generic;
using skabi.data.DomainModel;

namespace skabi.common.Services
{
    public interface IRpdbService
    {
        IEnumerable<Carbrand> GetAllCarbrands();
        IEnumerable<Proposal> GetLatestProposals(int numberOf);
        IEnumerable<Carmodel> GetCarbrandModels(int carbrandId);
        IEnumerable<Carmodel> GetCarbrandModels(string carbrandName);
        IEnumerable<Carmodel> GetAllCarmodels();
        IEnumerable<CarmodelType> GetCarmodelTypesForModel(int carmodelId);
        IEnumerable<CarmodelType> GetCarmodelTypesForModel(string carmodelName);
    }
}
