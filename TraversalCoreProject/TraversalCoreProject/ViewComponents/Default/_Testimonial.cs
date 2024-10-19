using System;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.ViewComponents.Default
{
	public class _Testimonial : ViewComponent
	{
		TestimonialManager testimonialManager = new TestimonialManager(new EfTestimonialDal());

		public IViewComponentResult Invoke()
		{
			ViewBag.v1 = testimonialManager.TGetByID(1);
			ViewBag.v2 = testimonialManager.TGetByID(2);
            return View();
		}
	}
}

