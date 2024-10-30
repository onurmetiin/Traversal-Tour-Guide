using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;


namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GuideController : Controller
    {
        private readonly IGuideService _guideService;

        public GuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }

        public IActionResult Index()
        {
            var guideList = _guideService.TGetList();
            return View(guideList);
        }

        [HttpGet]
        public IActionResult AddGuide()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddGuide(Guide newGuide)
        {
            GuideValidator validatorGuide = new GuideValidator();
            ValidationResult result = validatorGuide.Validate(newGuide);
            if(result.IsValid)
            {
                _guideService.TAdd(newGuide);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult EditGuide(int id)
        {
            var editedGuide = _guideService.TGetByID(id);
            _guideService.TUpdate(editedGuide);
            return View();
        }

        [HttpPost]
        public IActionResult EditGuide(Guide guide)
        {
            _guideService.TUpdate(guide);
            return RedirectToAction("Index");
        }

        public IActionResult ChangeStatusToActive(int id)
        {
            return RedirectToAction("Index");
        }

        public IActionResult ChangeStatusToInactive(int id)
        {
            return RedirectToAction("Index");
        }
    }
}

