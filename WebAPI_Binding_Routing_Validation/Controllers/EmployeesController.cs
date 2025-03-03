﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Binding_Routing_Validation.DTOs;
using WebAPI_Binding_Routing_Validation.Models;
using WebAPI_Binding_Routing_Validation.Repositories;

namespace WebAPI_Binding_Routing_Validation.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeesController : ControllerBase
	{
		private readonly IRepositoryManager _repository;
		private readonly ILoggerManager _logger;
		private readonly IMapper _mapper;

		public EmployeesController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
		{
			_repository = repository;
			_logger = logger;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult GetEmployeesForCompany(Guid companyId)
		{
			var company = _repository.Company.GetCompany(companyId, trackChanges: false);
			if(company == null)
			{
				_logger.LogInfo($"Company with id: {companyId} doeasn't exist in the database");
				return NotFound();
			}
			var employeesFromDb = _repository.Employee.GetEmployees(companyId, trackChanges: false);
			var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employeesFromDb);
			return Ok(employeesDto);
		}

		[HttpGet("{id}", Name = "GetEmployeeForCompany")]
		public IActionResult GetEmployeeForCompany(Guid companyId, Guid id)
		{
			var company = _repository.Company.GetCompany(companyId, trackChanges: false);
			if(company == null)
			{
				_logger.LogInfo($"Company with id: {companyId} doeasn't exist in the database");
				return NotFound();
			}
			var employeeFromDb = _repository.Employee.GetEmployee(companyId, id, trackChanges:false);
			if(employeeFromDb == null)
			{
				_logger.LogInfo($"Employee with id: {id} doesn't exist in the database");
				return NotFound();
			}
			var employeeDto = _mapper.Map<EmployeeDto>(employeeFromDb);
			return Ok(employeeDto);
		}

		[HttpPost]
		public IActionResult CreateEmployeeForCompany(Guid companyId, [FromBody] EmployeeForCreationDto employee)
		{
			if(employee == null)
			{
				_logger.LogError("EmployeeForCreationDto object sent from client is null.");
				return BadRequest("EmployeeForCreationDto object is null");
			}
			if(!ModelState.IsValid)
			{
				_logger.LogError("Invalid model state for the EmployeeForCreationDto object");
				return UnprocessableEntity(ModelState);
			}
			var company = _repository.Company.GetCompany(companyId, trackChanges: false);
			if(company == null)
			{
				_logger.LogInfo($"Company with id: {companyId} doesn't exist in the database");
				return NotFound();
			}
			var employeeEntity = _mapper.Map<Employee>(employee);
			_repository.Employee.CreateEmployeeForCompany(companyId, employeeEntity);
			_repository.Save();
			var employeeToReturn = _mapper.Map<EmployeeDto>(employeeEntity);
			return CreatedAtRoute("GetEmployeeForCompany", new { companyId, id = employeeToReturn.Id }, employeeToReturn);
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteEmployeeForCompany(Guid companyId, Guid id)
		{
			var company = _repository.Company.GetCompany(companyId, trackChanges: false);
			if(company == null)
			{
				_logger.LogInfo($"Company with id: {companyId} doesn't exist in the database");
				return NotFound();
			}
			var employeeForCompany = _repository.Employee.GetEmployee(companyId, id, trackChanges: false);
			if(employeeForCompany == null)
			{
				_logger.LogInfo($"Employee with id: {id} doesn't exist in the database");
				return NotFound();
			}
			_repository.Employee.DeleteEmployee(employeeForCompany);
			_repository.Save();
			return NoContent();
		}

		[HttpPut("{id}")]
		public IActionResult UpdateEmployeeForCompany(Guid companyId, Guid id, [FromBody] EmployeeForUpdateDto employee)
		{
			if(employee == null)
			{
				_logger.LogError("EmployeeForUpdateDto object sent from client is null.");
				return BadRequest("EmployeeForUpdateDto is null");
			}
			if(!ModelState.IsValid)
			{
				_logger.LogError("Invalid model state for the EmployeeForUpdateDto object");
				return UnprocessableEntity(ModelState);
			}
			var company = _repository.Company.GetCompany(companyId, trackChanges: false);
			if(company == null)
			{
				_logger.LogInfo($"Company with id: {companyId} doesn't exist in the database");
				return NotFound();
			}
			var employeeEntity = _repository.Employee.GetEmployee(companyId, id, trackChanges: true);
			if(employeeEntity == null)
			{
				_logger.LogInfo($"Employee with id: {id} doesn't exist in the database");
				return NotFound();
			}
			_mapper.Map(employee, employeeEntity);
			_repository.Save();
			return NoContent();
		}
	}
}
