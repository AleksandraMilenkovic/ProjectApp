using ProjectApp.Models;
using System.Collections.Generic;

namespace ProjectApp.ViewModels
{
    public class ProjectsViewModel
    {
        public List<Project> ProjectList { get; set; }
        public bool VisibleComToUser { get; set; }
    }
}