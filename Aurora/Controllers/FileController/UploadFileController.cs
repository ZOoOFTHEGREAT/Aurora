using AuroraBLL.Dtos.FileDto;
using AuroraBLL.Managers.ImageManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuroraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadFileController : ControllerBase
    {
        [HttpPost]
        public ActionResult<FileDto> Upload(IFormFile file)
        {
            #region Check Extension
            var extension = Path.GetExtension(file.FileName);

            var allowedExtensions = new string[]
            {
                ".jpg",".png",".svg"
            };

            bool isExtensionAllowed = allowedExtensions
                .Contains(extension, StringComparer.InvariantCultureIgnoreCase);
            if (!isExtensionAllowed)
            {
                return BadRequest();
            }
            #endregion

            #region Check For Length
            bool isSizeAllowed = file.Length is > 0 and < 5_000_000;
            if (!isSizeAllowed)
                return BadRequest();
            #endregion

            #region Storing Image
            var newFileName = $"{Guid.NewGuid()}{extension}";
            var imagesPath =Path.Combine(Environment.CurrentDirectory,"Images");
            var fullFileName =Path.Combine(imagesPath,newFileName);

            using var stream = new FileStream(fullFileName, FileMode.Create);
            file.CopyTo(stream);
            #endregion

            #region Generate URL
            var url = $"{Request.Scheme}://{Request.Host}/Images/{newFileName}";
            return new FileDto
            {
                Url = url,
                IsSuccess = true
            };
            #endregion
        }

    }
}
