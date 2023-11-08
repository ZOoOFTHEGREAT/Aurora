﻿using AuroraDAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL;

public class Cart
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public string UserId { get; set; }=string.Empty;
    public User User { get; set; } = null!;
    public virtual ICollection<CartItem> CartItems { get; set;}=new List<CartItem>();
}
