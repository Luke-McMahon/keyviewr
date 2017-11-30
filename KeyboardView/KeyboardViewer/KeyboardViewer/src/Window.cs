using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace KeyboardViewer
{
    public class Window : GameWindow
    {
        private const string WINDOW_TITLE = "Keyboard Viewer";
        private KeyManager _keyManager;
        private View _view;
        private Color _backgroundColor = Color.Blue;
        private Random _rng;
        private Sprite _aKey;
        private Texture2D[] _texture;

        public Window(int width, int height) : base(width, height)
        {
            GL.Enable(EnableCap.Texture2D);
            _view = new View(Vector2.Zero, 0.0075, 0.0);
            _texture = new Texture2D[2];
        }

        protected override void OnLoad(EventArgs e)
        {
            _keyManager = new KeyManager();
            _rng = new Random();
            _keyManager.View.RegisterKey(Key.A, _aKey);

            _texture[0] = ContentPipe.LoadTexture("a.png");
            _texture[1] = ContentPipe.LoadTexture("keyboard.png");


            base.OnLoad(e);

            this.Title = WINDOW_TITLE;
        }

        protected override void OnKeyDown(KeyboardKeyEventArgs e)
        {
            _keyManager.AddKey(e.Key);
            _keyManager.PrintKeys();
            
            base.OnKeyDown(e);
        }

        protected override void OnKeyUp(KeyboardKeyEventArgs e)
        {
            _keyManager.RemoveKey(e.Key);
            base.OnKeyUp(e);
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            Console.WriteLine("Pressed: " + e.Button);
            base.OnMouseDown(e);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.ClearColor(_backgroundColor);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            SpriteBatch.Begin(Width, Height);
            GL.LoadIdentity();
            _view.ApplyTransform();
            SpriteBatch.Draw(_texture[1], new Vector2(0.2f, 0.3f), new Vector2(0.2f, 0.2f), Color.Red, new Vector2(10.0f, 50.0f));
            SpriteBatch.Draw(_texture[0], new Vector2(-150 + _texture[0].Width, 0.0f), new Vector2(0.2f, 0.2f), Color.Green, new Vector2(10.0f, 50.0f));

            SwapBuffers();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            Console.WriteLine("[NOTE] Window resized. Current size: " + this.Size);
        }
    }
}
