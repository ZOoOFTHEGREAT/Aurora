﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL;

public interface ICartItemRepo:IGenericRepo<CartItem>
{
    List<CartItem>? GetCartItemByCartId(int id);

}
