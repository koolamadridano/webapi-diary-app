using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

using SharpDevelopWebApi.Models;

namespace SharpDevelopWebApi.Controllers
{
	public class GalleryController : ApiController
	{
		readonly SDWebApiDbContext _db = new SDWebApiDbContext();
		

	    [HttpPost]
		[Route("api/gallery/upload")]		
        public IHttpActionResult Create(Gallery gallery)
        {
        	_db.Galleries.Add(gallery);
            _db.SaveChanges();
            return Ok(gallery);
        }
        
        [HttpGet]
		[Route("api/gallery/all")]		
        public IHttpActionResult GetAll(string keyword = "")
        {
            keyword = keyword.Trim();
            var gallery = new List<Gallery>();
            if(!string.IsNullOrEmpty(keyword))
            {
               gallery = _db.Galleries
               	.Where(x => x.PhotoUrl.Contains(keyword))
                    .ToList();
            }
            gallery = _db.Galleries.ToList();
            return Ok(gallery);
        }
        [HttpGet]
    	[Route("api/gallery/findBySpecialId/{Id}")]		
        public IHttpActionResult GetBySpecialId(int Id)
        {       
        	var gallery = _db.Galleries.Where(x => x.specialId == Id);
            if (gallery != null)
                return Ok(gallery);
            else
                return BadRequest("Special Id is invalid or not found");
        }
        [HttpDelete]
        [Route("api/gallery/remove/{Id}")]		
        public IHttpActionResult Delete(int Id)
        {
            var gallery = _db.Galleries.Find(Id);
            if (gallery != null)
            {
                _db.Galleries.Remove(gallery);
                _db.SaveChanges();
                return Ok("Img removed successfully!");
            }
            else
                return BadRequest("Img id is invalid or not found");
        }
	}
}