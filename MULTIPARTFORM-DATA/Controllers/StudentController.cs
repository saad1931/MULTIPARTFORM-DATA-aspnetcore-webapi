using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MULTIPARTFORM_DATA.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MULTIPARTFORM_DATA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpPost]
        public ActionResult Student([FromForm] StudentModel std)
        {
            //Getting Name
            string name = std.Name;
            // Getting Image
            var image = std.Image;

            var filePath = Path.Combine("wwwroot/images", image.FileName);
            // Saving Image on www/root
            if (image.Length > 0)
            {
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }
            }
            

            return Ok(new { status = true, message = "Student Posted Successfully" });
        }
    }
}
