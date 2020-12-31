using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Mvc;

using SharpDevelopWebApi.Models;

namespace SharpDevelopWebApi.Controllers
{

	public class DiaryController : ApiController
	{
		readonly SDWebApiDbContext _db = new SDWebApiDbContext();

	    [HttpPost]
		[Route("api/diary/create")]		
        public IHttpActionResult Create(Diary diary)
        {
        	_db.Diaries.Add(diary);
            _db.SaveChanges();
            return Ok(diary);
        }
        
	    [HttpGet]
		[Route("api/diary/all")]		
        public IHttpActionResult GetAll(string keyword = "")
        {
            keyword = keyword.Trim();
            var diaries = new List<Diary>();
            if(!string.IsNullOrEmpty(keyword))
            {
               diaries = _db.Diaries
               	.Where(x => x.Content.Contains(keyword))
                    .ToList();
            }
            diaries = _db.Diaries.ToList();
            return Ok(diaries);
        }
       	[HttpGet]
    	[Route("api/diary/find/{Id}")]		
        public IHttpActionResult Get(int Id)
        {       
            var diary = _db.Diaries.Find(Id);
            if (diary != null)
                return Ok(diary);
            else
                return BadRequest("diary Id is invalid or not found");
        }
        [HttpGet]
    	[Route("api/diary/findBySpecialId/{Id}")]		
        public IHttpActionResult GetBySpecialId(int Id)
        {       
        	var diary = _db.Diaries.Where(x => x.specialId == Id);
            if (diary != null)
                return Ok(diary);
            else
                return BadRequest("Special Id is invalid or not found");
        }
        [HttpDelete]
        [Route("api/diary/remove/{Id}")]		
        public IHttpActionResult Delete(int Id)
        {
            var diary = _db.Diaries.Find(Id);
            if (diary != null)
            {
                _db.Diaries.Remove(diary);
                _db.SaveChanges();
                return Ok("Diary removed successfully!");
            }
            else
                return BadRequest("Diary id is invalid or not found");
        }
        
        [HttpPut]
        [Route("api/diary/update")]		
        public IHttpActionResult Update(Diary diaryEdit)
        {
            var diary = _db.Diaries.Find(diaryEdit.Id);
            if (diary != null)
            {	
            	diary.Content = diaryEdit.Content;
                _db.Entry(diary).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();

                return Ok(diary);
            }
            else
                return BadRequest("Diary id is invalid or not found");
        }
	}
}