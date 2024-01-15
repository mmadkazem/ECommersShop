using ECommersShop.Persistance;
using ECommersShop.Service.Carts.Commands.AddNewCart;

namespace ECommersShop.FacadPattern.Carts
{
    public interface ICartServiceFacad
    {
        IAddNewCartService AddNewCart { get; }
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
    }
}