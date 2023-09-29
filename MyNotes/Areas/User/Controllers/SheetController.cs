﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyNotes.DataAccess.Repository.IRepository;
using MyNotes.Models;
using MyNotes.Utility;

namespace MyNotes.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = SD.Role_User)]
    public class SheetController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public SheetController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Sheet> objSheetList = _unitOfWork.Sheet.GetAll().ToList();
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
                return View(new Sheet());
            }
            else
            {
                //update
                Sheet? sheetFromDb = _unitOfWork.Sheet.Get(u => u.Id == id);
                return View(sheetFromDb);
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