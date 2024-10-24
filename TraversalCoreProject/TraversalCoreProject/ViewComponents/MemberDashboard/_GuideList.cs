using System;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.ViewComponents.MemberDashboard
{
	public class _GuideList : ViewComponent
	{
		GuideManager guideManager = new GuideManager(new EfGuideDal());

		public IViewComponentResult Invoke()
		{
			var guideList = guideManager.TGetList();
			return View(guideList);
		}
	}
}

