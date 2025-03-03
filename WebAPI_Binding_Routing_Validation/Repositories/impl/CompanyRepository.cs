using WebAPI_Binding_Routing_Validation.Models;

namespace WebAPI_Binding_Routing_Validation.Repositories.impl
{
	public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
	{
		public CompanyRepository(RepositoryContext repositoryContext) : base(repositoryContext)
		{
		}

		public void CreateCompany(Company company)
		{
			Create(company);
		}

		public void DeleteCompany(Company company)
		{
			Delete(company);
		}

		public IEnumerable<Company> GetAllCompanies(bool trackChanges)
		{
			return FindAll(trackChanges).OrderBy(x => x.Name).ToList();
		}

		public IEnumerable<Company> GetByIds(IEnumerable<Guid> ids, bool trackChanges)
		{
			return FindByCondition(x => ids.Contains(x.Id), trackChanges);
		}

		public Company GetCompany(Guid companyId, bool trackChanges)
		{
			return FindByCondition(x => x.Id.Equals(companyId), trackChanges).SingleOrDefault();
		}
	}
}
