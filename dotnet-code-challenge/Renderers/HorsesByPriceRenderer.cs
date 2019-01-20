using dotnet_code_challenge.Helpers;
using dotnet_code_challenge.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace dotnet_code_challenge.Renderers
{
    public class HorsesByPriceRenderer : IRenderer<IEnumerable<Horse>>
    {
        private readonly IWriter _writer;

        public HorsesByPriceRenderer(IWriter writer)
        {
            _writer = writer;
        }

        public void Render(IEnumerable<Horse> horses)
        {
            _writer.WriteLine("Horses by Price");
            _writer.WriteLine(string.Empty);
            _writer.WriteLine($"{"Horse".PadRight(20)} Price");
            _writer.WriteLine("============================");

            if (horses == null)
                throw new ApplicationException("Horses array provided to render is invalid");

            foreach (var horse in horses)
            {
                _writer.WriteLine($"{horse.Name.Trim().PadRight(20)} {horse.Price:C}");
            }

        }
    }
}
