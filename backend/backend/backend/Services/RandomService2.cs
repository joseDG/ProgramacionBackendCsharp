namespace backend.Services
{
    public class RandomService2 : IRandomService
    {
        private readonly int _value;
        
        public int Value
        {
            get { return _value; }
        }

        public RandomService2()
        {
            var random = new Random();
            _value = random.Next(1, 100);
        }
    }
}
