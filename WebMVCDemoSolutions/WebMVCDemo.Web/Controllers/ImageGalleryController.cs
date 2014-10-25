using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using WebMVCDemo.Web.Models;

namespace WebMVCDemo.Web.Controllers
{
    public class ImageGalleryController : ApiController
    {
        public IEnumerable<ImageDetails> GetAllImages()
        {
            // HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, imageDetails);
            List<ImageDetails> imageList = new List<ImageDetails>();
            ImageDetails imageDetails;

            foreach (string filePath in Directory.GetFiles(ConfigurationManager.AppSettings["PhotoGalleryPath"]))
            {
                imageDetails = new ImageDetails();

                FileInfo imageFile = new FileInfo(filePath);
                imageDetails.Name = imageFile.Name;
                imageDetails.Title = imageFile.Name;

                imageList.Add(imageDetails);
            }

            return imageList;
        }

        //public IHttpActionResult GetProduct(int id)
        //{
        //    var images = imageDetails.FirstOrDefault((p) => p.Id == id);
        //    if (images == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(images);
        //}
    }
}
