using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyNotes.DataAccess.Repository.IRepository;
using MyNotes.Models;
using MyNotes.Utility;

namespace MyNotes.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = SD.Role_Admin)]
	public class UserController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		public UserController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public IActionResult Index()
		{
			List<ApplicationUser> applicationUsers = _unitOfWork.ApplicationUser.GetAll().ToList();
			return View(applicationUsers);
		}
	}
}
