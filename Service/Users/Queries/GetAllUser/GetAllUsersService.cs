using ECommersShop.Common.Dto;
using ECommersShop.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ECommersShop.Service.Users.Queries.GetAllUser
{
    public class GetAllUsersService : IGetAllUsersService
    {
        private readonly AppDbContex _context;

        public GetAllUsersService(AppDbContex context) => _context = context;

        public async Task<ResultsDto<GetUserDto>> Execute()
        {
            var users = await _context.Users
                                .Where(u => u.IsRemoved == false)
                                .Select(u => new GetUserDto(u.Id, u.FullName, u.Email))
                                .ToListAsync();
            
            return new ResultsDto<GetUserDto>
            {
                IsSucssecc = true,
                Message = "this All User",
                Data = users
            };
        }
    }
}