namespace backend.Services
{
    public class RandomService : IRandomService
    {
        private readonly int _value;
        
        public int Value
        {
            get { return _value; }
        }

        public RandomService()
        {
            var random = new Random();
            _value = random.Next(1, 100);
        }
    }
}
