using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectApp.Models
{
    public class Project
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Client { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public bool Visibility { get; set; }
        public Comment Comments { get; set; }
        public List<Comment> CommentList { get; set; }

        public Project()
        {
            this.CommentList = new List<Comment>();
        }
    }
}