using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyNotes.DataAccess.Repository.IRepository;
using MyNotes.Models;
using MyNotes.Models.ViewModels;
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
            List<Sheet> objUserSheetList = _unitOfWork.Sheet.GetAll()
               .Where(s => s.ApplicationUserId == HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value && s.InTrash == false).ToList();
            List<Sheet> objAdminSheetList = _unitOfWork.Sheet.GetAll()
                .Where(s => s.ApplicationUserId == "66b75e85-857a-47b6-9fd7-1312a9d88671" && s.InTrash == false).ToList();

			TabVM compositeModel = new TabVM()
			{
				Sheets = new SheetVM()
				{
                    UserSheets = objUserSheetList,
                    AdminSheets = objAdminSheetList
                },
				Tabs = objUserTabList
			};
			
			return View(compositeModel);
		}
	}
}
