using Domain;
namespace Infrastructure;
public interface ICategoryService
{
    Task<Response<List<GetCategoryDto>>> GetCategoriesAsync();
    Task<Response<GetCategoryWithToDo>> GetCategoryByIdAsync(int id);
    Task<Response<AddCategoryDto>> AddCategoryAsync(AddCategoryDto model);
    Task<Response<AddCategoryDto>> UpdateCategoryAsync(AddCategoryDto model);
    Task<Response<string>> DeleteCategoryAsync(int id);
}
