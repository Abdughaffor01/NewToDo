using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;
[Route("[controller]")]

public class CategoryController:ControllerBase
{
    private readonly ICategoryService _service;
    public CategoryController(ICategoryService service)=>_service = service;



    [HttpGet("GetCategoriesAsync")]
    public async Task<Response<List<GetCategoryDto>>> GetCategoriesAsync() { 
        return await _service.GetCategoriesAsync();
    }

    [HttpGet("GetCategoryByIdAsync")]
    public async Task<Response<GetCategoryWithToDo>> GetCategoryByIdAsync(int id) { 
        return await _service.GetCategoryByIdAsync(id);
    }

    [HttpPost("AddCategoryAsync")]
    public async Task<Response<AddCategoryDto>> AddCategoryAsync(AddCategoryDto model) { 
        return await _service.AddCategoryAsync(model);
    }

    [HttpDelete("DeleteCategoryAsync")]
    public async Task<Response<string>> DeleteCategoryAsync(int id) { 
        return await _service.DeleteCategoryAsync(id);
    }

    [HttpPut("UpdateCategoryAsync")]
    public async Task<Response<AddCategoryDto>> UpdateCategoryAsync(AddCategoryDto model) { 
        return await _service.UpdateCategoryAsync(model);
    }
}
