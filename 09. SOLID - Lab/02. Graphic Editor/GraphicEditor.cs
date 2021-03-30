using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

using P02.Graphic_Editor.Contracts;

namespace P02.Graphic_Editor
{
    public abstract class GraphicEditor : IGraphicEditor
    {
        public void DrawShape(IShape shape)
        {
            this.DrawFigure(shape);
        }

        public abstract void DrawFigure(IShape shape);
    }
}
