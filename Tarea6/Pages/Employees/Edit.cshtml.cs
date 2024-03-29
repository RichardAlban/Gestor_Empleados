using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tarea6.Data;
using Tarea6.Models.ViewModels;

namespace Tarea6.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesDemoDbContext dbContext;
        [BindProperty]

        public EditEmployeeViewModel EditEmployeeViewModel { get; set; }

        public EditModel(RazorPagesDemoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void OnGet(Guid id)
        {
            var employee = dbContext.Employees.Find(id);
            if (employee != null)
            {
                EditEmployeeViewModel = new EditEmployeeViewModel()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Email = employee.Email,
                    DateOfBirth = employee.DateOfBirth,
                    Salary = employee.Salary,
                    Departament = employee.Departament
                };
            }
        }

        public void OnPostUpdate()
        {
            if (EditEmployeeViewModel != null)
            {
                var existingEmployee = dbContext.Employees.Find(EditEmployeeViewModel.Id);
                if (existingEmployee != null)
                {

                    existingEmployee.Name = EditEmployeeViewModel.Name;
                    existingEmployee.Email = EditEmployeeViewModel.Email;
                    existingEmployee.Salary = EditEmployeeViewModel.Salary;
                    existingEmployee.DateOfBirth = EditEmployeeViewModel.DateOfBirth;
                    existingEmployee.Departament = EditEmployeeViewModel.Departament;

                    dbContext.SaveChanges();
                    ViewData["Message"] = "Empleado ha sido Modificado";

                }
            }
        }
        public IActionResult OnPostDelete()
        {
			var existingEmployee = dbContext.Employees.Find(EditEmployeeViewModel.Id);
            if(existingEmployee != null)
            {
                dbContext.Employees.Remove(existingEmployee);
                dbContext.SaveChanges();

                return RedirectToPage("/Employees/List");

            }
            return Page();

		}
	}
}
