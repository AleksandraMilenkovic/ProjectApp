using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ProjectApp.Models;
using ProjectApp.ViewModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace ProjectApp.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext _context;
        public AdminController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: AdminPage
        //[Authorize(Roles = "ADMIN")]
        public ActionResult Admin()
        {
            AdminViewModel ViewData = new AdminViewModel();
            ViewData.ProjectList = _context.Projects.ToList();
            ViewData.UserList = _context.Users.ToList();
            return View(ViewData);
        }

        //Edit/Add project
        //[Authorize(Roles = "ADMIN")]
        public ActionResult ModifyProject(int? Id)
        {
            Project ProjectData = new Project();
            if (Id > 0)
            {
                ProjectData = _context.Projects.SingleOrDefault(p => p.Id == Id);
            }
            return View(ProjectData);
        }
        [HttpPost]
        //[Authorize(Roles = "ADMIN")]
        public ActionResult ModifyP(Project ModelData)
        {
            if (ModelData.Id > 0)
            {
                Project ProjectInDB = _context.Projects.SingleOrDefault(p => p.Id == ModelData.Id);
                ProjectInDB.Name = ModelData.Name;
                ProjectInDB.Client = ModelData.Client;
                ProjectInDB.Location = ModelData.Location;
                ProjectInDB.Description = ModelData.Description;
                ProjectInDB.Visibility = ModelData.Visibility;
            }
            else
            {
                _context.Projects.Add(ModelData);
            }

            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return RedirectToAction("Admin", "Admin");
        }
        //Edit/Add user
        //[Authorize(Roles = "ADMIN")]
        public ActionResult ModifyUser(string Id)
        {
            AdminViewModel ViewData = new AdminViewModel();
            ViewData.SingleUser = _context.Users.SingleOrDefault(u => u.Id == Id);

            ViewData.SelectedRole = ViewData.SingleUser.Roles.SingleOrDefault().RoleId;
            var RolesFDatabase = _context.Roles.ToList();

            var RolesListItems = new SelectList(RolesFDatabase.Select(item => new SelectListItem
            {
                Text = item.Name,
                Value = item.Id
            }).ToList(), "Value", "Text");

            ViewData.RolesList = RolesListItems;
            return View(ViewData);
        }
        [HttpPost]
        //[Authorize(Roles = "ADMIN")]
        public ActionResult ModifyU(AdminViewModel ModelData)
        {
            if (ModelState.IsValid)
            {
                var oldUser = _context.Users.SingleOrDefault(u => u.Id == ModelData.SingleUser.Id);
                oldUser.UserName = ModelData.SingleUser.UserName;
                var oldRoleId = oldUser.Roles.SingleOrDefault().RoleId;
                var oldRoleName = _context.Roles.SingleOrDefault(r => r.Id == oldRoleId).Name;
                var newRoleName = _context.Roles.SingleOrDefault(r => r.Id == ModelData.SelectedRole).Name;

                if (oldRoleName != newRoleName)
                {
                    var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));

                    UserManager.RemoveFromRole(ModelData.SingleUser.Id, oldRoleName);
                    UserManager.AddToRole(ModelData.SingleUser.Id, newRoleName);
                }

                _context.Entry(oldUser).State = EntityState.Modified;

                try
                {
                    _context.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

            }
            return RedirectToAction("Admin", "Admin");
        }
    }
}