using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLand.Application.Models
{
    public class ShoppingCartItem : IDatabaseModel
    {
        public virtual long? Id { get; protected internal set; }
        public virtual long? MovieId { get; protected internal set; }
        public virtual long? ShoppingCartId { get; protected internal set; }
        public virtual Movie Movie { get; protected internal set; }
        public virtual ShoppingCart ShoppingCart { get; protected internal set; }

        protected ShoppingCartItem()
        {

        }

        protected ShoppingCartItem(
            Movie movie,
            ShoppingCart shoppingCart)
        {
            MovieId = movie.Id;
            ShoppingCartId = shoppingCart.Id;
            Movie = movie;
            ShoppingCart = shoppingCart;
        }

        public static ShoppingCartItem Create(
            Movie movie,
            ShoppingCart shoppingCart)
        {
            return new ShoppingCartItem(
                movie,
                shoppingCart);
        }
    }
}
