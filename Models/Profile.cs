using System;

namespace SharpDevelopWebApi.Models
{
	public class Profile
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Gender { get; set; }
		public string ShortDescription { get; set; }
		
		public DateTime? BirthDate { get; set; }
	}
}
