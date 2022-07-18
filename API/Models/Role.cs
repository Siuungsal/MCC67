using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Kolom Role harus diisi")]
        [StringLength(30, ErrorMessage = "Role tidak boleh melebihi 30 karakter")]
        public string Name { get; set; }

        //public IEnumerable<Role_User> role_Users { get; set; }
    }
}
