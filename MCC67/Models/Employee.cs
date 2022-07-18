using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCC67.Models
{
	public class Employee
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Kolom Nama harus diisi")]
		[StringLength(30, ErrorMessage = "Nama tidak boleh melebihi 30 karakter")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Kolom Alamat harus diisi")]
		[StringLength(100, ErrorMessage = "Alamat tidak boleh melebihi 100 karakter")]
		public string Alamat { get; set; }

		[Required(ErrorMessage = "Kolom Jabatan harus diisi")]
		[StringLength(30, ErrorMessage = "Jabatan tidak boleh melebihi 30 karakter")]
		public string Jabatan { get; set; }

		[Required(ErrorMessage = "Kolom Hobi harus diisi")]
		[StringLength(30, ErrorMessage = "Hobi tidak boleh melebihi 30 karakter")]
		public string Hobi { get; set; }

		/*public Role role { get; set; }

		[ForeignKey("role")]
		public int RoleId { get; set; }*/
	}
}
