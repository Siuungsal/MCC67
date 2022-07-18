using MCC67.Context;
using MCC67.Models;
using MCC67.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MCC67.Repositories.Data
{
	public class AccountRepository
	{

		MyContext myContext;
		public AccountRepository(MyContext myContext)
		{
			this.myContext = myContext;
		}

		//public object Login(string email, string password)
		public Login Post(string email, string password)
		{
			/*var role = myContext.Role_User.ToList();
			var name = myContext.Role_User.Where(x => x.user.Email == role_User.user.Email).SingleOrDefault();
			var pass = myContext.Role_User.Where(x => x.user.Password == role_User.user.Password).SingleOrDefault();
			if (name == null && pass == null)
			{
				return role;
			}*/

			var data = myContext.Role_User.
				Include(x => x.user).
				Include(x => x.user.employee).
				Include(x => x.role).
				Where(x => x.user.Email.Equals(email) && x.user.Password.Equals(password)).
				//SingleOrDefault();
				ToList();

			/*Login login = new Login();
			login.Id = data.user.Id;
			login.Name = data.user.employee.Name;
            login.Role = myContext.Role.ToList();*/

			Login login = new Login();
			login.Id = data.FirstOrDefault().user.Id;
			login.Email = data.FirstOrDefault().user.Email;
			login.Name = data.FirstOrDefault().user.employee.Name;

            foreach (var item in data)
            {
				login.Role.Add(item.role);
            }

			/*foreach (var rol in data.user.role_Users)
			{
				login.Role.Add(rol);
			}*/

			/*var result =
				from d in data
				group d by d.user.Id into Group
				let row = Group.First()
				select new
				{
					Id = Group.Key,
					Name = row.user.employee.Name,
					Role = Group.Select(r => r.role.Name)
				};

			List<object> results = new List<object>();

			foreach(var res in result)
            {
				results.Add(res);
            }*/

			return login;
		}

		public int Register(User user)
		{
			myContext.User.Add(user);
			int result = myContext.SaveChanges();
			return result;
		}

		public int ChangePassword(User user)
		{
			myContext.Entry(user.Password).State = EntityState.Modified;
			var result = myContext.SaveChanges();
			return result;
		}

		public void ForgotPassword()
		{

		}

		public int Logout(User user)
		{
			var role = myContext.Role.ToList();
			var name = myContext.User.Where(x => x.Email == user.Email).SingleOrDefault();
			var pass = myContext.User.Where(x => x.Password == user.Password).SingleOrDefault();
			if (name == null && pass == null)
			{
				return 0;
			}
			return 1;
		}
	}
}
