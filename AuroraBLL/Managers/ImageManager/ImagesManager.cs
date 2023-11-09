using AuroraBLL.Dtos.ImageDtos;
using AuroraDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraBLL.Managers.ImageManager
{
    public class ImagesManager : IImagesManager
    {
        #region Inject
        private readonly IUnitOfWork _IUnitOfWork;
        
        public ImagesManager(IUnitOfWork unitOfWork) 
        {
           _IUnitOfWork = unitOfWork;

        }

        public IUnitOfWork? UnitOfWork { get; }
        #endregion

        #region Read By Product Id

        public IEnumerable<ImagesReadByProductIdDto> GetImagesByProductId(int ProductId)
        {
            IEnumerable<Image>? imagesfromDb = _IUnitOfWork.ImageRepo.GetImagesByProductId(ProductId);
            if (imagesfromDb == null)
            {
                return Enumerable.Empty<ImagesReadByProductIdDto>();
            }
            return imagesfromDb.Select(I => new ImagesReadByProductIdDto
            {                
                ImageUrl = I.ImageUrl
            });
        }
        #endregion

        #region Add
        public bool Add(ImageAddDto imageFromRequest)
        {
            Product? productcheck = _IUnitOfWork.ProductRepo.GetById(imageFromRequest.ProductId);

            Image? image = new Image
            {
                ImageUrl = imageFromRequest.ImageUrl,
                ProductId = imageFromRequest.ProductId,
            };

            if (productcheck == null) 
            {
                return false;
            }
            
            _IUnitOfWork.ImageRepo.Add(image);
            _IUnitOfWork.SaveChanges();
            return true;
        }
        #endregion

        #region Delete
        public bool Delete(ImageDeleteDto image)
        {
            Image? imagetobedeleted = _IUnitOfWork.ImageRepo.GetById(image.Id);
            if (imagetobedeleted == null) 
            {
                return false;
            }
            _IUnitOfWork.ImageRepo.Delete(imagetobedeleted);
            _IUnitOfWork.SaveChanges();
            return true;
        }
        #endregion
        
        #region Update

        public bool Update(ImageUpdateDto image)
        {
            Image? imagetobeupdated = _IUnitOfWork.ImageRepo.GetById(image.Id);
            if(imagetobeupdated == null)
            {

                return false;
            }
            imagetobeupdated.ProductId = image.ProductId;
            imagetobeupdated.ImageUrl = image.ImageUrl;

            _IUnitOfWork.ImageRepo.Update(imagetobeupdated);
            _IUnitOfWork.SaveChanges();
            return true;
        }
        #endregion  
    }
}
