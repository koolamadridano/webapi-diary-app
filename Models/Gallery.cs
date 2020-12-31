/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 27/12/2020
 * Time: 8:30 pm
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SharpDevelopWebApi.Models
{
	public class Gallery
	{
		public int Id { get; set; }
		public int specialId { get; set; }
		public string PostedBy { get; set; }
		public string PhotoUrl { get; set; }
		public string DatePosted { get; set; }
	}
}
