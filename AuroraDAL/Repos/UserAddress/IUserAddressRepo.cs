﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL;

public interface IUserAddressRepo:IGenericRepo<UserAddress>
{
    UserAddress? GetUserAddresByUserId(string UserId);
}
