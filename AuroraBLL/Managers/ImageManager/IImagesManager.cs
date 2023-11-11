using AuroraBLL.Dtos.ImageDtos;
using AuroraDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraBLL.Managers.ImageManager
{
    public interface IImagesManager
    {
        IEnumerable<ImagesReadByProductIdDto> GetImagesByProductId(int ProductId);
        bool Add(ImageAddDto image);
        bool Update(ImageUpdateDto image);
        bool Delete(int iamgeid);
    }
}
