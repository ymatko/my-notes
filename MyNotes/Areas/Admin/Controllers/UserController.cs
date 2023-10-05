using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyNotes.DataAccess.Data;
using MyNotes.DataAccess.Repository.IRepository;
using MyNotes.Models;
using MyNotes.Utility;

namespace MyNotes.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = SD.Role_Admin)]
	public class UserController : Controller
	{
		private readonly ApplicationDbContext _db;
		public UserController(ApplicationDbContext db)
		{
			_db = db;
		}
		public IActionResult Index()
		{
			List<ApplicationUser> applicationUsers = _db.ApplicationUsers.ToList();
			var userRoles = _db.UserRoles.ToList();
			var roles = _db.Roles.ToList();

			foreach(var user in applicationUsers)
			{
				var roleId = userRoles.FirstOrDefault(u => u.UserId == user.Id).RoleId;
				user.Role = roles.FirstOrDefault(u => u.Id == roleId).Name;
				user.QuantityOfSheet = _db.Sheets.Where(s => s.ApplicationUserId == user.Id).Count();

			}

			return View(applicationUsers);
		}
	}
}
