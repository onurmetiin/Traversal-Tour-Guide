using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TraversalCoreProject.Controllers
{
    public class CommentController : Controller
    {
        CommentManager commentManager = new CommentManager(new EfCommentDal());

        [HttpGet]
        public PartialViewResult AddComment()
        {
            return PartialView();
        }


        [HttpPost]
        public PartialViewResult AddComment(Comment c)
        {
            c.CommentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            c.CommentState = true;
            commentManager.TAdd(c);
            return PartialView();
        }
    }
}

