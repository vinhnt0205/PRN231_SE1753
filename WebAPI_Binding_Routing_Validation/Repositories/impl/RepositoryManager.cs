using WebAPI_Binding_Routing_Validation.Models;

namespace WebAPI_Binding_Routing_Validation.Repositories.impl
{
	public class RepositoryManager : IRepositoryManager
	{
		private readonly RepositoryContext _repositoryContext;
		private ICompanyRepository _companyRepository;
		private IEmployeeRepository _employeeRepository;
		public RepositoryManager(RepositoryContext repositoryContext)
		{
			_repositoryContext = repositoryContext;
		}
		public ICompanyRepository Company => _companyRepository == null ? new CompanyRepository(_repositoryContext) : _companyRepository;

		public IEmployeeRepository Employee => _employeeRepository == null ? new EmployeeRepository(_repositoryContext) : _employeeRepository;

		public void Save()
		{
			_repositoryContext.SaveChanges();
		}
	}
}
