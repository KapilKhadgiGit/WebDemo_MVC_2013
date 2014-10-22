using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebMVCDemo.Web.Controllers
{
    public class ParallelProgramingController : Controller
    {
        // GET: ParallelPrograming
        public ActionResult Index()
        {
            return View();
        }


        public async static Task<long?> GetPageLength()
        {
            HttpClient client = new HttpClient();
            var httpMessage = await client.GetAsync("http://apress.com");
            return httpMessage.Content.Headers.ContentLength;
        } 
    }
}