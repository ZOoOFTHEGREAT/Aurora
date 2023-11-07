using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL.Repos;

public class ImageRepo : GenericRepo<Image>, IImageRepo
{
    private readonly AppDbContext appDbContext;

    public ImageRepo(AppDbContext appDbContext) : base(appDbContext)
    {
        this.appDbContext = appDbContext;
    }

    public List<Image>? GetImagesByProductId(int id)
    {
        return appDbContext.Images.Where(x => x.ProductId == id).ToList();
    }
}
