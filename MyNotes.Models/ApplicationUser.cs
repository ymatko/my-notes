using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNotes.Models
{
	public class ApplicationUser : IdentityUser
	{
		[NotMapped]
		public string Role { get; set; }
		[NotMapped]
		public int QuantityOfSheet { get; set; }
	}
}
