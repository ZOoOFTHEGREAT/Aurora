﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL;

public interface IUserRepo : IGenericRepo<User>
{
    User GetUserById(string id);
    User? GetUSerByPhoneNumber(string phoneNumber);
    User? GetUSerByEmail(string email);
}
