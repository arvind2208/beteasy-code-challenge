using System;
using System.Collections.Generic;
using System.Text;

namespace dotnet_code_challenge.Helpers
{
    public interface IFileSystem
    { 
        string ReadAllText(string path);
    }
}
