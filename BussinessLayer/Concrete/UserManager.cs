using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class UserManager : IUserService
		
	{
		IUserDal _userDal;

		public UserManager(IUserDal userDal)
		{
			_userDal = userDal;
		}

		//public void AddT(AppUser t)
		//{
		//	_userDal.Insert(t);
		//}

		//public void DeleteT(AppUser t)
		//{
		//	_userDal.Delete(t);
		//}

		//public List<AppUser> GetList()
		//{
		//	return _userDal.GetListAll();
		//}

		//public AppUser TGetById(int id)
		//{
		//	return _userDal.GetById(id);
		//}

		//public void UpdateT(AppUser t)
		//{
		//	_userDal.Update(t);
		//}
	}
}
