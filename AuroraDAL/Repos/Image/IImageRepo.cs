﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AuroraDAL;

public interface IImageRepo:IGenericRepo<Image>
{
    List<Image>? GetImagesByProductId(int id);
}
