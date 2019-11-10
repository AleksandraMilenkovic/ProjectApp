using Microsoft.AspNet.Identity;
using ProjectApp.Models;
using ProjectApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ProjectApp.Controllers
{
    public class ProjectsController : Controller
    {
        private ApplicationDbContext _context;
        public ProjectsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: ProjectsPage
        public ActionResult Projects()
        {

            ProjectsViewModel ViewData = new ProjectsViewModel();

            ViewData.ProjectList = _context.Projects.ToList();
            var userId = User.Identity.GetUserId();
            var SingleUser = _context.Users.SingleOrDefault(u => u.Id == userId);

            var SelectedRole = SingleUser.Roles.SingleOrDefault().RoleId;

            var role = _context.Roles.SingleOrDefault(r => r.Id == SelectedRole);
            if (!(role.Name == "GUEST"))
            {
                for (int i = 0; i < ViewData.ProjectList.Count; i++)
                {
                    var PrId = ViewData.ProjectList[i].Id;
                    List<Comment> lista = _context.Comments.Where(x => x.ProjectId == PrId).ToList();
                    foreach (var comment in lista)
                    {
                        ViewData.ProjectList[i].CommentList.Add(comment);
                    }
                }
            }


            return View(ViewData);
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN, EMPLOYEE")]
        public ActionResult SaveComment(string text, int ProjectId)
        {
            Comment CommentFDB = new Comment();
            CommentFDB.UserName = User.Identity.GetUserName();
            CommentFDB.UserId = User.Identity.GetUserId();
            CommentFDB.Text = text;
            CommentFDB.ProjectId = ProjectId;

            _context.Comments.Add(CommentFDB);


            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return RedirectToAction("Projects", "Projects");
        }
    }
}