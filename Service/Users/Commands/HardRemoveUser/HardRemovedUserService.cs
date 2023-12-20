using ECommersShop.Common.Dto;
using ECommersShop.Persistance;

namespace ECommersShop.Service.Users.Commands.HardRemoveUser
{
    public class HardRemovedUserService : IHardRemovedUserService
    {
        private readonly DataBaseContext _context;
        public HardRemovedUserService(DataBaseContext context) => _context = context;

        public async Task<ResultDto> Execute(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user is null)
            {
                return new ResultDto
                {
                    IsSucssecc = false,
                    Message = "This user does not exist!!!"
                };
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return new ResultDto
            {
                IsSucssecc = true,
                Message = "This user hard removed..."
            };
        }
    }
}