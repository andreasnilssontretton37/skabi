//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.EntityClient;

namespace skabi.data.DomainModel
{
    public partial class rpdbEntities : ObjectContext, IObjectContext
    {
        public const string ConnectionString = "name=rpdbEntities";
        public const string ContainerName = "rpdbEntities";
    
        #region Constructors
    
        public rpdbEntities()
            : base(ConnectionString, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = true;
        }
    
        public rpdbEntities(string connectionString)
            : base(connectionString, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = true;
        }
    
        public rpdbEntities(EntityConnection connection)
            : base(connection, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = true;
        }
    
        #endregion
    
        #region IObjectSet Properties
    
        public IObjectSet<Carbrand> Carbrands
        {
            get { return _carbrands  ?? (_carbrands = CreateObjectSet<Carbrand>("Carbrands")); }
        }
        private IObjectSet<Carbrand> _carbrands;
    
        public IObjectSet<Carmodel> Carmodels
        {
            get { return _carmodels  ?? (_carmodels = CreateObjectSet<Carmodel>("Carmodels")); }
        }
        private IObjectSet<Carmodel> _carmodels;
    
        public IObjectSet<CarmodelType> CarmodelTypes
        {
            get { return _carmodelTypes  ?? (_carmodelTypes = CreateObjectSet<CarmodelType>("CarmodelTypes")); }
        }
        private IObjectSet<CarmodelType> _carmodelTypes;
    
        public IObjectSet<CarmodelTypesProposal> CarmodelTypesProposals
        {
            get { return _carmodelTypesProposals  ?? (_carmodelTypesProposals = CreateObjectSet<CarmodelTypesProposal>("CarmodelTypesProposals")); }
        }
        private IObjectSet<CarmodelTypesProposal> _carmodelTypesProposals;
    
        public IObjectSet<Layout> Layouts
        {
            get { return _layouts  ?? (_layouts = CreateObjectSet<Layout>("Layouts")); }
        }
        private IObjectSet<Layout> _layouts;
    
        public IObjectSet<News> News
        {
            get { return _news  ?? (_news = CreateObjectSet<News>("News")); }
        }
        private IObjectSet<News> _news;
    
        public IObjectSet<Proposal> Proposals
        {
            get { return _proposals  ?? (_proposals = CreateObjectSet<Proposal>("Proposals")); }
        }
        private IObjectSet<Proposal> _proposals;

        #endregion

    public new IObjectSet<T> CreateObjectSet<T>() where T : class
    {
        return base.CreateObjectSet<T>();
    }
    
    public new IObjectSet<T> CreateObjectSet<T>(string name) where T : class
    {
        return base.CreateObjectSet<T>(name);
    }
    
    }
}
