using API.Models;
using System.Collections.Generic;

namespace API.ViewModels
{
    public class Login
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        //public List<string> Role { get; set; }
        public List<Role> Role = new List<Role>();
    }
}
