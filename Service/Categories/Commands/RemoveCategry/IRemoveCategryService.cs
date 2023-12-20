using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommersShop.Common.Dto;

namespace ECommersShop.Service.Categories.Commands.RemoveCategry
{
    public interface IRemoveCategryService
    {
        Task<ResultDto> Execute(int id);
    }
}