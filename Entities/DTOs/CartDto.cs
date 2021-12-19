﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CartDto : IDto
    {
        public int UserId { get; set; }
        public double TotalCartPrice { get; set; }
    }
}
