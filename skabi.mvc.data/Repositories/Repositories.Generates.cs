
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using skabi.data.DomainModel;
 
namespace skabi.data.Repository
{

	using skabi.data.DomainModel;

    public interface IRepository<T> where T : class
    {    
        #region    Methods
    
        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Query(Expression<Func<T, bool>> filter);        
        void Add(T entity);
        void Remove(T entity);   
        
        #endregion
    }
    
    public abstract class Repository<T> : IRepository<T>
                                  where T : class
    {
        #region Members
 
        protected IObjectSet<T> _objectSet;
 
        #endregion
 
        #region Ctor
 
        public Repository(ObjectContext context)
        {
              _objectSet = context.CreateObjectSet<T>();
        }

        #endregion
 
        #region IRepository<T> Members
 
        public IEnumerable<T> GetAll()
        {
              return _objectSet;
        }
 
        public abstract T GetById(int id);
 
        public IEnumerable<T> Query(Expression<Func<T, bool>> filter)
        {
              return _objectSet.Where(filter);
        }
 
        public void Add(T entity)
        {
              _objectSet.AddObject(entity);
        }
 
        public void Remove(T entity)
        {
              _objectSet.DeleteObject(entity);
        }
 
        #endregion
      }
 
    
    public partial class CarbrandRepository : 
		Repository<Carbrand>
    {
        #region Ctor
 
        public CarbrandRepository(ObjectContext context)
               : base(context)
        {
        }
 
        #endregion
 
        #region Methods
 
        public override Carbrand GetById(int id)   
        {
            return _objectSet.SingleOrDefault(e => e.id == id);
        }
 
        #endregion        
    }
    
    public partial class CarmodelRepository : 
		Repository<Carmodel>
    {
        #region Ctor
 
        public CarmodelRepository(ObjectContext context)
               : base(context)
        {
        }
 
        #endregion
 
        #region Methods
 
        public override Carmodel GetById(int id)   
        {
            return _objectSet.SingleOrDefault(e => e.id == id);
        }
 
        #endregion        
    }
    
    public partial class CarmodelTypeRepository : 
		Repository<CarmodelType>
    {
        #region Ctor
 
        public CarmodelTypeRepository(ObjectContext context)
               : base(context)
        {
        }
 
        #endregion
 
        #region Methods
 
        public override CarmodelType GetById(int id)   
        {
            return _objectSet.SingleOrDefault(e => e.id == id);
        }
 
        #endregion        
    }
    
    public partial class CarmodelTypesProposalRepository : 
		Repository<CarmodelTypesProposal>
    {
        #region Ctor
 
        public CarmodelTypesProposalRepository(ObjectContext context)
               : base(context)
        {
        }
 
        #endregion
 
        #region Methods
 
        public override CarmodelTypesProposal GetById(int id)   
        {
            return _objectSet.SingleOrDefault(e => e.id == id);
        }
 
        #endregion        
    }
    
    public partial class NewsRepository : 
		Repository<News>
    {
        #region Ctor
 
        public NewsRepository(ObjectContext context)
               : base(context)
        {
        }
 
        #endregion
 
        #region Methods
 
        public override News GetById(int id)   
        {
            return _objectSet.SingleOrDefault(e => e.id == id);
        }
 
        #endregion        
    }
    
    public partial class ProposalRepository : 
		Repository<Proposal>
    {
        #region Ctor
 
        public ProposalRepository(ObjectContext context)
               : base(context)
        {
        }
 
        #endregion
 
        #region Methods
 
        public override Proposal GetById(int id)   
        {
            return _objectSet.SingleOrDefault(e => e.id == id);
        }
 
        #endregion        
    }
        
  public interface IUnitOfWork
  {
      #region    Methods
    
            IRepository<Carbrand> 
		Carbrands { get; }   
            IRepository<Carmodel> 
		Carmodels { get; }   
            IRepository<CarmodelType> 
		CarmodelTypes { get; }   
            IRepository<CarmodelTypesProposal> 
		CarmodelTypesProposals { get; }   
            IRepository<News> 
		News { get; }   
            IRepository<Proposal> 
		Proposals { get; }   
        void Commit();
    
    #endregion
  }
 
  public partial class UnitOfWork : IUnitOfWork
  {
    #region Members
 
    private readonly ObjectContext _context;
        private CarbrandRepository _carbrands;
        private CarmodelRepository _carmodels;
        private CarmodelTypeRepository _carmodeltypes;
        private CarmodelTypesProposalRepository _carmodeltypesproposals;
        private NewsRepository _news;
        private ProposalRepository _proposals;
        
    #endregion
 
    #region Ctor
 
    public UnitOfWork(ObjectContext context)
    {
      if (context == null)
      {
        throw new ArgumentNullException("context wasn't supplied");
      }
 
      _context = context;
    }
 
    #endregion
 
    #region IUnitOfWork Members
 
        public IRepository<Carbrand> Carbrands
    {
        get
        {
            if (_carbrands == null)
            {
                _carbrands = new CarbrandRepository(_context);
            }
            return _carbrands;
        }
    }
        public IRepository<Carmodel> Carmodels
    {
        get
        {
            if (_carmodels == null)
            {
                _carmodels = new CarmodelRepository(_context);
            }
            return _carmodels;
        }
    }
        public IRepository<CarmodelType> CarmodelTypes
    {
        get
        {
            if (_carmodeltypes == null)
            {
                _carmodeltypes = new CarmodelTypeRepository(_context);
            }
            return _carmodeltypes;
        }
    }
        public IRepository<CarmodelTypesProposal> CarmodelTypesProposals
    {
        get
        {
            if (_carmodeltypesproposals == null)
            {
                _carmodeltypesproposals = new CarmodelTypesProposalRepository(_context);
            }
            return _carmodeltypesproposals;
        }
    }
        public IRepository<News> News
    {
        get
        {
            if (_news == null)
            {
                _news = new NewsRepository(_context);
            }
            return _news;
        }
    }
        public IRepository<Proposal> Proposals
    {
        get
        {
            if (_proposals == null)
            {
                _proposals = new ProposalRepository(_context);
            }
            return _proposals;
        }
    }
        
    
    public void Commit()
    {
      _context.SaveChanges();
    }
 
    #endregion
  }
}
