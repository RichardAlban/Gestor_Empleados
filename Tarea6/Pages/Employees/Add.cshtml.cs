using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tarea6.Data;
using Tarea6.Models.Domain;
using Tarea6.Models.ViewModels;

namespace Tarea6.Pages.Employees
{
    public class AddModel : PageModel
    {
		private readonly RazorPagesDemoDbContext dbContext;

		public AddModel(RazorPagesDemoDbContext dbContext)
        {
			this.dbContext = dbContext;
		}
        [BindProperty]
        public AddEmployeeViewModel AddEmployeeRequest { get; set; }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            //Convierto el ViewModel a DomainModel
            var empleyeeDomainModel = new Employee
            {
                Name = AddEmployeeRequest.Name,
                Email = AddEmployeeRequest.Email,
                Salary = AddEmployeeRequest.Salary,
                DateOfBirth = AddEmployeeRequest.DateOfBirth,
                Departament = AddEmployeeRequest.Departament
            };
            dbContext.Employees.Add(empleyeeDomainModel);
            dbContext.SaveChanges();

            ViewData["Message"] = "Empleado creado";
        }
    }
}
