using backend.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace backend.Services
{
    //Se agregan genericos <T> para que este servicio pueda ser utilizado por cualquier entidad
    public interface ICommonService<T, TI, TU>
    {
        public List<string> Errors { get; } 
        Task<IEnumerable<T>> GetAllAsync();
        Task<T>GetByIdAsync(int id);
        Task<T>CreateAsync(TI beerInsertDto);
        Task<T>UpdateAsync(int id, TU beerUpdateDto);
        Task<T>DeleteAsync(int id);
        bool Validate(TI dto);
        bool Validate(TU dto);

    }
}


