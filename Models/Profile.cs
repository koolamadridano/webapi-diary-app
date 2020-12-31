using System;

namespace SharpDevelopWebApi.Models
{
	public class Media 
	{
		public string Music { get; set; }
		public string Video { get; set; }
	}
	public class Address
	{
		public string Country { get; set; }
		public string City { get; set; }
	}
	
	public class Profile
	{
		public int Id { get; set; }
		public int specialId { get; set; }
		public string PhotoUrl { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Gender { get; set; }
		public string ShortDescription { get; set; }
		public string Course { get; set; }
		
		public Address Address { get; set; }
		public Media Media { get; set; }
		public string BirthDate { get; set; }
	}
}
