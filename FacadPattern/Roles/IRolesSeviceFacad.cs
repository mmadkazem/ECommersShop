using ECommersShop.Service.Roles.Commands;
using ECommersShop.Service.Roles.Commands.HardRemovedRolesInUser;
using ECommersShop.Service.Roles.Commands.RemovedRolesUser;
using ECommersShop.Service.Roles.Commands.UpdateRole;
using ECommersShop.Service.Roles.Queries.GeRolesReomvedByUserId;
using ECommersShop.Service.Roles.Queries.GetRoles;

namespace ECommersShop.FacadPattern.Roles
{
    public interface IRolesSeviceFacad
    {
        IGetRolesByUserIdService GetRolesByUserId { get; }
        IGetRolesReomvedByUserIdService GetRolesReomvedByUserId { get; }
        IAddNewRoleInUserService AddNewRoleInUser { get; }
        IRemovedRolesUserService RemovedRolesUser { get; }
        IUpdateRoleInUserService UpdateRoleInUser { get; }
        IHardRemovedRolesInUserService HardRemovedRolesInUser { get; }
    }
}