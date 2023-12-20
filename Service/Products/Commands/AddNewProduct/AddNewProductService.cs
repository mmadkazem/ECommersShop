using ECommersShop.Common.Dto;
using ECommersShop.Entity.Products;
using ECommersShop.Persistance;
using Microsoft.EntityFrameworkCore;

namespace ECommersShop.Service.Products.Commands.AddNewProduct
{
    public class AddNewProductService : IAddNewProductService
    {
        private readonly DataBaseContext _context;

        public AddNewProductService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<ResultDto> Execute(AddNewProductDto model)
        {
            var product = new Product
            {
                Name = model.Name,
                Brand = model.Brand,
                Description = model.Decription,
                Inventory = model.Inventory,
                Price = model.Price,
                Displayed = model.Displayed
            };

            var productInCategory = new List<ProductInCategory>();
            foreach (var item in model.CategoriesId)
            {
                var category = await _context.Categories
                                .Where(c => !c.IsRemoved && c.Id == item)
                                .FirstOrDefaultAsync();
                productInCategory.Add(new ProductInCategory
                {
                    Product = product,
                    ProductId = product.Id,
                    Category = category,
                    CategryId = category.Id
                });
            }
            product.ProductInCategories = productInCategory;

            await _context.Products.AddAsync (product);
            await _context.SaveChangesAsync();

            return new ResultDto
            {
                IsSucssecc = true,
                Message = "This added product successfully..."
            };

        }
    }
}