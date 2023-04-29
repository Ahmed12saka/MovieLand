using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLand.Application.Models
{
    public enum ShoppingCartStatus
    {
        Pending,
        Paid,
        Completed,
        Canceled = 999
    }
}
