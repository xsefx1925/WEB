
using ContosoUniversity.Data;
using ContosoUniversity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Controllers
{
	public class StudentController : Controller
	{
		private readonly UniversityContext _context;

		public StudentController(UniversityContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> Index(
			string sortOrder,
			string currentFilter,
			string searchString,
			int? pageNumber)
		{
		
			ViewData["CurrentSort"] = sortOrder;
			ViewData["NameSortParm"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
			ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

			if (searchString != null)
			{
				pageNumber = 1;
			}
			else
			{
				searchString = currentFilter;
			}

			ViewData["CurrentFilter"] = searchString;

			var students = from s in _context.Students
						   select s;

			
			if (!string.IsNullOrEmpty(searchString))
			{
				students = students.Where(s => s.LastName.Contains(searchString)
									   || s.FirstName.Contains(searchString));
			}

			switch (sortOrder)
			{
				case "name_desc":
					students = students.OrderByDescending(s => s.LastName);
					break;
				case "Date":
					students = students.OrderBy(s => s.EnrollmentDate);
					break;
				case "date_desc":
					students = students.OrderByDescending(s => s.EnrollmentDate);
					break;
				default:
					students = students.OrderBy(s => s.LastName);
					break;
			}

			
			int pageSize = 3; 
			return View(await PaginatedList<Student>.CreateAsync(students.AsNoTracking(), pageNumber ?? 1, pageSize));
		}
	
	}
}