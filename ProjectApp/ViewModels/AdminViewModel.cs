using ProjectApp.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ProjectApp.ViewModels
{
    public class AdminViewModel
    {
        public Project SingleProject { get; set; }
        public ApplicationUser SingleUser { get; set; }
        public List<Project> ProjectList { get; set; }
        public List<ApplicationUser> UserList { get; set; }
        public string SelectedRole { get; set; }
        public IEnumerable<SelectListItem> RolesList { get; set; }
    }
}