using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyNotes.DataAccess.Repository.IRepository;
using MyNotes.Models;
using MyNotes.Models.ViewModels;
using MyNotes.Utility;
using System.Security.Claims;

namespace MyNotes.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class SheetController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public SheetController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Sheet> objUserSheetList = _unitOfWork.Sheet.GetAll()
                .Where(s => s.ApplicationUserId == HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value && s.InTrash == false).ToList();
            List<Sheet> objAdminSheetList = _unitOfWork.Sheet.GetAll()
                .Where(s => s.ApplicationUserId == "66b75e85-857a-47b6-9fd7-1312a9d88671" && s.InTrash == false).ToList();

            SheetVM compositeModel = new SheetVM()
            {
                UserSheets = objUserSheetList,
                AdminSheets = objAdminSheetList
            };
            return View(compositeModel);
        }

        public IActionResult Upsert(int? id)
        {   
            if (id == null || id == 0)
            {
                //create
                Sheet sheet = new() {
                    ApplicationUserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value,
                    Name = "",
                    Text = ""
                };
                return View(sheet);
            }
            else
            {
                //update
                Sheet? sheetFromDb = _unitOfWork.Sheet.Get(u => u.Id == id);
                if (sheetFromDb.ApplicationUserId == HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value)
                {
                    return View(sheetFromDb);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
        }

        [HttpPost]
        public IActionResult Upsert(Sheet obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Id == 0)
                {
                    _unitOfWork.Sheet.Add(obj);
                    TempData["success"] = "Sheet created successfully";
                }
                else
                {
                    _unitOfWork.Sheet.Update(obj);
                    TempData["success"] = "Sheet updated successfully";

                }
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }
        }
        public IActionResult Trash(int? id)
        {
            if (id == 0 || id == null)
            {
                List<Sheet> objSheetList = _unitOfWork.Sheet.GetAll()
                .Where(s => s.ApplicationUserId == HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value && s.InTrash == true).ToList();
                return View(objSheetList);
            }
            Sheet? obj = _unitOfWork.Sheet.Get(u => u.Id == id);
            obj.InTrash = true;
            _unitOfWork.Sheet.Update(obj);
            TempData["success"] = "Sheet added to trash";
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
        public IActionResult OffTrash(int? id)
        {
            if (id == 0 || id == null)
            {
                List<Sheet> objSheetList = _unitOfWork.Sheet.GetAll()
                .Where(s => s.ApplicationUserId == HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value && s.InTrash == true).ToList();
                return View(objSheetList);
            }
            Sheet? obj = _unitOfWork.Sheet.Get(u => u.Id == id);
            obj.InTrash = false;
            _unitOfWork.Sheet.Update(obj);
            TempData["success"] = "Sheet was deleted from trash";
            _unitOfWork.Save();
            return RedirectToAction("Trash");
        }

        public IActionResult Delete(int? id)
        {
            Sheet? obj = _unitOfWork.Sheet.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Sheet.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Sheet deleted successfully";
            return RedirectToAction("Trash");
        }

        public IActionResult DeleteRange()
        {
            IEnumerable<Sheet> sheets = _unitOfWork.Sheet.GetAll().Where(s => s.ApplicationUserId == HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value && s.InTrash == true);
            if (sheets == null)
            {
                return NotFound();
            }
            _unitOfWork.Sheet.RemoveRange(sheets);
            _unitOfWork.Save();
            TempData["success"] = "Sheets deleted successfully";
            return RedirectToAction("Trash");
        }
    }
}
