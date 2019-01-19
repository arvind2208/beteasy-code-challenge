using System;
using System.Collections.Generic;
using System.Text;

namespace dotnet_code_challenge.Services
{
    public interface IService<TResponse>
    {
        TResponse Invoke();
    }
}
