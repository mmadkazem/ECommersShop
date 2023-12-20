using ECommersShop.Persistance;
using ECommersShop.Service.Roles.Commands;
using ECommersShop.Service.Roles.Commands.HardRemovedRolesInUser;
using ECommersShop.Service.Roles.Commands.RemovedRolesUser;
using ECommersShop.Service.Roles.Commands.UpdateRole;
using ECommersShop.Service.Roles.Queries.GeRolesReomvedByUserId;
using ECommersShop.Service.Roles.Queries.GetRoles;

namespace ECommersShop.FacadPattern.Roles
{
    public class RolesSeviceFacad : IRolesSeviceFacad
    {
        private readonly DataBaseContext _context;
        public RolesSeviceFacad(DataBaseContext context) => _context = context;

        private IGetRolesByUserIdService _getRolesByUserId;
        public IGetRolesByUserIdService GetRolesByUserId
        {
            get
            {
                return _getRolesByUserId = _getRolesByUserId ??
                    new GetRolesByUserIdService(_context);
            }
        }

        private IGetRolesReomvedByUserIdService _getRolesReomvedByUserId;
        public IGetRolesReomvedByUserIdService GetRolesReomvedByUserId
        {
            get
            {
                return _getRolesReomvedByUserId = _getRolesReomvedByUserId ??
                    new GetRolesReomvedByUserIdService(_context);
            }
        }

        private IAddNewRoleInUserService _addNewRoleInUser;
        public IAddNewRoleInUserService AddNewRoleInUser
        {
            get
            {
                return _addNewRoleInUser = _addNewRoleInUser ??
                    new AddNewRoleInUserService(_context);
            }
        }
        private IRemovedRolesUserService _removedRolesUser;
        public IRemovedRolesUserService RemovedRolesUser
        {
            get
            {
                return _removedRolesUser = _removedRolesUser ??
                    new RemovedRolesUserService(_context);
            }
        }

        private IUpdateRoleInUserService _updateRoleInUser;
        public IUpdateRoleInUserService UpdateRoleInUser
        {
            get
            {
                return _updateRoleInUser = _updateRoleInUser ??
                    new UpdateRoleInUserService(_context);
            }
        }

        private IHardRemovedRolesInUserService _hardRemovedRolesInUser;
        public IHardRemovedRolesInUserService HardRemovedRolesInUser
        {
            get
            {
                return _hardRemovedRolesInUser = _hardRemovedRolesInUser ?? 
                    new HardRemovedRolesInUserService(_context);
            }
        }
    }
}