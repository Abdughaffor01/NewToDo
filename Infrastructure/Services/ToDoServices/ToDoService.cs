using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Infrastructure;
public class ToDoService : IToDoService
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;
    public ToDoService(IMapper mapper,DataContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<Response<AddToDoDto>> AddToDoAsync(AddToDoDto model)
    {
        try
        {
            var toDo = _mapper.Map<ToDo>(model);
            await _context.ToDos.AddAsync(toDo);
            await _context.SaveChangesAsync();
            var mapped=_mapper.Map<AddToDoDto>(toDo);
            return new Response<AddToDoDto>(mapped);
        }
        catch (Exception ex)
        {
            return new Response<AddToDoDto>(HttpStatusCode.InternalServerError,ex.Message); 
        }
    }

    public async Task<Response<string>> DeleteToDoAsync(int id)
    {
        try
        {
            var toDo = await _context.ToDos.FindAsync(id);
            if (toDo == null) return new Response<string>(HttpStatusCode.NotFound);
            _context.ToDos.Remove(toDo);
            await _context.SaveChangesAsync();
            return new Response<string>("Successfuly deleted toDo");
        }
        catch (Exception ex)
        {
            return new Response<string>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }

    public async Task<Response<GetToDoDto>> GetToDoByIdAsync(int id)
    {
        try
        {
            var toDo = await _context.ToDos.FindAsync(id);
            if (toDo == null) return new Response<GetToDoDto>(HttpStatusCode.NotFound);
            var mapped = _mapper.Map<GetToDoDto>(toDo);
            return new Response<GetToDoDto>(mapped);
        }
        catch (Exception ex)
        {
            return new Response<GetToDoDto>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }

    public async Task<Response<List<GetToDoDto>>> GetToDosAsync()
    {
        try
        {
            var toDos = await _context.ToDos.ToListAsync();
            var mapped = _mapper.Map<List<GetToDoDto>>(toDos);
            return new Response<List<GetToDoDto>>(mapped);
        }
        catch (Exception ex)
        {
            return new Response<List<GetToDoDto>>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }

    public async Task<Response<AddToDoDto>> UpdateToDoAsync(AddToDoDto model)
    {
        try
        {
            var toDo = await _context.ToDos.FindAsync(model.Id);
            if (toDo == null) return new Response<AddToDoDto>(HttpStatusCode.NotFound);
            _mapper.Map(model,toDo);
            await _context.SaveChangesAsync();
            var mapped = _mapper.Map<AddToDoDto>(toDo);
            return new Response<AddToDoDto>(mapped);
        }
        catch (Exception ex)
        {
            return new Response<AddToDoDto>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }
}
