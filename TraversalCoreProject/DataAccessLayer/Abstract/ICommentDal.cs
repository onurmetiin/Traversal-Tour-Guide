﻿using System;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
	public interface ICommentDal : IGenericDal<Comment>
	{
		public List<Comment> GetlistCommentWithDestination();
	}
}

