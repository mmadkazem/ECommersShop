using ECommersShop.Persistance;
using ECommersShop.Service.Finances.Commands;

namespace ECommersShop.FacadPattern.Finances
{
    public interface IFinancesServiceFacad
    {
        IAddRequestPayService AddRequestPay { get; }
    }

    public class FinancesServiceFacad : IFinancesServiceFacad
    {
        public DataBaseContext _context;

        public FinancesServiceFacad(DataBaseContext context)
        {
            _context = context;
        }

        private IAddRequestPayService _addRequestPay;
        public IAddRequestPayService AddRequestPay
        {
            get
            {
                return _addRequestPay = _addRequestPay ??
                    new AddRequestPayService(_context);
            }
        }
    }
}