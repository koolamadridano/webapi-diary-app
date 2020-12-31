using System;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;

using SharpDevelopWebApi.Models;

namespace SharpDevelopWebApi.Controllers
{
	/// <summary>
	/// Description of SongController.
	/// </summary>
	public class SongController : ApiController
	{
		readonly SDWebApiDbContext _db = new SDWebApiDbContext();

	    [HttpPost]
		[Route("api/song/upload")]		
        public IHttpActionResult Create(Song song)
        {
        	_db.Songs.Add(song);
            _db.SaveChanges();
            return Ok(song);
        }
       [HttpGet]
    	[Route("api/song/findBySpecialId/{Id}")]		
        public IHttpActionResult GetBySpecialId(int Id)
        {       
        	var song = _db.Songs.Where(x => x.specialId == Id);
            if (song != null)
                return Ok(song);
            else
                return BadRequest("Special Id is invalid or not found");
        }
	}
}