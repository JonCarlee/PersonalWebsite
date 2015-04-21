using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PersonalWebsite.Models;

namespace PersonalWebsite.Controllers
{
    [Authorize(Roles = "Admin,Moderator")]
    public class CommentController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Comment
        public ActionResult Index()
        {
            return View();
        }
        //GET
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);

            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "Created,Id,Updated,AuthorId,Body,PostId")] Comment comment)
        {
            //If user didn't mess up
            if (ModelState.IsValid)
            {
                //Find the post that this comment is a part of based on the PostId tag
                Post post = db.Posts.Find(comment.PostId);
                //Put comment on the graph
                db.Comments.Attach(comment);
                //Change the updated tag time to current time
                comment.Updated = System.DateTimeOffset.Now;
                //Let the Database know the data has changed
                db.Entry(comment).State = EntityState.Modified;
                //Save the Changes
                db.SaveChanges();
                //Go back to the Details page, which is handled by the Posts controller, and find the page based on the post slug
                return RedirectToAction("Details", "Posts", new { slug = post.Slug });
            }
            return View(comment);
        }


    }
}