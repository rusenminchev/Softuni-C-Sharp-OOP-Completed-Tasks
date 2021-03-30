using P02.Graphic_Editor.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor
{
    public class TriangleGraphicEditor : IGraphicEditor
    {
        public void DrawShape(IShape shape)
        {
            Triangle triangle = shape as Triangle;

            Console.WriteLine("/|");
        }
    }
}
