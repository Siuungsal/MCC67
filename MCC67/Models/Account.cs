using System.ComponentModel.DataAnnotations;

namespace MCC67.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Kolom Nama harus diisi")]
        [StringLength(30, ErrorMessage = "Nama tidak boleh melebihi 30 karakter")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Kolom Password harus diisi")]
        public string Password { get; set; }
    }
}
