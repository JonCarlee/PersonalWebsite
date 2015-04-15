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
        public ActionResult Edit([Bind(Include = "Created,Id,Updated,AuthorId,Body,PostId")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                Post post = db.Posts.Find(comment.PostId);
                db.Comments.Attach(comment);
                comment.Updated = System.DateTimeOffset.Now;
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", "Posts", new { slug = post.Slug });
            }
            return View(comment);
        }


    }
}