using ECommersShop.Common.Dto;
using ECommersShop.Persistance;

namespace ECommersShop.Service.Users.Commands.ReturnUser
{
    public class ReturnRemovedUserService : IReturnRemovedUserService
    {
        private readonly AppDbContex _context;
        public ReturnRemovedUserService(AppDbContex context) => _context = context;
        public async Task<ResultDto> Execute(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user is null)
            {
                return new ResultDto
                {
                    IsSucssecc = false,
                    Message = "Not users removed exited!!!"
                };
            }
            user.IsRemoved = false;
            user.RemoveTime = null;
            await _context.SaveChangesAsync();

            return new ResultDto
            {
                IsSucssecc = true,
                Message = "This user removed is back"
            };
        }
    }
}