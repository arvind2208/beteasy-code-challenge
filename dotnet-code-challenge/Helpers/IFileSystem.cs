namespace dotnet_code_challenge.Helpers
{
    public interface IFileSystem
    { 
        string ReadAllText(string path);
    }
}
