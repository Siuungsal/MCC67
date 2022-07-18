using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MCC67.Models
{
	public class Role_User
	{
		[Key]
		public int Id { get; set; }

		public User user { get; set; }
		[ForeignKey("user")]
		public int UserId { get; set; }

		public Role role { get; set; }
		[ForeignKey("role")]
		public int RoleId { get; set; }
	}
}
