﻿using WebAPI_Binding_Routing_Validation.Models;
namespace WebAPI_Binding_Routing_Validation.Repositories
{
	public interface IEmployeeRepository
	{
		IEnumerable<Employee> GetEmployees(Guid companyId, bool trackChanges);
		Employee GetEmployee(Guid companyId, Guid id, bool trackChanges);
		void CreateEmployeeForCompany(Guid companyId, Employee employee);
		void DeleteEmployee(Employee employee);
	}
}
