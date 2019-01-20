using System;
using System.Collections.Generic;
using System.Text;

namespace dotnet_code_challenge.Renderers
{
    public interface IRenderer<T>
    {
        void Render(T data);
    }
}
