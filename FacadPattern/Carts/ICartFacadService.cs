using ECommersShop.Persistance;
using ECommersShop.Service.Carts.Commands.AddNewCart;
using ECommersShop.Service.Carts.Commands.RemoveCartItem;
using ECommersShop.Service.Carts.Commands.UpdateCountCartItem;
using ECommersShop.Service.Carts.Queries.GetUserCart;

namespace ECommersShop.FacadPattern.Carts
{
    public interface ICartServiceFacad
    {
        IAddNewCartService AddNewCart { get; }
        IGetUserCartService GetUserCart { get; }
        IRemoveCartItemService RemoveCartItem { get; }
        IUpdateCountCartItemService UpdateCountCartItem { get; }
    }
    public class CartServiceFacad : ICartServiceFacad
    {
        private readonly DataBaseContext _context;

        public CartServiceFacad(DataBaseContext context)
        {
            _context = context;
        }

        private IAddNewCartService _addNewCart;
        public IAddNewCartService AddNewCart
        {
            get
            {
                return _addNewCart = _addNewCart ??
                    new AddNewCartService(_context);
            }
        }

        private IGetUserCartService _getUserCart;
        public IGetUserCartService GetUserCart
        {
            get
            {
                return _getUserCart = _getUserCart ??
                    new GetUserCartService(_context);
            }
        }

        private IRemoveCartItemService _removeCartItem;
        public IRemoveCartItemService RemoveCartItem
        {
            get
            {
                return _removeCartItem = _removeCartItem ??
                    new RemoveCartItemService(_context);
            }
        }

        private IUpdateCountCartItemService _updateCountCartItem;
        public IUpdateCountCartItemService UpdateCountCartItem
        {
            get
            {
                return _updateCountCartItem = _updateCountCartItem ??
                    new UpdateCountCartItemService(_context);
            }
        }
    }
}