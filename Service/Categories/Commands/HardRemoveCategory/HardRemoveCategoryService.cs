using ECommersShop.Common.Dto;
using ECommersShop.Persistance;
using ECommersShop.Service.Categories.Commands.HardRemoveCategory;
using Microsoft.EntityFrameworkCore;

public class HardRemoveCategoryService : IHardRemoveCategoryService
{
    private readonly DataBaseContext _context;

    public HardRemoveCategoryService(DataBaseContext context)
    {
        _context = context;
    }

    public async Task<ResultDto> Execute(int id)
    {
        var category = await _context.Categories
                        .Where(c => c.IsRemoved && c.Id == id)
                        .FirstOrDefaultAsync();
        if (category is null)
        {
            return new ResultDto
            {
                IsSucssecc = false,
                Message = "This category dose not exist!!!"
            };
        }

        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();

        return new ResultDto
        {
            IsSucssecc = true,
            Message = "This category hard removed successfully..."
        };
    }
}
