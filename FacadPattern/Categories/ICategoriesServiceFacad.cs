using ECommersShop.Persistance;
using ECommersShop.Service.Categories.Commands.AddNewCategory;
using ECommersShop.Service.Categories.Commands.HardRemoveCategory;
using ECommersShop.Service.Categories.Commands.RemoveCategry;
using ECommersShop.Service.Categories.Commands.ReturnRemovedCategory;
using ECommersShop.Service.Categories.Commands.UpdateCategory;
using ECommersShop.Service.Categories.Queries.GetAllCategories;
using ECommersShop.Service.Categories.Queries.GetAllRemovedCategories;
using ECommersShop.Service.Categories.Queries.GetCategoryById;
using ECommersShop.Service.Categories.Queries.GetRemovedCategoryById;

namespace ECommersShop.FacadPattern.Categories
{
    public interface ICategoriesServiceFacad
    {
        // Queries Services
        IGetAllCategoriesService GetAllCategories { get; }
        IGetAllRemovedCategoriesService GetAllRemovedCategories { get; }
        IGetCategoryByIdService GetCategoryById { get; }
        IGetRemovedCategoryByIdService GetRemovedCategoryById { get; }

        // Commands Services
        IAddNewCategoryService AddNewCategory { get; }
        IUpdateCategoryService UpdateCategory { get; }
        IRemoveCategryService RemoveCategry { get; }
        IHardRemoveCategoryService HardRemoveCategory { get; }
        IReturnRemovedCategoryService ReturnRemovedCategory { get; }
    }

    public class CategoriesServiceFacad : ICategoriesServiceFacad
    {
        private readonly DataBaseContext _context;
        public CategoriesServiceFacad(DataBaseContext context) => _context = context;

        private IGetAllCategoriesService _getAllCategories;
        public IGetAllCategoriesService GetAllCategories
        {
            get
            {
                return _getAllCategories = _getAllCategories ??
                    new GetAllCategoriesService(_context);
            }
        }


        private IGetAllRemovedCategoriesService _getAllRemovedCategories;
        public IGetAllRemovedCategoriesService GetAllRemovedCategories
        {
            get
            {
                return _getAllRemovedCategories = _getAllRemovedCategories ??
                    new GetAllRemovedCategoriesService(_context);
            }
        }

        private IGetCategoryByIdService _getCategoryById;
        public IGetCategoryByIdService GetCategoryById
        {
            get
            {
                return _getCategoryById = _getCategoryById ??
                    new GetCategoryByIdService(_context);
            }
        }

        private IGetRemovedCategoryByIdService _getRemovedCategoryById;
        public IGetRemovedCategoryByIdService GetRemovedCategoryById
        {
            get
            {
                return _getRemovedCategoryById = _getRemovedCategoryById ??
                    new GetRemovedCategoryByIdService(_context);
            }
        }

        // Commadns 
        private IAddNewCategoryService _addNewCategory;
        public IAddNewCategoryService AddNewCategory
        {
            get
            {
                return _addNewCategory = _addNewCategory ??
                    new AddNewCategoryService(_context);
            }
        }

        private IUpdateCategoryService _updateCategory;
        public IUpdateCategoryService UpdateCategory
        {
            get
            {
                return _updateCategory = _updateCategory ??
                    new UpdateCategoryService(_context);
            }
        }

        private IRemoveCategryService _removeCategry;
        public IRemoveCategryService RemoveCategry
        {
            get
            {
                return _removeCategry = _removeCategry ??
                    new RemoveCategryService(_context);
            }
        }

        private IHardRemoveCategoryService _hardRemoveCategory;
        public IHardRemoveCategoryService HardRemoveCategory
        {
            get
            {
                return _hardRemoveCategory = _hardRemoveCategory ??
                    new HardRemoveCategoryService(_context);
            }
        } 

        private IReturnRemovedCategoryService _returnRemovedCategory;
        public IReturnRemovedCategoryService ReturnRemovedCategory
        {
            get
            {
                return _returnRemovedCategory = _returnRemovedCategory ??
                    new ReturnRemovedCategoryService(_context);
            }
        }
    }
}