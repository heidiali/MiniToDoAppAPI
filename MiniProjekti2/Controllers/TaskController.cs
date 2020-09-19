using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MiniProjekti2.Models;

namespace MiniProjekti2.Controllers
{
    public class TaskController : ApiController
    {
        private ToDoDB db = new ToDoDB();


        // GET: api/Task
        //public IEnumerable<TaskInfo> Get()
        //{
        //    List<TaskInfo> kaikki = new List<TaskInfo>();
        //    kaikki = db.TaskInfoes.ToList();
        //    return kaikki;

        //    //  Voi tehdä myös. Muista public...< > pitää olla <Tuote>
        //    //  return db.Tuote.ToList();
        //}


       // GET: api/Task
       public IQueryable<TaskInfo> GetTaskInfoes()
       {
           return db.TaskInfoes;
       }

        // GET: api/Task/5
        [ResponseType(typeof(TaskInfo))]
        public IHttpActionResult GetTaskInfo(int id)
        {
            TaskInfo taskInfo = db.TaskInfoes.Find(id);
            if (taskInfo == null)
            {
                return NotFound();
            }

            return Ok(taskInfo);
        }
        

        // PUT: api/Task/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTaskInfo(int id, TaskInfo taskInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != taskInfo.TaskID)
            {
                return BadRequest();
            }

            db.Entry(taskInfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Task
        [ResponseType(typeof(TaskInfo))]
        public IHttpActionResult PostTaskInfo(TaskInfo taskInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TaskInfoes.Add(taskInfo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = taskInfo.TaskID }, taskInfo);
        }

        // DELETE: api/Task/5
        [ResponseType(typeof(TaskInfo))]
        public IHttpActionResult DeleteTaskInfo(int id)
        {
            TaskInfo taskInfo = db.TaskInfoes.Find(id);
            if (taskInfo == null)
            {
                return NotFound();
            }

            db.TaskInfoes.Remove(taskInfo);
            db.SaveChanges();

            return Ok(taskInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TaskInfoExists(int id)
        {
            return db.TaskInfoes.Count(e => e.TaskID == id) > 0;
        }
    }
}