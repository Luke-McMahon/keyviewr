using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace KeyboardViewer
{
    class View
    {
        public Vector2 Position;
        public double Rotation;
        public double Zoom;

        public View(Vector2 position, double zoom = 1.0, double rotation = 0.0)
        {
            Position = position;
            Zoom = zoom;
            Rotation = rotation;
        }
        
        public void ApplyTransform()
        {
            Matrix4 transform = Matrix4.Identity;
            transform = Matrix4.Mult(transform, Matrix4.CreateTranslation(-Position.X, -Position.Y, 0.0f));
            transform = Matrix4.Mult(transform, Matrix4.CreateRotationZ(-(float) Rotation));
            transform = Matrix4.Mult(transform, Matrix4.CreateScale((float)Zoom, (float)Zoom, 1.0f));

            GL.MultMatrix(ref transform);
        }
    }
}
