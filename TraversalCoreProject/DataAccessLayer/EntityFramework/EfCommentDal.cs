﻿using System;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EfCommentDal : GenericRepository<Comment>, ICommentDal
    {
        public List<Comment> GetlistCommentWithDestination()
        {
            using var c = new Context();
            return c.Comments.Include(x => x.Destination).ToList();
        }
    }
}

