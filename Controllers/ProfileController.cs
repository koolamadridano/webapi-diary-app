using System;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using System.Collections.Generic;
using SharpDevelopWebApi.Models;

namespace SharpDevelopWebApi.Controllers
{
	public class ProfileController : ApiController
	{
		readonly SDWebApiDbContext _db = new SDWebApiDbContext();
		
	    [HttpPost]
		[Route("api/profile/create")]		
	    public IHttpActionResult Create(Profile profile)
	    {
	    	_db.Profiles.Add(profile);
	        _db.SaveChanges();
	        return Ok(profile);
	    }
	    
	    [HttpGet]
		[Route("api/profile/all")]		
        public IHttpActionResult GetAll(string keyword = "")
        {
            keyword = keyword.Trim();
            var profiles = new List<Profile>();
            if(!string.IsNullOrEmpty(keyword))
            {
               profiles = _db.Profiles
               	.Where(x => x.FirstName.Contains(keyword))
                    .ToList();
            }
            profiles = _db.Profiles.ToList();
            return Ok(profiles);
        }
        
       	[HttpGet]
    	[Route("api/profile/find/{Id}")]		
        public IHttpActionResult Get(int Id)
        {       
            var profile = _db.Profiles.Find(Id);
            if (profile != null)
                return Ok(profile);
            else
                return BadRequest("Profile is invalid or not found");
        }
		[HttpGet]
    	[Route("api/profile/findBySpecialId/{Id}")]		
        public IHttpActionResult GetBySpecialId(int Id)
        {       
        	var profile = _db.Profiles.Where(x => x.specialId == Id).Take(1);
            if (profile != null)
                return Ok(profile);
            else
                return BadRequest("Special Id is invalid or not found");
        }
        [HttpPut]
        [Route("api/profile/update")]		
        public IHttpActionResult Update(Profile profileEdit)
        {
            var profile = _db.Profiles.Find(profileEdit.Id);
            if (profile != null)
            {	
            	profile.FirstName = profileEdit.FirstName;
            	profile.LastName = profileEdit.LastName;
            	profile.Gender = profileEdit.Gender;
            	profile.Media = profileEdit.Media;
            	profile.BirthDate = profileEdit.BirthDate;
            	profile.Address = profileEdit.Address;
            	profile.ShortDescription = profileEdit.ShortDescription;
            	
                _db.Entry(profile).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return Ok(profile);
            }
            else
                return BadRequest("Profile id is invalid or not found");
        }
        
        [HttpDelete]
        [Route("api/profile/remove/{Id}")]		
        public IHttpActionResult Delete(int Id)
        {
            var profile = _db.Profiles.Find(Id);
            if (profile != null)
            {
                _db.Profiles.Remove(profile);
                _db.SaveChanges();
                return Ok("Profile removed successfully!");
            }
            else
                return BadRequest("Profile id is invalid or not found");
        }
        
	}
}