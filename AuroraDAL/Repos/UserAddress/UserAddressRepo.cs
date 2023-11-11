﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL;

public class UserAddressRepo : GenericRepo<UserAddress>, IUserAddressRepo
{
    #region Inject
    private readonly AppDbContext appDbContext;

    public UserAddressRepo(AppDbContext appDbContext) : base(appDbContext)
    {
        this.appDbContext = appDbContext;
    }
    #endregion

    #region Get User Address By User Id
    public List<UserAddress>? GetAddressesByUserId(string id)
    {
        return appDbContext.UserAddresses.Where(x => x.UserId == id).ToList();
    }
}
    #endregion
