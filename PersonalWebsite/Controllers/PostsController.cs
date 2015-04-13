using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PersonalWebsite.Models;
using PagedList;
using PagedList.Mvc;

namespace PersonalWebsite.Controllers
{
    [Authorize(Roles="Admin")]
    public class PostsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [AllowAnonymous]
        public ActionResult Index(int? page)
        {
            var posts = db.Posts.ToList();
            var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
            var onePageOfPosts = posts.OrderByDescending(p => p.Created).ToPagedList(pageNumber, 3); // will only contain 3 products max because of the pageSize

            ViewBag.OnePageOfPosts = onePageOfPosts;
            return View();
        }

        public ActionResult ManageUser()
        {
            var users = db.Users.ToList();
            ViewBag.users = users;
            return View();
        }

        public ActionResult Menu()
        {
            return View();
        }
        // GET: Posts
        public ActionResult Admin()
        {
            return View(db.Posts.ToList());
        }

        // GET: Posts/Details/5
        [AllowAnonymous]
        public ActionResult Details(string Slug)
        {
            if (String.IsNullOrWhiteSpace(Slug))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.FirstOrDefault(p=>p.Slug == Slug);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Created,Body,Title,Published, MediaURL")] Post post, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                var Slug = StringUtilities.URLFriendly(post.Title);
                if (String.IsNullOrWhiteSpace(Slug))
                {
                    ModelState.AddModelError("Title", "Invalid title.");
                    return View(post);
                }
                if (db.Posts.Any(p => p.Slug == Slug))
                {
                    ModelState.AddModelError("Title", "The title must be unique.");
                    return View(post);
                }
                else
                {
                    post.Created = System.DateTimeOffset.Now;
                    post.Slug = Slug;

                    db.Posts.Add(post);
                    db.SaveChanges();
                    return RedirectToAction("Admin");
                }
            }
            return View(post);
        }


        // GET: Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Updated,Title,Body,MediaURL")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Posts.Attach(post);
                post.Updated = System.DateTimeOffset.Now;

                db.Entry(post).Property(p => p.Body).IsModified = true;
                db.Entry(post).Property(p => p.MediaURL).IsModified = true;
                db.Entry(post).Property(p => p.Updated).IsModified = true;
                db.SaveChanges();
                
            }
            return RedirectToAction("Admin");
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Posts/Delete/5
        public ActionResult DeleteUser(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser user = User.Identity.Name;
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("DeleteUser")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
