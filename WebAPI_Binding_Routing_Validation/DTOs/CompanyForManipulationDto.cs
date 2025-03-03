﻿using System.ComponentModel.DataAnnotations;
namespace WebAPI_Binding_Routing_Validation.DTOs
{
	public abstract class CompanyForManipulationDto
	{
		[Required(ErrorMessage = "Company name is a required field.")]
		[MaxLength(60, ErrorMessage = "Maximum length for the Name is 60 characters.")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Company address is a required field.")]
		[MaxLength(60, ErrorMessage = "Maximum length for the Address is 60 charaters.")]
		public string Address { get; set; }
		public string Country { get; set; }
	}
}
