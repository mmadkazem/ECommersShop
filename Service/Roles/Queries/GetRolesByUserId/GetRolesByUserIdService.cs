using ECommersShop.Common.Dto;
using ECommersShop.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ECommersShop.Service.Roles.Queries.GetRoles
{
    public class GetRolesByUserIdService : IGetRolesByUserIdService
    {
        private readonly AppDbContex _contex;
        public GetRolesByUserIdService(AppDbContex contex) => _contex = contex;

        public async Task<ResultsDto<GetRolesDto>> Execute(int userId)
        {
            var roles = await _contex.UserInRoles
                        .Where(u => u.IsRemoved == false && u.UserId == userId)
                        .Select(u => new GetRolesDto(u.Role.ToString(), 
                            u.UpdateTime, u.InsertTime))
                        .ToListAsync();
            if (roles.Count == 0)
            {
                return new ResultsDto<GetRolesDto>
                {
                    IsSucssecc = false,
                    Message = "This User In roles NotFound!!!"
                };
            }
            return new ResultsDto<GetRolesDto>
            {
                Data = roles,
                IsSucssecc = true,
                Message = $"Roles of this user with id: {userId}"
            };
        }
    }
}