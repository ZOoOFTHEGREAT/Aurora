using AuroraBLL.Dtos.CategoryDtos;
using AuroraBLL.Dtos.ImageDtos;
using AuroraBLL.Dtos.PaymentDetailDtos;
using AuroraBLL.Managers.CategoryManager;
using AuroraBLL.Managers.ImageManager;
using AuroraBLL.Managers.PaymentDetailManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuroraAPI.Controllers.ImageController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        #region Inject 

        private readonly IImagesManager imagemanager;

        public ImageController(IImagesManager imagesManager)
        {
            this.imagemanager = imagesManager;
        }
        #endregion

        #region Add Image
        [HttpPost]
        [Route("AddImage")]

        public ActionResult Add(ImageAddDto ImageToAdd)
        {
            bool isAdded = imagemanager.Add(ImageToAdd);
            return isAdded ? Accepted() : BadRequest();
        }
        #endregion

        #region Update Image
        [HttpPut]
        [Route("UpdateImage")]

        public ActionResult Edit(ImageUpdateDto imageToUpdate)
        {
            bool isEdited = imagemanager.Update(imageToUpdate);

            return isEdited ? Accepted() : BadRequest();
        }
        #endregion

        #region Delete Image
        [HttpDelete]
        [Route("{ImageToDeleteId}")]

        public ActionResult Delete(int imageToDeleteId)
        {
            bool isDeleted = imagemanager.Delete(imageToDeleteId);

            return isDeleted ? Accepted() : BadRequest();
        }
        #endregion

        #region Get Image By Product ID
        [HttpGet]
        [Route("Byproduct/{productId}")]

        public ActionResult<IEnumerable<ImagesReadByProductIdDto>> GetAllImagesByProductId(int productId)
        {
            IEnumerable<ImagesReadByProductIdDto>? productimages = imagemanager.GetImagesByProductId(productId);
            if (productimages == null) { return NotFound(); }
            return Ok(productimages);

        }
        #endregion
    }
}
