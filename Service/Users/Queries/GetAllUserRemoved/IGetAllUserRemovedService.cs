using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommersShop.Common.Dto;

namespace ECommersShop.Service.Users.Queries.GetAllUserRemoved
{
    public interface IGetAllUserRemovedService
    {
        Task<ResultsDto<GetRemovedUserDto>> Execute();
    }
}