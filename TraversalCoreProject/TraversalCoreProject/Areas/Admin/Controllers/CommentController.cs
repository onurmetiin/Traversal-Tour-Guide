using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            var comList = _commentService.TGetListCommentWithDestination();
            return View(comList);
        }

        public IActionResult DeleteComment(int id)
        {
            var delete = _commentService.TGetByID(id);
            _commentService.TDelete(delete);
            return RedirectToAction("Index");
        }
    }
}

