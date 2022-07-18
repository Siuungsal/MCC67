using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Produk
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Kolom Nama harus diisi")]
        [StringLength(30, ErrorMessage = "Nama tidak boleh melebihi 30 karakter")]
        public string Name { get; set; }

        public Supplier suplier { get; set; }

        [ForeignKey("suplier")]
        public int SuplierId { get; set; }
    }
}
