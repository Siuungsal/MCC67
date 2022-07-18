using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Kolom Nama harus diisi")]
        [StringLength(30, ErrorMessage = "Nama tidak boleh melebihi 30 karakter")]
        public string Name { get; set; }
    }
}
