using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebAPI_Binding_Routing_Validation.Models;

namespace WebAPI_Binding_Routing_Validation.Repositories.impl
{
	public class RepositoryBase<T> : IRepositoryBase<T> where T : class
	{
		protected RepositoryContext _repositoryContext;
		public RepositoryBase(RepositoryContext repositoryContext)
		{
			_repositoryContext = repositoryContext;
		}

		public void Create(T entity)
		{
			_repositoryContext.Set<T>().Add(entity);
		}

		public void Delete(T entity)
		{
			_repositoryContext.Set<T>().Remove(entity);
		}

		public IQueryable<T> FindAll(bool trackChanges)
		{
			return trackChanges ? _repositoryContext.Set<T>() : _repositoryContext.Set<T>().AsNoTracking();
		}

		public IQueryable<T> FindByCondition(Expression<Func<T, bool>> predicate, bool trackChanges)
		{
			return trackChanges ? _repositoryContext.Set<T>().Where(predicate) : _repositoryContext.Set<T>().Where(predicate).AsNoTracking();
		}

		public void Update(T entity)
		{
			_repositoryContext.Set<T>().Update(entity);
		}
	}
}
