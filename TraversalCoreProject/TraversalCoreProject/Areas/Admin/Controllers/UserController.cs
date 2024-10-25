using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        IAppUserService _appUserService;
        public UserController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        public IActionResult Index()
        {
            var userList = _appUserService.TGetList();
            return View(userList);
        }

        public IActionResult DeleteUser(int id)
        {
            var deletedUser = _appUserService.TGetByID(id);
            _appUserService.TDelete(deletedUser);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditUser(int id)
        {
            var editedUser = _appUserService.TGetByID(id);
            _appUserService.TUpdate(editedUser);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EditUser(AppUser user)
        {            
            _appUserService.TUpdate(user);
            return RedirectToAction("Index");
        }

        public IActionResult CommentUser(int id)
        {
            return View();
        }

        public IActionResult ReservationUser(int id)
        {

            return View();
        }
    }
}

