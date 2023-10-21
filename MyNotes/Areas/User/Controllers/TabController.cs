using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyNotes.DataAccess.Repository.IRepository;
using MyNotes.Models;
using System.Security.Claims;

namespace MyNotes.Areas.User.Controllers
{
	[Area("User")]
	[Authorize]
	public class TabController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		public TabController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public IActionResult Index()
		{
			List<Tab> objUserTabList = _unitOfWork.Tab.GetAll().Where(t => t.Sheet.ApplicationUserId == HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value).ToList();
			return View(objUserTabList);
		}
	}
}
