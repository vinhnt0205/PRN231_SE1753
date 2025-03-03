using System.Linq.Expressions;

namespace WebAPI_Binding_Routing_Validation.Repositories
{
	public interface IRepositoryBase<T> 
	{
		IQueryable<T> FindAll(bool trackChanges);
		IQueryable<T> FindByCondition(Expression<Func<T, bool>> predicate, bool trackChanges);
		void Create(T entity);
		void Update(T entity);
		void Delete(T entity);

	}
}
