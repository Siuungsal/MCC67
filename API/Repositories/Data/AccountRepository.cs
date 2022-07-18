using API.Context;
using API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace API.Repositories.Data
{
    public class AccountRepository
    {
        MyContext myContext;
        public AccountRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }

        public Login Post(string email, string password)
        {
            var data = myContext.Role_User.
                Include(x => x.user).
                Include(x => x.user.employee).
                Include(x => x.role).
                Where(x => x.user.Email.Equals(email) && x.user.Password.Equals(password)).
                ToList();

            Login login = new Login();
            login.Id = data.FirstOrDefault().user.Id;
            login.Email = data.FirstOrDefault().user.Email;
            login.Name = data.FirstOrDefault().user.employee.Name;

            foreach (var item in data)
            {
                login.Role.Add(item.role);
            }

            return login;
        }
    }
}