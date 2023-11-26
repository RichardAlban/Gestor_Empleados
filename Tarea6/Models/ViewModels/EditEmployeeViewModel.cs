namespace Tarea6.Models.ViewModels
{
	public class EditEmployeeViewModel
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public long Salary { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string Departament { get; set; }
	}
}
