
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace skabi.mvc.data
{
    public interface IRepository<T> where T : class
    {    
		#region	Methods
	
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

	
	public partial class carbrandRepository : Repository<carbrand>
	{
		#region Ctor

		public carbrandRepository(ObjectContext context)
   			: base(context)
		{
		}

		#endregion

		#region Methods
 
		public override carbrand GetById(int id)   
		{
			return _objectSet.SingleOrDefault(e => e.id == id);
		}

		#endregion		
	}
	
	public partial class carmodelRepository : Repository<carmodel>
	{
		#region Ctor

		public carmodelRepository(ObjectContext context)
   			: base(context)
		{
		}

		#endregion

		#region Methods
 
		public override carmodel GetById(int id)   
		{
			return _objectSet.SingleOrDefault(e => e.id == id);
		}

		#endregion		
	}
	
	public partial class carmodeltypeRepository : Repository<carmodeltype>
	{
		#region Ctor

		public carmodeltypeRepository(ObjectContext context)
   			: base(context)
		{
		}

		#endregion

		#region Methods
 
		public override carmodeltype GetById(int id)   
		{
			return _objectSet.SingleOrDefault(e => e.id == id);
		}

		#endregion		
	}
	
	public partial class carmodeltypes_proposalsRepository : Repository<carmodeltypes_proposals>
	{
		#region Ctor

		public carmodeltypes_proposalsRepository(ObjectContext context)
   			: base(context)
		{
		}

		#endregion

		#region Methods
 
		public override carmodeltypes_proposals GetById(int id)   
		{
			return _objectSet.SingleOrDefault(e => e.id == id);
		}

		#endregion		
	}
	
	public partial class newsRepository : Repository<news>
	{
		#region Ctor

		public newsRepository(ObjectContext context)
   			: base(context)
		{
		}

		#endregion

		#region Methods
 
		public override news GetById(int id)   
		{
			return _objectSet.SingleOrDefault(e => e.id == id);
		}

		#endregion		
	}
	
	public partial class proposalRepository : Repository<proposal>
	{
		#region Ctor

		public proposalRepository(ObjectContext context)
   			: base(context)
		{
		}

		#endregion

		#region Methods
 
		public override proposal GetById(int id)   
		{
			return _objectSet.SingleOrDefault(e => e.id == id);
		}

		#endregion		
	}
		
  public interface IUnitOfWork
  {
  	#region	Methods
	
			IRepository<carbrand> carbrands { get; }   
			IRepository<carmodel> carmodels { get; }   
			IRepository<carmodeltype> carmodeltypes { get; }   
			IRepository<carmodeltypes_proposals> carmodeltypes_proposals { get; }   
			IRepository<news> news { get; }   
			IRepository<proposal> proposals { get; }   
	    void Commit();
	
	#endregion
  }

  public partial class UnitOfWork : IUnitOfWork
  {
    #region Members

    private readonly ObjectContext _context;
		private carbrandRepository _carbrands;
		private carmodelRepository _carmodels;
		private carmodeltypeRepository _carmodeltypes;
		private carmodeltypes_proposalsRepository _carmodeltypes_proposals;
		private newsRepository _news;
		private proposalRepository _proposals;
	    
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

		public IRepository<carbrand> carbrands
	{
		get
		{
			if (_carbrands == null)
			{
				_carbrands = new carbrandRepository(_context);
			}
			return _carbrands;
		}
	}
		public IRepository<carmodel> carmodels
	{
		get
		{
			if (_carmodels == null)
			{
				_carmodels = new carmodelRepository(_context);
			}
			return _carmodels;
		}
	}
		public IRepository<carmodeltype> carmodeltypes
	{
		get
		{
			if (_carmodeltypes == null)
			{
				_carmodeltypes = new carmodeltypeRepository(_context);
			}
			return _carmodeltypes;
		}
	}
		public IRepository<carmodeltypes_proposals> carmodeltypes_proposals
	{
		get
		{
			if (_carmodeltypes_proposals == null)
			{
				_carmodeltypes_proposals = new carmodeltypes_proposalsRepository(_context);
			}
			return _carmodeltypes_proposals;
		}
	}
		public IRepository<news> news
	{
		get
		{
			if (_news == null)
			{
				_news = new newsRepository(_context);
			}
			return _news;
		}
	}
		public IRepository<proposal> proposals
	{
		get
		{
			if (_proposals == null)
			{
				_proposals = new proposalRepository(_context);
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
