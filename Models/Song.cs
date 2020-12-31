/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 30/12/2020
 * Time: 11:10 pm
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SharpDevelopWebApi.Models
{
	/// <summary>
	/// Description of Song.
	/// </summary>
	public class Song
	{
		public int Id { get; set; }
		public int specialId { get; set; }
		public string PhotoUrl { get; set; }
		public string PostedBy { get; set; }
	}
}
