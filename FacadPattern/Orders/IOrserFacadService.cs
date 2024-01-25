using ECommersShop.Persistance;
using ECommersShop.Service.Orders.Commands;
using ECommersShop.Service.Orders.Commands.RemveOrder;
using ECommersShop.Service.Orders.Queries.GetOderAll;

namespace ECommersShop.FacadPattern.Orders
{
    public interface IOrserFacadService
    {
        IAddNewOrderServise AddNewOrder { get; }
        IRemveOrderService RemveOrder { get; }
        IGetOrderAllService GetOrderAll { get; }
    }
    public class OrserFacadService : IOrserFacadService
    {
        private readonly DataBaseContext _context;

        public OrserFacadService(DataBaseContext context)
        {
            _context = context;
        }

        private IAddNewOrderServise _addNewOrder;
        public IAddNewOrderServise AddNewOrder 
        {
            get
            {
                return _addNewOrder = _addNewOrder ??
                    new AddNewOrderServise(_context);
            }
        }

        private IGetOrderAllService _getOrderAll;
        public IGetOrderAllService GetOrderAll
        {
            get
            {
                return _getOrderAll = _getOrderAll ??
                    new GetOrderAllService(_context);
            }
        }

        private IRemveOrderService _remveOrder;
        public IRemveOrderService RemveOrder
        {
            get
            {
                return _remveOrder = _remveOrder ??
                    new RemveOrderService(_context);
            }
        }
    }
}
