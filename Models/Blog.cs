using System;
using System.ComponentModel.DataAnnotations;

namespace Counselor.Models
{
    public class Blog
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Content { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Summary { get; set; }

        [StringLength(100)]
        public string? Author { get; set; }

        [Display(Name = "Published Date")]
        public DateTime PublishedDate { get; set; }

        [Display(Name = "Is Published")]
        public bool IsPublished { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
