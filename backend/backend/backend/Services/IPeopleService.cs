using backend.Controllers;

namespace backend.Services
{
    public interface IPeopleService
    {
        bool Validate(People people);
    }
}
