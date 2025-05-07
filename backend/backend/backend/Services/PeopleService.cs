using backend.Controllers;

namespace backend.Services
{
    public class PeopleService : IPeopleService
    {
        public bool Validate(People people)
        {
            if (string.IsNullOrEmpty(people.Name) || people.Name.Length < 1)
            {
                return false;
            }
            return true;
        }
    }
}
