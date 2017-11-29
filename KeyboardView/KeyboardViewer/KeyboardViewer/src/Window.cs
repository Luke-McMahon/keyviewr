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
        private Color _backgroundColor = Color.Blue;
        private Random _rng;
        private Sprite _aKey;

        protected override void OnLoad(EventArgs e)
        {
            _keyManager = new KeyManager();
            _rng = new Random();
            _aKey = new Sprite();

            _keyManager.View.RegisterKey(Key.A, _aKey);

            base.OnLoad(e);

            this.Title = WINDOW_TITLE;
        }

        protected override void OnKeyDown(KeyboardKeyEventArgs e)
        {
            _keyManager.AddKey(e.Key);
            _keyManager.PrintKeys();
            //_backgroundColor = Color.FromArgb(_rng.Next(0, 255), _rng.Next(0, 255), _rng.Next(0, 255));
            
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

            foreach (var k in _keyManager.Keys)
            {
                k.Draw();
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            Console.WriteLine("[NOTE] Window resized. Current size: " + this.Size);
        }
    }
}
