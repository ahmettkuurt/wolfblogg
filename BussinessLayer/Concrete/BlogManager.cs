﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class BlogManager : IBlogService
	{
		IBlogDal _blogDal;

		public BlogManager(IBlogDal blogDal)
		{
			_blogDal = blogDal;
		}

        public List<Blog> GetBLogListWithCategory()
        {
            return _blogDal.GetListWithCategory();
        }
        public List<Blog> GetListWithCategoryByWriterBm(int id)
        {
            return _blogDal.GetListWithCategoryByWriter(id);
        }

        public Blog TGetById(int id)
		{
			return _blogDal.GetById(id);
		}

		public List<Blog> GetList()
		{
			return _blogDal.GetListAll();
		}

		public List<Blog> GetLast3Blog()
		{
			return _blogDal.GetListAll().Take(3).ToList();
		}
		public List<Blog> GetBlogById(int id)
		{
			return _blogDal.GetListAll(x=> x.BlogID == id);
		}

        public List<Blog> GetBlogListByWriter(int id)
        {
            return _blogDal.GetListAll(x => x.BlogID == id); 
        }

        public void AddT(Blog t)
        {
            _blogDal.Insert(t);
        }

        public void DeleteT(Blog t)
        {
            _blogDal.Delete(t);
        }

        public void UpdateT(Blog t)
        {
           _blogDal.Update(t);
        }
    }
}
