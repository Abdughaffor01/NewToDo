using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Infrastructure;
public class CategoryService : ICategoryService
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;
    public CategoryService(DataContext context,IMapper mapper)
    {
        _mapper = mapper;
        _context = context;
    }
    public async Task<Response<AddCategoryDto>> AddCategoryAsync(AddCategoryDto model)
    {
        try
        {
            var category=_mapper.Map<Category>(model);
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            var mapped=_mapper.Map<AddCategoryDto>(category);
            return new Response<AddCategoryDto>(mapped);
        }
        catch (Exception ex)
        {
            return new Response<AddCategoryDto>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }

    public async Task<Response<string>> DeleteCategoryAsync(int id)
    {
        try
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return new Response<string>(HttpStatusCode.NotFound);
            _context.Categories.Remove(category);   
            await _context.SaveChangesAsync();
            return new Response<string>("Successfuly deleted category");
        }
        catch (Exception ex)
        {
            return new Response<string>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }

    public async Task<Response<List<GetCategoryDto>>> GetCategoriesAsync()
    {
        var categories =await _context.Categories.ToListAsync();
        var mapped = _mapper.Map<List<GetCategoryDto>>(categories);
        return new Response<List<GetCategoryDto>>(mapped);
    }

    public async Task<Response<GetCategoryWithToDo>> GetCategoryByIdAsync(int id)
    {
        try
        {
            var category = await _context.Categories.Select(c=>new GetCategoryWithToDo() { 
                Id = c.Id,
                Name=c.Name,
                ToDos=c.ToDos,
            }).FirstOrDefaultAsync(c=>c.Id==id);
            if (category == null) return new Response<GetCategoryWithToDo>(HttpStatusCode.NotFound);
            return new Response<GetCategoryWithToDo>(category);
        }
        catch (Exception ex)
        {
            return new Response<GetCategoryWithToDo>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }

    public async Task<Response<AddCategoryDto>> UpdateCategoryAsync(AddCategoryDto model)
    {
        try
        {
            var category=await _context.Categories.FindAsync(model.Id);
            if (category == null) return new Response<AddCategoryDto>(HttpStatusCode.NotFound);
            _mapper.Map(model,category);
            await _context.SaveChangesAsync();
            var mapped = _mapper.Map<AddCategoryDto>(category);
            return new Response<AddCategoryDto>(mapped);
        }
        catch (Exception ex)
        {
            return new Response<AddCategoryDto>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }
}
