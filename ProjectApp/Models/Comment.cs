using System.ComponentModel.DataAnnotations;

namespace ProjectApp.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public int ProjectId { get; set; }
        [Required]
        public string UserId { get; set; }
        public string UserName { get; set; }
        [Required]
        public string Text { get; set; }
    }
}