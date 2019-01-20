namespace dotnet_code_challenge.Services
{
    public interface IService<TResponse>
    {
        TResponse Invoke();
    }
}
