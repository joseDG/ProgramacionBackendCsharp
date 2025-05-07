using backend.Controllers;

namespace backend.Services
{
    public class PeopleService2 : IPeopleService
    {
        public bool Validate(People people)
        {
            if (string.IsNullOrEmpty(people.Name) || people.Name.Length > 5)
            {
                return false;
            }
            return true;
        }
    }
}
