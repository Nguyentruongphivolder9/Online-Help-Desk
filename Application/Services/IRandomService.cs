namespace Application.Services
{
    public interface IRandomService
    {
        Task<string> RandomCode();
    }
}
