using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVCDemo.Web.Models
{
    public class TaskDetails
    {
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string TaskDescription { get; set; }
        public DateTime? DueDate { get; set; }
    }
}