﻿using System;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.ViewComponents.Default
{
	public class _Feature : ViewComponent
	{
		FeatureManager featureManager = new FeatureManager(new EfFeatureDal());

		public IViewComponentResult Invoke()
		{
			
			return View();
		}
	}
}

