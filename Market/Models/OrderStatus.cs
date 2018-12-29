using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Market.Models
{
    public enum OrderStatus
    {
        Created,
        InProgress,
        Shipped,
        Delivered
    }
}