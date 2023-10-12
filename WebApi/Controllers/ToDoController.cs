using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;
[Route("[controller]")]
public class ToDoController:ControllerBase
{
    private readonly IToDoService _service;
    public ToDoController(IToDoService service)=>_service = service;


    [HttpGet("GetToDosAsync")]
    public async Task<Response<List<GetToDoDto>>> GetToDosAsync() { 
        return await _service.GetToDosAsync();
    }

    [HttpGet("GetToDoByIdAsync")]
    public async Task<Response<GetToDoDto>> GetToDoByIdAsync(int id) { 
        return await _service.GetToDoByIdAsync(id);
    }

    [HttpPost("AddToDoAsync")]
    public async Task<Response<AddToDoDto>> AddToDoAsync(AddToDoDto model) { 
        return await _service.AddToDoAsync(model);
    }

    [HttpPut("UpdateToDoAsync")]
    public async Task<Response<AddToDoDto>> UpdateToDoAsync(AddToDoDto model) { 
        return await _service.UpdateToDoAsync(model);
    }

    [HttpDelete("DeleteToDoAsync")]
    public async Task<Response<string>> DeleteToDoAsync(int id) { 
        return await _service.DeleteToDoAsync(id);
    }

}
