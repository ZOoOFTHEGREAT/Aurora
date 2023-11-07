using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL.Repos;

public class ImageRepo : GenericRepo<Image>, IImageRepo
{
    #region Inject
    private readonly AppDbContext appDbContext;

    public ImageRepo(AppDbContext appDbContext) : base(appDbContext)
    {
        this.appDbContext = appDbContext;
    }
    #endregion

    #region Get Images By Product Id
    public List<Image>? GetImagesByProductId(int ProductId)
    {
        return appDbContext.Images.Where(x => x.ProductId == ProductId).ToList();
    }
    #endregion
}
