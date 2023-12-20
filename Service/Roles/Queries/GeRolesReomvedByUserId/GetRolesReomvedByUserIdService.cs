using ECommersShop.Common.Dto;
using ECommersShop.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ECommersShop.Service.Roles.Queries.GeRolesReomvedByUserId
{
    public class GetRolesReomvedByUserIdService : IGetRolesReomvedByUserIdService
    {
        private readonly DataBaseContext _context;
        public GetRolesReomvedByUserIdService(DataBaseContext context) => _context = context;
        public async Task<ResultsDto<GetRemovedRolesDto>> Execute(int userId)
        {
            var roles = await _context.UserInRoles
                        .Where(u => u.IsRemoved && u.UserId == userId)
                        .Select(u => new GetRemovedRolesDto(u.Role.ToString(),
                                 u.RemoveTime, u.InsertTime, u.UpdateTime))
                        .ToListAsync();

            if (roles.Count == 0)
            {
                return new ResultsDto<GetRemovedRolesDto>
                {
                    IsSucssecc = false,
                    Message = "This user in roles does not exist!!!"
                };
            }
            return new ResultsDto<GetRemovedRolesDto>
            {
                Data = roles,
                IsSucssecc = true,
                Message = $"Roles of this user with id: {userId}"
            };

        }
    }
}