using System;
using System.ComponentModel.DataAnnotations;

namespace TaskList.Shared
{
    public class Todo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public String Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required.")]
        public String Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Due Date is required.")]
        public DateTime DueDate { get; set; }

        [Required(ErrorMessage = "Priority is required.")]
        public String Priority { get; set; } = string.Empty;

        [Required(ErrorMessage = "Status is required.")]
        public String Status { get; set; } = string.Empty;

    }
}

