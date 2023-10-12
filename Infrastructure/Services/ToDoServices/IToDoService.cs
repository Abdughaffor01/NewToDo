using Domain;

namespace Infrastructure;
public interface IToDoService
{
    Task<Response<List<GetToDoDto>>> GetToDosAsync();
    Task<Response<GetToDoDto>> GetToDoByIdAsync(int id);
    Task<Response<AddToDoDto>> AddToDoAsync(AddToDoDto model);
    Task<Response<AddToDoDto>> UpdateToDoAsync(AddToDoDto model);
    Task<Response<string>> DeleteToDoAsync(int id);
}
