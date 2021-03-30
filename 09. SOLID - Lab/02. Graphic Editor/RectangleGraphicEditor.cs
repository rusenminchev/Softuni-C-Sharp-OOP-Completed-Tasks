using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor.Contracts
{
    public class RectangleGraphicEditor : IGraphicEditor
    {
        public void DrawShape(IShape shape)
        {
            Rectangle rectangle = shape as Rectangle;

            Console.WriteLine("|||||||||||");
        }
    }
}
