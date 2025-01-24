using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bankcard.Models;

namespace Bankcard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileuploadController : ControllerBase
    {
        // POST: api/Fileupload
        [HttpPost]
        public ActionResult PostFileupload([FromForm]FileuploadModel std)
        {
            // Getting Image
            var image = std.Image;

            // Saving Image on Server
            if (image.Length > 0)
            {
                using (var fileStream = new FileStream(image.FileName, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }
            }

            return Ok(new { status = true, message = "Successfully" });
        }
    }
}
