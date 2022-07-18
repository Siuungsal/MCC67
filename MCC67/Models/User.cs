using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCC67.Models
{
	public class User
	{
        public Employee employee { get; set; }
        [Key]
        [ForeignKey("employee")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Kolom Email harus diisi")]
        [StringLength(50, ErrorMessage = "Email tidak boleh melebihi 50 karakter")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Kolom Password harus diisi")]
        public string Password { get; set; }

        //public IEnumerable<Role_User> role_Users { get; set; }
    }

}

