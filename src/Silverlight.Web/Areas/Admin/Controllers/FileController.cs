using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Silverlight.ApplicationCore.Interfaces;

namespace Silverlight.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize]
    public class FileController : ControllerBase
    {
        private readonly IAppLogger<FileController> _appLogger;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FileController(IAppLogger<FileController> appLogger, IWebHostEnvironment webHostEnvironment)
        {
            _appLogger = appLogger;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Upload(IFormFile file, string path)
        {
            try
            {
                if (file != null)
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, path);

                    string filePath = Path.Combine(uploadsFolder, file.FileName);

                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    return new ObjectResult(new { status = "success", filePath });
                }
            }
            catch (Exception ex)
            {
                _appLogger.LogError(ex.Message);
            }

            return new ObjectResult(new { status = "fail" });
        }
    }
}
