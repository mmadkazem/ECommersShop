using ECommersShop.Common.Dto;
using ECommersShop.Persistance;
using ECommersShop.Service.Users.Queries.GetAllUser;
using Microsoft.EntityFrameworkCore;

namespace ECommersShop.Service.Users.Queries.GetUserById
{
    public class GetUserByIdService : IGetUserByIdService
    {
        private readonly DataBaseContext _context;
        public GetUserByIdService(DataBaseContext context) => _context =context;
        public async Task<ResultDto<GetUserDto>> Execute(int id)
        {
            var user = await _context.Users
                        .Where(u => u.Id == id && u.IsRemoved == false)
                        .Select(u => new GetUserDto(u.Id, u.FullName, u.Email))
                        .FirstOrDefaultAsync();
            if (user is null)
            {
                return new ResultDto<GetUserDto>
                {
                    IsSucssecc = false,
                    Message = "This user does not exist!!!!!!"
                };
            }
            return new ResultDto<GetUserDto>
            {
                IsSucssecc = true,
                Message = "This User is Found...",
                Data = user
            };
        }
    }
}