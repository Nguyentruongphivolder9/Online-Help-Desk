using Application.Services;

namespace Infrastructure.Services
{
    public class RandomService : IRandomService
    {
        public Task<string> RandomCode()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 10000000);
            string formattedNumber = randomNumber.ToString("D7");
            return Task.FromResult(formattedNumber);
        }
    }
}
