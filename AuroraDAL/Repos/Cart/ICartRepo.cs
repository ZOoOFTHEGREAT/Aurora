﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL;

public interface ICartRepo:IGenericRepo<Cart>
{
    Cart? GetCartByUserId(string id);
}
