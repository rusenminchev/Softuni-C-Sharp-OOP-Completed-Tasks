using P02.Graphic_Editor.Contracts;
using System;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            IShape rectangle = new Rectangle();

            RectangleGraphicEditor rectangleGraphicEditor = new RectangleGraphicEditor();
            rectangleGraphicEditor.DrawShape(rectangle);


            IShape circle = new Circle();

            CircleGraphicEditor circleGraphicEditor = new CircleGraphicEditor();
            circleGraphicEditor.DrawFigure(circle);

        }
    }
}
