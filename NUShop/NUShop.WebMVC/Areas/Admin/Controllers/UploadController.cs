using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace NUShop.WebMVC.Areas.Admin.Controllers
{
    public class UploadController : BaseController
    {
        #region Injections

        private readonly IHostingEnvironment _env;

        public UploadController(IHostingEnvironment env)
        {
            _env = env;
        }

        #endregion Injections

        [HttpPost]
        public IActionResult UploadImage()
        {
            var date = DateTime.Now;
            var files = Request.Form.Files;
            if (files.Count == 0)
            {
                return new BadRequestObjectResult(files);
            }

            var file = files[0];
            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

            var imageFolder = $@"\uploaded\images\{date.ToString("yyyyMMdd")}";
            var folder = _env.WebRootPath + imageFolder;

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            var filePath = Path.Combine(folder, fileName);
            using (FileStream fileStream = System.IO.File.Create(filePath))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }

            return new OkObjectResult(Path.Combine(imageFolder, fileName).Replace(@"\", @"/"));
        }


        [HttpPost]
        public async Task UploadImageCKEditor(IList<IFormFile> upload, string CKEditorFuncNum, string CKEditor, string langCode)
        {
            var date = DateTime.Now;
            if (upload.Count == 0)
            {
                await HttpContext.Response.WriteAsync("Please, add image!");
            }
            else
            {
                var file = upload[0];
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var imageFolder = $@"\uploaded\images\{date.ToString("yyyyMMdd")}";
                var folder = _env.WebRootPath + imageFolder;

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                var filePath = Path.Combine(folder, fileName);
                using (FileStream fileStream = System.IO.File.Create(filePath))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                }
                await HttpContext.Response.WriteAsync("<script>window.parent.CKEDITOR.tools.callFunction(" + CKEditorFuncNum + ", '" + Path.Combine(imageFolder, fileName).Replace(@"\", @"/") + "');</script>");
            }
        }
    }
}