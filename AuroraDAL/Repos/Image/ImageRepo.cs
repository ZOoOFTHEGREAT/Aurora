using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL.Repos;

public class ImageRepo : GenericRepo<Image>, IImageRepo
{
    public ImageRepo(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
