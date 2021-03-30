using P02.Graphic_Editor.Contracts;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace P02.Graphic_Editor
{
    public class SquareGraphicEditor : IGraphicEditor
    {
        public void DrawShape(IShape shape)
        {
            Square square = shape as Square;

            Console.WriteLine("| |");
        }
    }
}
