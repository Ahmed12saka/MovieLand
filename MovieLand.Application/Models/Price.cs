using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLand.Application.Models
{
    public class Price
    {
        public Price(
            decimal amount,
            string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public virtual long? Id { get; protected internal set; }
        public virtual decimal Amount { get; protected internal set; }
        public virtual string Currency { get; protected internal set; }
        public virtual Movie movie { get; protected internal set; }
    }
}
