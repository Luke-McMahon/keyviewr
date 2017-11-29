using System;
using System.Drawing;
using System.Drawing.Imaging;
using OpenTK.Graphics.OpenGL;
using PixelFormat = System.Drawing.Imaging.PixelFormat;

namespace KeyboardViewer
{
    public class Sprite
    {
        private Color _tint;
        private readonly int _texId;
        private const int VERTEX_POS = 128;

        public Sprite() : this("a.png")
        {
        }

        public Sprite(string filename)
        {
            _texId = LoadTexture(filename);
            Untyped();
        }

        public int LoadTexture(string file)
        {
            Bitmap bmp = new Bitmap(file);
            int tex;

            GL.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest);

            GL.GenTextures(1, out tex);
            GL.BindTexture(TextureTarget.Texture2D, tex);

            BitmapData data = bmp.LockBits(new System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);

            return tex;
        }

        public void Draw()
        {
            GL.MatrixMode(MatrixMode.Projection);
            GL.PushMatrix();
            GL.LoadIdentity();

            GL.Ortho(0, 1600, 0, 1200, -1, 1);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.PushMatrix();
            GL.LoadIdentity();

            GL.Disable(EnableCap.Lighting);
            GL.Enable(EnableCap.Texture2D);

            GL.BindTexture(TextureTarget.Texture2D, _texId);

            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0, 0);
            GL.Color3(_tint);
            GL.Vertex3(128, 128 + VERTEX_POS, 0);

            GL.TexCoord2(1, 0);
            GL.Color3(_tint);
            GL.Vertex3(128 + VERTEX_POS, 128 + VERTEX_POS, 0);

            GL.TexCoord2(1, 1);
            GL.Color3(_tint);
            GL.Vertex3(128 + VERTEX_POS, 0, 0);


            GL.TexCoord2(0, 1);
            GL.Color3(_tint);
            GL.Vertex3(128, 0, 0);

            GL.End();

            GL.Disable(EnableCap.Texture2D);
            GL.PopMatrix();

            GL.MatrixMode(MatrixMode.Projection);
            GL.PopMatrix();
            
            GL.MatrixMode(MatrixMode.Modelview);
        }

        public void Typed()
        {
            _tint = Color.LightGreen;
        }

        public void Untyped()
        {
            _tint = Color.Transparent;
        }
    }
}