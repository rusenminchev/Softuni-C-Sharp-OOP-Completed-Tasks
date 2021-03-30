using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor.Contracts
{
    public class CircleGraphicEditor : GraphicEditor
    {
        public override void DrawFigure(IShape shape)
        {
            Circle circle = shape as Circle;

            Console.WriteLine("O");
        }
    }
}
