using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMVCDemo.Web.Models
{
    public class TaskDetails
    {
        public int TaskId { get; set; }
        [Required(ErrorMessage="Title can not be blank.")]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
    }
}