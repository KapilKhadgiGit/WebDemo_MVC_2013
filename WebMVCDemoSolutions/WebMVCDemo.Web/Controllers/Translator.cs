using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebMVCDemo.Web.Controllers
{
    public class Translator
    {
        public static DAL.Task TaskBalToTaskDal(Models.TaskDetails taskdetails)
        {
            DAL.Task task = new DAL.Task();

            task.Title = taskdetails.Title;
            task.Description = taskdetails.Description;
            task.DueDate = taskdetails.DueDate;

            return task;
        }
    }
}
