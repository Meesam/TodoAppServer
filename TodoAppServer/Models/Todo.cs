using System.ComponentModel.DataAnnotations;

namespace TodoAppServer.Models
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } =string.Empty;

        [Required]
        public bool IsCompleted { get; set; } = false;

        public bool IsDeleted { get; set; } = false;

        [Required]
        public DateTime CreatedDate { get; set; }

        public DateTime LastModifiedDate { get; set; }
    }
}
