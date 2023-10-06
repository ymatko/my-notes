using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyNotes.DataAccess.Repository.IRepository;
using MyNotes.Models;
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
            List<Sheet> objSheetList = _unitOfWork.Sheet.GetAll()
                .Where(s => s.ApplicationUserId == HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value && s.InTrash == false).ToList();
            return View(objSheetList);
        }

        public IActionResult SheetTableIndex()
        {
            List<Sheet> objSheetList = _unitOfWork.Sheet.GetAll().ToList();
            return View(objSheetList);
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
            return RedirectToAction("Index");
        }
    }
}
