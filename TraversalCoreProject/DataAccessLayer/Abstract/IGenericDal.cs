﻿using System;
using System.Linq.Expressions;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
	public interface IGenericDal<T>
	{
        void Insert(T t);
        void Delete(T t);
        void Update(T t);
        List<T> GetList();
        T GetByID(int id);
        List<T> GetListByFilter(Expression<Func<T, bool>> filter);
    }
}

